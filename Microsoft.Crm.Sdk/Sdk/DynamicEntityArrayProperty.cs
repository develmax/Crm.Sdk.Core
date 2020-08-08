using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class DynamicEntityArrayProperty : Property
    {
        private DynamicEntity[] valueField;

        [XmlArrayItem(IsNullable = false)]
        public DynamicEntity[] Value
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
            this.Value = (DynamicEntity[])value;
        }

        public DynamicEntityArrayProperty()
        {
        }

        public DynamicEntityArrayProperty(string name, DynamicEntity[] value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}