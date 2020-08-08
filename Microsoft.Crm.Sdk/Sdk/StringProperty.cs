using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class StringProperty : Property
    {
        private string valueField;

        public string Value
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
            this.Value = (string)value;
        }

        public StringProperty()
        {
        }

        public StringProperty(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}