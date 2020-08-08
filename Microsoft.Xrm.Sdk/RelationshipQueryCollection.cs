using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Provides a collection of relationship queries.</summary>
    [CollectionDataContract(Name = "RelationshipQueryCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class RelationshipQueryCollection : DataCollection<Relationship, QueryBase>
    {
    }
}