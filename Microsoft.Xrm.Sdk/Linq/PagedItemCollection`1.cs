using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal sealed class PagedItemCollection<TSource> : PagedItemCollectionBase, IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IEnumerator, IDisposable
  {
    private TSource current;
    private IEnumerator<TSource> enumerator;
    private IEnumerable<TSource> source;

    public PagedItemCollection(
      IEnumerable<TSource> source,
      QueryExpression query,
      string pagingCookie,
      bool moreRecords)
      : base(query, pagingCookie, moreRecords)
    {
      this.source = source;
    }

    public PagedItemCollection<TSource> Clone()
    {
      return new PagedItemCollection<TSource>(this.source, this.Query, this.PagingCookie, this.MoreRecords);
    }

    public IEnumerator<TSource> GetEnumerator()
    {
      return (IEnumerator<TSource>) this.Clone();
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "The enumerator will be disposed by the calling method.")]
    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }

    public TSource Current
    {
      get
      {
        return this.current;
      }
    }

    public void Dispose()
    {
      if (this.enumerator != null)
        this.enumerator.Dispose();
      this.enumerator = (IEnumerator<TSource>) null;
      this.current = default (TSource);
    }

    object IEnumerator.Current
    {
      get
      {
        return (object) this.Current;
      }
    }

    public bool MoveNext()
    {
      if (this.enumerator == null)
        this.enumerator = this.source.GetEnumerator();
      if (!this.enumerator.MoveNext())
        return false;
      this.current = this.enumerator.Current;
      return true;
    }

    public void Reset()
    {
      throw new NotImplementedException();
    }
  }
}
