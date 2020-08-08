using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class UniqueIdentifier
    {
        private bool isNullField;
        private bool isNullFieldSpecified;
        private Guid valueField;

        public UniqueIdentifier()
        {
        }

        public UniqueIdentifier(Guid value)
        {
            this.Value = value;
        }

        public static UniqueIdentifier Null
        {
            get
            {
                return new UniqueIdentifier()
                       {
                           IsNull = true,
                           IsNullSpecified = true
                       };
            }
        }

        public override bool Equals(object obj)
        {
            return obj is UniqueIdentifier uniqueIdentifier && this.IsNull == uniqueIdentifier.IsNull && this.IsNullSpecified == uniqueIdentifier.IsNullSpecified && this.Value.Equals(uniqueIdentifier.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        [XmlAttribute]
        public bool IsNull
        {
            get
            {
                return this.isNullField;
            }
            set
            {
                this.isNullField = value;
            }
        }

        [XmlIgnore]
        public bool IsNullSpecified
        {
            get
            {
                return this.isNullFieldSpecified;
            }
            set
            {
                this.isNullFieldSpecified = value;
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