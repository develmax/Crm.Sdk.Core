using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class CrmDecimalProperty : Property
    {
        private CrmDecimal valueField;

        public CrmDecimal Value
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
            this.Value = (CrmDecimal)value;
        }

        public CrmDecimalProperty()
        {
        }

        public CrmDecimalProperty(string name, CrmDecimal value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}