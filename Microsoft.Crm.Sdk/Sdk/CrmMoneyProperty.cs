using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class CrmMoneyProperty : Property
    {
        private CrmMoney valueField;

        public CrmMoney Value
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
            this.Value = (CrmMoney)value;
        }

        public CrmMoneyProperty()
        {
        }

        public CrmMoneyProperty(string name, CrmMoney value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}