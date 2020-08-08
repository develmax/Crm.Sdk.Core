using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains a collection of entity references.</summary>
    [CollectionDataContract(Name = "EntityReferenceCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class EntityReferenceCollection : DataCollection<EntityReference>
    {
        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see> class.</summary>
        public EntityReferenceCollection()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see> class setting the list of entity references.</summary>
        /// <param name="list">Type: Returns_IList&lt;<see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>&gt;. A list of entity references.</param>
        public EntityReferenceCollection(IList<EntityReference> list)
            : base(list)
        {
        }
    }
}