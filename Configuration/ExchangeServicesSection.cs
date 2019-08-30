using System.Configuration;

namespace AGS.Configuration {

    public sealed class ExchangeServicesSection : ConfigurationSection {

        static readonly ConfigurationProperty s_Services = new ConfigurationProperty(
            "", typeof(ExchangeServiceSettingsCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

        static readonly ConfigurationPropertyCollection s_Properties;

        static ExchangeServicesSection() {
            s_Properties = new ConfigurationPropertyCollection {
                s_Services
            };
        }

        protected override ConfigurationPropertyCollection Properties => s_Properties;

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public ExchangeServiceSettingsCollection Services => (ExchangeServiceSettingsCollection)this[s_Services];
    }
}
