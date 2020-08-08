using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Specifies a collection of field level security privileges allowed for the specified attributes.</summary>
    [CollectionDataContract(Name = "AttributePrivilegeCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [KnownType(typeof(AttributePrivilege))]
    [Serializable]
    public sealed class AttributePrivilegeCollection : DataCollection<AttributePrivilege>
    {
        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.AttributePrivilegeCollection"></see> class.</summary>
        public AttributePrivilegeCollection()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.AttributePrivilegeCollection"></see> class, setting the list property.</summary>
        /// <param name="list">Type: Returns_IList&lt;<see cref="T:Microsoft.Xrm.Sdk.AttributePrivilege"></see>&gt;. The list of attribute privileges.</param>
        public AttributePrivilegeCollection(IList<AttributePrivilege> list)
            : base(list)
        {
        }
    }
}