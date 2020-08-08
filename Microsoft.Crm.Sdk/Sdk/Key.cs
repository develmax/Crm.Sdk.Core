using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class Key
    {
        private Guid valueField;

        public Key()
        {
        }

        public Key(Guid value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Key key && this.Value.Equals(key.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static Key Null
        {
            get
            {
                return new Key(Guid.Empty);
            }
        }

        [XmlText]
        public Guid Value
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
    }
}