using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class EntityNameReference
    {
        private bool isNullField;
        private bool isNullFieldSpecified;
        private string valueField;

        public EntityNameReference()
        {
        }

        public EntityNameReference(string value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is EntityNameReference entityNameReference && this.IsNull == entityNameReference.IsNull && this.IsNullSpecified == entityNameReference.IsNullSpecified && this.Value.Equals(entityNameReference.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static EntityNameReference Null
        {
            get
            {
                return new EntityNameReference()
                       {
                           IsNull = true,
                           IsNullSpecified = true
                       };
            }
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
        public string Value
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