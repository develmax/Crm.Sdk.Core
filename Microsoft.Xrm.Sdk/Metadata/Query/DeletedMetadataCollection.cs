using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    /// <summary>The structure used to return deleted metadata.</summary>
    [CollectionDataContract(Name = "DeletedMetadataCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
    public sealed class DeletedMetadataCollection : DataCollection<DeletedMetadataFilters, DataCollection<Guid>>
    {
    }
}