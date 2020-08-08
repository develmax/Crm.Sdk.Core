using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains a collection of related entities.</summary>
    [CollectionDataContract(Name = "RelatedEntityCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class RelatedEntityCollection : DataCollection<Relationship, EntityCollection>
    {
        /// <summary>Gets a value indicating whether the <see cref="T:Microsoft.Xrm.Sdk.RelatedEntityCollection"></see> is read-only.</summary>
        /// <returns>Type: Returns_Booleantrue if the <see cref="T:Microsoft.Xrm.Sdk.RelatedEntityCollection"></see> is read-only; otherwise, false.</returns>
        public override bool IsReadOnly
        {
            get
            {
                return base.IsReadOnly;
            }
            internal set
            {
                base.IsReadOnly = value;
                foreach (KeyValuePair<Relationship, EntityCollection> keyValuePair in (DataCollection<Relationship, EntityCollection>)this)
                {
                    if (keyValuePair.Value != null)
                        keyValuePair.Value.IsReadOnly = true;
                }
            }
        }
    }
}