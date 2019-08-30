using System;
using System.Collections.Specialized;
using System.Configuration;
using EWS = Microsoft.Exchange.WebServices.Data;

namespace HMMSReadEmail.Configuration {

    public sealed class ExchangeServiceSettings : ConfigurationElement {

        static readonly ConfigurationProperty s_Url = new ConfigurationProperty(
            "url", typeof(string), null, ConfigurationPropertyOptions.IsKey | ConfigurationPropertyOptions.IsRequired);
        static readonly ConfigurationProperty s_Version = new ConfigurationProperty(
            "version", typeof(EWS.ExchangeVersion), default, ConfigurationPropertyOptions.IsRequired);
        static readonly ConfigurationProperty s_UseDefaultCredentials = new ConfigurationProperty(
            "useDefaultCredentials", typeof(bool));
        static readonly ConfigurationProperty s_UserName = new ConfigurationProperty(
            "userName", typeof(string));
        static readonly ConfigurationProperty s_Password = new ConfigurationProperty(
            "password", typeof(string));
        static readonly ConfigurationProperty s_Domain = new ConfigurationProperty(
            "domain", typeof(string));
        static readonly ConfigurationProperty s_Mailboxes = new ConfigurationProperty(
            "mailboxes", typeof(ExchangeMailboxSettingsCollection));
        static readonly ConfigurationProperty s_Retries = new ConfigurationProperty(
            "retries", typeof(byte));
        static readonly ConfigurationProperty s_RetryDelay = new ConfigurationProperty(
            "retryDelay", typeof(TimeSpan));
        static readonly ConfigurationPropertyCollection s_Properties;

        static ExchangeServiceSettings() {
            s_Properties = new ConfigurationPropertyCollection {
                s_Url,
                s_Version,
                s_UseDefaultCredentials,
                s_UserName,
                s_Password,
                s_Domain,
                s_Mailboxes,
                s_Retries,
                s_RetryDelay
            };
        }

        protected override ConfigurationPropertyCollection Properties => s_Properties;

        [ConfigurationProperty("url", Options = ConfigurationPropertyOptions.IsKey | ConfigurationPropertyOptions.IsRequired)]
        public string Url {
            get => (string)this[s_Url];
            set => this[s_Url] = value;
        }

        [ConfigurationProperty("version", IsRequired = true)]
        public EWS.ExchangeVersion Version {
            get => (EWS.ExchangeVersion)this[s_Version];
            set => this[s_Version] = value;
        }

        [ConfigurationProperty("useDefaultCredentials")]
        public bool UseDefaultCredentials {
            get => (bool)this[s_UseDefaultCredentials];
            set => this[s_UseDefaultCredentials] = value;
        }

        [ConfigurationProperty("userName")]
        public string UserName {
            get => (string)this[s_UserName];
            set => this[s_UserName] = value;
        }

        [ConfigurationProperty("password")]
        public string Password {
            get => (string)this[s_Password];
            set => this[s_Password] = value;
        }

        [ConfigurationProperty("domain")]
        public string Domain {
            get => (string)this[s_Domain];
            set => this[s_Domain] = value;
        }

        [ConfigurationProperty("mailboxes")]
        public ExchangeMailboxSettingsCollection Mailboxes =>
            (ExchangeMailboxSettingsCollection)this[s_Mailboxes];

        [ConfigurationProperty("retries")]
        public byte Retries {
            get => (byte)this[s_Retries];
            set => this[s_Retries] = value;
        }

        [ConfigurationProperty("retryDelay")]
        public TimeSpan RetryDelay {
            get => (TimeSpan)this[s_RetryDelay];
            set => this[s_RetryDelay] = value;
        }
        public static ExchangeServiceSettings GetConfig()
        {
            var ExchangeServiceSettings = ConfigurationManager.GetSection("ExchangeServiceSettings") as NameValueCollection;

            ExchangeServiceSettings _config = new ExchangeServiceSettings();

            if (ExchangeServiceSettings != null)
            {
                _config.Url = ExchangeServiceSettings["URL"].ToString();
                _config.Version = (EWS.ExchangeVersion)Convert.ToInt32(ExchangeServiceSettings["Version"]);
                _config.UserName = ExchangeServiceSettings["UserName"].ToString();
                _config.Password = ExchangeServiceSettings["Password"].ToString();
                _config.Domain = ExchangeServiceSettings["Domain"].ToString();
                _config.Retries = Convert.ToByte(ExchangeServiceSettings["Retries"]);
                _config.RetryDelay = TimeSpan.FromSeconds(Convert.ToInt32(ExchangeServiceSettings["RetryDelay"]));
            }
            return _config;
        }
    }
}
