using System.ComponentModel;

namespace Microsoft.Xrm.Sdk.Query
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IQueryVisitor
    {
        void Visit(QueryExpression query);

        void Visit(QueryByAttribute query);

        void Visit(FetchExpression query);

        void Visit(ColumnSet columnSet);

        void Visit(PagingInfo pageInfo);

        void Visit(OrderExpression order);

        void Visit(LinkEntity linkEntity);

        void Visit(FilterExpression filter);

        void Visit(ConditionExpression condition);
    }
}