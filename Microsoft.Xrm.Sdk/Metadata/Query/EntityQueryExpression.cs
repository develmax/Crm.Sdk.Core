using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    /// <summary>Defines a complex query to retrieve entity metadata.</summary>
    [DataContract(Name = "EntityQueryExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
    public sealed class EntityQueryExpression : MetadataQueryExpression
    {
        /// <summary>Gets or sets a query expression for the labels to return.</summary>
        /// <returns>Type:<see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.LabelQueryExpression"></see>.</returns>
        [DataMember]
        public LabelQueryExpression LabelQuery { get; set; }

        /// <summary>Gets or sets a query expression for the entity attribute metadata to return.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.AttributeQueryExpression"></see>.</returns>
        [DataMember]
        public AttributeQueryExpression AttributeQuery { get; set; }

        /// <summary>Gets or sets a query expression for the entity relationship metadata to return.</summary>
        /// <returns>Type:<see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.RelationshipQueryExpression"></see>.</returns>
        [DataMember]
        public RelationshipQueryExpression RelationshipQuery { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal override void Accept(IMetadataQueryExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}