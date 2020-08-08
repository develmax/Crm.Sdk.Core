using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    /// <summary>Defines a complex query to retrieve attribute metadata for entities retrieved using an <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.EntityQueryExpression"></see></summary>
    [DataContract(Name = "AttributeQueryExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
    public sealed class AttributeQueryExpression : MetadataQueryExpression
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal override void Accept(IMetadataQueryExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}