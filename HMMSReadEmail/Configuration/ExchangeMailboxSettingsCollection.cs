using System;
using System.Configuration;

namespace HMMSReadEmail.Configuration
{

    public sealed class ExchangeMailboxSettingsCollection : ConfigurationElementCollection {

        public ExchangeMailboxSettingsCollection() :
            base(StringComparer.InvariantCultureIgnoreCase) { }

        public ExchangeMailboxSettings this[int index] => (ExchangeMailboxSettings)base.BaseGet(index);

        public new ExchangeMailboxSettings this[string mailbox] => (ExchangeMailboxSettings)base.BaseGet(mailbox);

        protected override ConfigurationElement CreateNewElement() => new ExchangeMailboxSettings();

        protected override object GetElementKey(ConfigurationElement element) =>
            ((ExchangeMailboxSettings)element).Address;
    }
}
