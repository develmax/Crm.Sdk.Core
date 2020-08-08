using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class CrmFloatProperty : Property
    {
        private CrmFloat valueField;

        public CrmFloat Value
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
            this.Value = (CrmFloat)value;
        }

        public CrmFloatProperty()
        {
        }

        public CrmFloatProperty(string name, CrmFloat value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}