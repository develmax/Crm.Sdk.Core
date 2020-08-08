using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class CrmDateTimeProperty : Property
    {
        private CrmDateTime valueField;

        public CrmDateTime Value
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
            this.Value = (CrmDateTime)value;
        }

        public CrmDateTimeProperty()
        {
        }

        public CrmDateTimeProperty(string name, CrmDateTime value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}