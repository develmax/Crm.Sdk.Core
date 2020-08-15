using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal abstract class PagedItemCollectionBase
  {
    private QueryExpression query;
    private bool moreRecords;
    private string pagingCookie;

    public PagedItemCollectionBase(QueryExpression query, string pagingCookie, bool moreRecords)
    {
      this.query = query;
      this.pagingCookie = pagingCookie;
      this.moreRecords = moreRecords;
    }

    public QueryExpression Query
    {
      get
      {
        return this.query;
      }
    }

    public bool MoreRecords
    {
      get
      {
        return this.moreRecords;
      }
    }

    public string PagingCookie
    {
      get
      {
        return this.pagingCookie;
      }
    }
  }
}
