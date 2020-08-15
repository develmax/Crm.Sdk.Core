using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal sealed class Query<T> : IOrderedQueryable<T>, IQueryable<T>, IEnumerable<T>, IOrderedQueryable, IQueryable, IEnumerable, IEntityQuery
  {
    public string EntityLogicalName { get; private set; }

    public Query(IQueryProvider provider, string entityLogicalName)
    {
      if (provider == null)
        throw new ArgumentNullException(nameof (provider));
      if (string.IsNullOrWhiteSpace(entityLogicalName))
        throw new ArgumentNullException(nameof (entityLogicalName));
      this.Provider = provider;
      this.EntityLogicalName = entityLogicalName;
      this.Expression = (Expression) Expression.Constant((object) this);
    }

    public Query(IQueryProvider provider, Expression expression)
    {
      if (provider == null)
        throw new ArgumentNullException(nameof (provider));
      if (expression == null)
        throw new ArgumentNullException(nameof (expression));
      this.Provider = provider;
      this.Expression = expression;
    }

    public IEnumerator<T> GetEnumerator()
    {
      if (this.Provider is QueryProvider provider)
        return provider.GetEnumerator<T>(this.Expression);
      throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The provider '{0}' is not of the expected type '{1}'.", (object) this.Provider, (object) typeof (QueryProvider)));
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.", Target = "CS$1$0000")]
    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }

    public Type ElementType
    {
      get
      {
        return typeof (T);
      }
    }

    public IQueryProvider Provider { get; private set; }

    public Expression Expression { get; private set; }
  }
}
