using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail.ConfigTest
{
    public class ConnectionManagerDataSection : ConfigurationSection
    {
        /// <summary>
        /// The name of this section in the app.config.
        /// </summary>
        public const string SectionName = "ConnectionManagerDataSection";

        private const string EndpointCollectionName = "ConnectionManagerEndpoints";

        [ConfigurationProperty(EndpointCollectionName)]
        [ConfigurationCollection(typeof(ConnectionManagerEndpointsCollection), AddItemName = "add")]
        public ConnectionManagerEndpointsCollection ConnectionManagerEndpoints { get { return (ConnectionManagerEndpointsCollection)base[EndpointCollectionName]; } }
    }

    public class ConnectionManagerEndpointsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionManagerEndpointElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConnectionManagerEndpointElement)element).Name;
        }
    }

    public class ConnectionManagerEndpointElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("address", IsRequired = true)]
        public string Address
        {
            get { return (string)this["address"]; }
            set { this["address"] = value; }
        }

        [ConfigurationProperty("useSSL", IsRequired = false, DefaultValue = false)]
        public bool UseSSL
        {
            get { return (bool)this["useSSL"]; }
            set { this["useSSL"] = value; }
        }

        [ConfigurationProperty("securityGroupsAllowedToSaveChanges", IsRequired = false)]
        public string SecurityGroupsAllowedToSaveChanges
        {
            get { return (string)this["securityGroupsAllowedToSaveChanges"]; }
            set { this["securityGroupsAllowedToSaveChanges"] = value; }
        }
    }
}
