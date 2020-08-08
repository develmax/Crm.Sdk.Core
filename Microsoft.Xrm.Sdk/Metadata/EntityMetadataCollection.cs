using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Defines a collection of <see cref="T:Microsoft.Xrm.Sdk.Metadata.EntityMetadata"></see></summary>
    [CollectionDataContract(Name = "EntityMetadataCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class EntityMetadataCollection : DataCollection<EntityMetadata>
    {
    }
}