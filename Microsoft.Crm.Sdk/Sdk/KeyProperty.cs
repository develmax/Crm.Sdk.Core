using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class KeyProperty : Property
    {
        private Key valueField;

        public Key Value
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
            this.Value = (Key)value;
        }

        public KeyProperty()
        {
        }

        public KeyProperty(string name, Key value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}