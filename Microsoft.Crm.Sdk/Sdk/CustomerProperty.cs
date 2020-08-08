using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class CustomerProperty : Property
    {
        private Customer valueField;

        public Customer Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        internal override object GetValue()
        {
            return (object)this.Value;
        }

        internal override void SetValue(object value)
        {
            this.Value = (Customer)value;
        }

        public CustomerProperty()
        {
        }

        public CustomerProperty(string name, Customer value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}