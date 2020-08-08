using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class Lookup : CrmReference
    {
        public Lookup()
        {
        }

        public Lookup(string type, Guid value)
        {
            this.type = type;
            this.Value = value;
        }

        public static Lookup Null
        {
            get
            {
                Lookup lookup = new Lookup();
                lookup.IsNull = true;
                lookup.IsNullSpecified = true;
                return lookup;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Lookup lookup && this.IsNull == lookup.IsNull && this.IsNullSpecified == lookup.IsNullSpecified && this.Value.Equals(lookup.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}