using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class StatusProperty : Property
    {
        private Status valueField;

        public Status Value
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
            this.Value = (Status)value;
        }

        public StatusProperty()
        {
        }

        public StatusProperty(string name, Status value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}