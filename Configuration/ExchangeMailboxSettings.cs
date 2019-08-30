using System;
using System.Configuration;

namespace AGS.Configuration {

    public sealed class ExchangeMailboxSettings : ConfigurationElement {

        static readonly ConfigurationProperty s_Address = new ConfigurationProperty(
            "address", typeof(string), String.Empty, ConfigurationPropertyOptions.IsKey | ConfigurationPropertyOptions.IsRequired);
        static readonly ConfigurationProperty s_UseDefaultCredentials = new ConfigurationProperty(
            "useDefaultCredentials", typeof(bool));
        static readonly ConfigurationProperty s_UserName = new ConfigurationProperty(
            "userName", typeof(string));
        static readonly ConfigurationProperty s_Password = new ConfigurationProperty(
            "password", typeof(string));
        static readonly ConfigurationProperty s_Domain = new ConfigurationProperty(
            "domain", typeof(string));
        static readonly ConfigurationPropertyCollection s_Properties;

        static ExchangeMailboxSettings() {
            s_Properties = new ConfigurationPropertyCollection {
                s_Address,
                s_UseDefaultCredentials,
                s_UserName,
                s_Password,
                s_Domain
            };
        }

        protected override ConfigurationPropertyCollection Properties => s_Properties;

        [ConfigurationProperty("address", Options = ConfigurationPropertyOptions.IsKey | ConfigurationPropertyOptions.IsRequired)]
        public string Address {
            get => (string)this[s_Address];
            set => this[s_Address] = value;
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
    }
}
