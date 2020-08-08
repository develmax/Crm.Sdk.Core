using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class Owner : CrmReference
    {
        public Owner()
        {
        }

        public Owner(string type, Guid value)
        {
            this.type = type;
            this.Value = value;
        }

        public static Owner Null
        {
            get
            {
                Owner owner = new Owner();
                owner.IsNull = true;
                owner.IsNullSpecified = true;
                return owner;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Owner owner && this.IsNull == owner.IsNull && this.IsNullSpecified == owner.IsNullSpecified && this.Value.Equals(owner.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}