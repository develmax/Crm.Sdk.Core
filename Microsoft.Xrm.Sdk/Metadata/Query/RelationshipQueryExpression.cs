using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    /// <summary>Defines a complex query to retrieve entity relationship metadata for entities retrieved using an <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.EntityQueryExpression"></see></summary>
    [DataContract(Name = "RelationshipQueryExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
    public sealed class RelationshipQueryExpression : MetadataQueryExpression
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal override void Accept(IMetadataQueryExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}