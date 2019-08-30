using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AGS {

    public interface IEmailHandler {

        Task ProcessEmails(
            IEmailMatch[] emails,
            TextWriter output,
            CancellationToken cancellationToken,
            ParameterDictionary<string> parameters);
    }

    public interface IEmailAddress {

        string Address { get; }
        string Name { get; }
    }

    public interface IEmailMessage {

        DateTime DateTimeReceived { get; }
        IEmailAddress Sender { get; }
        IEmailAddress From { get; }
        string Subject { get; }
        string Body { get; }
        string HtmlBody { get; }
        bool HasAttachments { get; }
        byte[] ConversationId { get; }
        IReadOnlyList<IEmailAddress> ToRecipients { get; }
        IReadOnlyList<IEmailAddress> CcRecipients { get; }
        IEnumerable<IEmailAttachment> GetAttachments();
        Stream GetContentStream();
        void Delete();
    }

    public interface IEmailAttachment {

        string FileName { get; }
        Stream GetContentStream();
    }

    public interface IFileAttachment : IEmailAttachment {
    }

    public interface IMessageAttachment : IEmailAttachment {

        IEmailMessage GetMessage();
    }

    public interface IEmailMatch {

        IEmailMessage Message { get; }
        IFileAttachment[] Attachments { get; }
    }
}
