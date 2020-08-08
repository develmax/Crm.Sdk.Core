using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    [CollectionDataContract(Name = "AttributeMappingCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [KnownType(typeof(AttributeMapping))]
    [Serializable]
    public sealed class AttributeMappingCollection : DataCollection<AttributeMapping>
    {
        public AttributeMappingCollection()
        {
        }

        public AttributeMappingCollection(IList<AttributeMapping> list)
            : base(list)
        {
        }
    }
}