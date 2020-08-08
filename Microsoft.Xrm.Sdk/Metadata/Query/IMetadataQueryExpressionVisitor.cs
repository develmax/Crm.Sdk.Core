using System.ComponentModel;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IMetadataQueryExpressionVisitor
    {
        void Visit(EntityQueryExpression query);

        void Visit(AttributeQueryExpression query);

        void Visit(RelationshipQueryExpression query);

        void Visit(LabelQueryExpression query);
    }
}