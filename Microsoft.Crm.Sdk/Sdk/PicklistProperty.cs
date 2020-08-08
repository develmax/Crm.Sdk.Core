using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class PicklistProperty : Property
    {
        private Picklist valueField;

        public Picklist Value
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
            this.Value = (Picklist)value;
        }

        public PicklistProperty()
        {
        }

        public PicklistProperty(string name, Picklist value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}