using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HMMSReadEmail.Configuration;
using MimeKit;
using MimeKit.Cryptography;
using MimeKit.Tnef;
using EWS = Microsoft.Exchange.WebServices.Data;

namespace HMMSReadEmail
{

    public static class ExchangeServices
    {

        //const string ConfigSectionName = "ags/exchangeServices";
        const string ConfigSectionName = "ags/exchangeServices";
        const int ExtendedProperty_ConversationId = 0x3013;
        const int ExtendedProperty_HtmlBody = 0x1013;
        const string MultipartSignedContentType = "multipart/signed";

        static readonly ExchangeServicesSection s_Config = 
            ConfigurationManager.GetSection(ConfigSectionName) as ExchangeServicesSection ??
            throw new Error.MissingConfig(ConfigSectionName);
               
        public static List<IEmailMessage> GetIncomingEmails(
            string address,
            bool loadHtmlBody = false,
            CancellationToken cancellationToken = default)
        {

            Contract.Requires(!String.IsNullOrEmpty(address));

            var settings = GetConnectionSettings(address);

            List<IEmailMessage> GetEmails()
            {
                var service = new EWS.ExchangeService(settings.Version)
                {
                    Url = new Uri(settings.Url)
                };
                if (settings.UseDefaultCredentials)
                {
                    service.UseDefaultCredentials = true;
                }
                else
                {
                    service.Credentials = new NetworkCredential(settings.UserName, settings.Password, settings.Domain);
                }
                var mailbox = new EWS.Mailbox(address);
                var inboxFolderId = new EWS.FolderId(EWS.WellKnownFolderName.Inbox, mailbox);
                var propertySet = new EWS.PropertySet(EWS.BasePropertySet.FirstClassProperties)
                {
                    RequestedBodyType = EWS.BodyType.Text
                };
                if (loadHtmlBody)
                {
                    propertySet.Add(new EWS.ExtendedPropertyDefinition(ExtendedProperty_HtmlBody, EWS.MapiPropertyType.Binary));
                }
                propertySet.Add(new EWS.ExtendedPropertyDefinition(ExtendedProperty_ConversationId, EWS.MapiPropertyType.Binary));
                var view = new EWS.ItemView(100)
                {
                    OrderBy = { { EWS.ItemSchema.DateTimeReceived, EWS.SortDirection.Ascending } },
                    PropertySet = propertySet
                };

                var emails = (from item in service.FindItems(inboxFolderId, view)
                              let email = item as EWS.EmailMessage
                              where email != null
                              select email).ToList();
                if (emails.Count > 0)
                {
                    propertySet.Add(EWS.ItemSchema.MimeContent);
                    service.LoadPropertiesForItems(emails, propertySet);
                }
                return emails.ConvertAll(email => {
                    if (email.ItemClass == "IPM.Note.SMIME")
                    {
                        using (var memoryStream = new MemoryStream(email.MimeContent.Content))
                        {
                            memoryStream.Position = 0L;
                            var pkcs7Mime = (ApplicationPkcs7Mime)MimeEntity.Load(memoryStream);
                            CryptographyContext.Register(typeof(WindowsSecureMimeContext));
                            pkcs7Mime.Verify(out var mimeEntity);
                            var multipart = (Multipart)mimeEntity;
                            var body = multipart.OfType<TextPart>().FirstOrDefault()?.Text;
                            var message = multipart.OfType<TnefPart>().FirstOrDefault()?.ConvertToMessage();
                            return new EmailMessage(
                                email,
                                body,
                                message?.Attachments
                                    .OfType<MimePart>()
                                    .Select(mp => {
                                        memoryStream.SetLength(0L);
                                        using (var contentStream = mp.Content.Open())
                                        {
                                            contentStream.CopyTo(memoryStream);
                                        }
                                        return new FileAttachment(
                                            mp.FileName,
                                            memoryStream.ToArray());
                                    })
                                    .ToArray());
                        }
                    }
                    else
                    {
                        return (IEmailMessage)new EmailMessage(email);
                    }
                });
            }

            var retries = 0;
            while (true)
            {
                try
                {
                    return GetEmails();
                }
                catch when (retries < settings.Retries)
                {
                    //await Task.Delay(settings.RetryDelay, cancellationToken);
                    retries++;
                }
            }
        }

        public static string GetEmailFileName(IEmailMessage email)
        {
            string fileName;
            if (String.IsNullOrEmpty(email.Subject))
            {
                fileName = "(no name)";
            }
            else
            {
                var invalidChars = Path.GetInvalidFileNameChars();
                var chars = email.Subject.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    for (int j = 0; j < invalidChars.Length; j++)
                    {
                        if (chars[i] == invalidChars[j])
                        {
                            chars[i] = '_';
                        }
                    }
                }
                fileName = new String(chars);
            }
            return fileName + ".eml";
        }

        static ExchangeConnectionSettings GetConnectionSettings(string address) => 
            (from service in s_Config.Services.Cast<ExchangeServiceSettings>()
             let mailbox = service.Mailboxes.Cast<ExchangeMailboxSettings>().FirstOrDefault(m =>
                StringComparer.InvariantCultureIgnoreCase.Equals(m.Address, address))
             where service.Mailboxes.Count > 0 || mailbox != null
             select new ExchangeConnectionSettings(service, mailbox)).FirstOrDefault() ??
            throw Error.Failure($"An Exchange service has not been defined for mailbox '{address}'.");

        class ExchangeConnectionSettings
        {

            public ExchangeConnectionSettings(
                ExchangeServiceSettings service,
                ExchangeMailboxSettings mailbox = null)
            {
                this.Url = service.Url;
                this.Version = service.Version;
                var useMailboxCredentials = mailbox?.UseDefaultCredentials == true || !String.IsNullOrEmpty(mailbox?.UserName);
                this.UseDefaultCredentials = (useMailboxCredentials ? mailbox.UseDefaultCredentials : service.UseDefaultCredentials);
                this.UserName = (useMailboxCredentials ? mailbox.UserName : service.UserName);
                this.Password = (useMailboxCredentials ? mailbox.Password : service.Password);
                this.Domain = mailbox?.Domain ?? service.Domain;
                this.Retries = service.Retries;
                this.RetryDelay = service.RetryDelay;
            }

            public string Url { get; }
            public EWS.ExchangeVersion Version { get; }
            public bool UseDefaultCredentials { get; }
            public string UserName { get; }
            public string Password { get; }
            public string Domain { get; }
            public byte Retries { get; }
            public TimeSpan RetryDelay { get; }
        }

        class EmailAddress : IEmailAddress
        {

            readonly EWS.EmailAddress _address;

            public EmailAddress(EWS.EmailAddress address)
            {
                _address = address;
            }

            public string Name => _address.Name;
            public string Address => _address.Address;
        }

        class EmailMessage : IEmailMessage
        {

            readonly EWS.EmailMessage _email;
            readonly string _body;

            IEmailAttachment[] _attachments;

            public EmailMessage(
                EWS.EmailMessage email,
                string body = null,
                IEmailAttachment[] attachments = null)
            {
                _email = email;
                _body = body;
                _attachments = attachments;
            }

            public DateTime DateTimeReceived => _email.DateTimeReceived;
            public IEmailAddress Sender => new EmailAddress(_email.Sender);
            public IEmailAddress From => new EmailAddress(_email.From);
            public string Subject => _email.Subject;
            public string Body => _body ?? _email.Body.Text;
            public string HtmlBody =>
                _email.ExtendedProperties.FirstOrDefault(x =>
                    x.PropertyDefinition.Tag == ExtendedProperty_HtmlBody) is EWS.ExtendedProperty htmlBodyProperty ?
                    Encoding.ASCII.GetString((byte[])htmlBodyProperty.Value) : null;
            public bool HasAttachments => _email.HasAttachments;
            public byte[] ConversationId =>
                _email.ExtendedProperties.FirstOrDefault(x =>
                    x.PropertyDefinition.Tag == ExtendedProperty_ConversationId) is EWS.ExtendedProperty conversationIdProperty ?
                    (byte[])conversationIdProperty.Value : null;
            public IReadOnlyList<IEmailAddress> ToRecipients =>
                _email.ToRecipients.Select(address => new EmailAddress(address)).ToList().AsReadOnly();
            public IReadOnlyList<IEmailAddress> CcRecipients =>
                _email.CcRecipients.Select(address => new EmailAddress(address)).ToList().AsReadOnly();

            public IEnumerable<IEmailAttachment> GetAttachments()
            {
                if (_attachments is null)
                {
                    var attachments = new List<IEmailAttachment>(_email.Attachments.Count);
                    foreach (var attachment in _email.Attachments)
                    {
                        if (attachment is EWS.FileAttachment fileAttachment)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                fileAttachment.Load(memoryStream);
                                memoryStream.Position = 0L;
                                if (_email.ItemClass == "IPM.Note.SMIME.MultipartSigned")
                                {
                                    if (MimeEntity.Load(memoryStream) is MultipartSigned multipartSigned)
                                    {
                                        foreach (var signedAttachment in FindSignedAttachments(multipartSigned))
                                        {
                                            attachments.Add(signedAttachment);
                                        }
                                    }
                                }
                                else
                                {
                                    attachments.Add(
                                        new FileAttachment(
                                            fileAttachment.Name,
                                            memoryStream.ToArray()));
                                }
                            }
                        }
                        else if (attachment is EWS.ItemAttachment itemAttachment)
                        {
                            itemAttachment.Load(EWS.ItemSchema.MimeContent);
                            if (itemAttachment.Item is EWS.EmailMessage email)
                            {
                                attachments.Add(new MessageAttachment(email));
                            }
                        }
                    }
                    _attachments = attachments.ToArray();
                }
                return _attachments.AsEnumerable();
            }

            public Stream GetContentStream() => new MemoryStream(_email.MimeContent.Content);

            public void Delete() => _email.Delete(EWS.DeleteMode.MoveToDeletedItems);

            static IEnumerable<FileAttachment> FindSignedAttachments(Multipart multipart)
            {
                var stack = new Stack<Multipart>();
                stack.Push(multipart);
                using (var memoryStream = new MemoryStream())
                {
                    while (stack.Count > 0)
                    {
                        multipart = stack.Pop();
                        foreach (var mimeEntity in multipart)
                        {
                            if (mimeEntity is MimePart mimePart &&
                                mimePart.IsAttachment &&
                                !(mimePart is ApplicationPkcs7Signature))
                            {
                                memoryStream.SetLength(0L);
                                mimePart.Content.DecodeTo(memoryStream);
                                yield return new FileAttachment(
                                    mimePart.FileName,
                                    memoryStream.ToArray());
                            }
                            else if (mimeEntity is Multipart subPart)
                            {
                                stack.Push(subPart);
                            }
                        }
                    }
                }
            }
        }

        class FileAttachment : IFileAttachment
        {

            readonly byte[] _content;

            public FileAttachment(
                string fileName,
                byte[] content)
            {
                this.FileName = fileName;
                _content = content;
            }

            public string FileName { get; }

            public Stream GetContentStream() => new MemoryStream(_content);
        }

        class MessageAttachment : IMessageAttachment
        {

            readonly IEmailMessage _message;

            public MessageAttachment(EWS.EmailMessage email)
            {
                _message = new EmailMessage(email);
                this.FileName = GetEmailFileName(_message);
            }

            public IEmailMessage GetMessage() => _message;

            public string FileName { get; }

            public Stream GetContentStream() => _message.GetContentStream();
        }
    }
}
