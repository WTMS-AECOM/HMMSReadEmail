using System;
using System.Configuration;

namespace AGS.Configuration {

    [ConfigurationCollection(typeof(ExchangeServiceSettings))]
    public sealed class ExchangeServiceSettingsCollection : ConfigurationElementCollection {

        public ExchangeServiceSettingsCollection() :
            base(StringComparer.InvariantCultureIgnoreCase) { }

        public ExchangeServiceSettings this[int index] => (ExchangeServiceSettings)base.BaseGet(index);

        public new ExchangeServiceSettings this[string url] => (ExchangeServiceSettings)base.BaseGet(url);

        protected override ConfigurationElement CreateNewElement() => new ExchangeServiceSettings();

        protected override object GetElementKey(ConfigurationElement element) => ((ExchangeServiceSettings)element).Url;
    }
}
