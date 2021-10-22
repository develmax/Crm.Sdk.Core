using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.Xrm.Sdk.Linq
{
	internal sealed class Query<T> : IOrderedQueryable<T>, IEntityQuery
	{
		public string EntityLogicalName { get; }

		public Query(IQueryProvider provider, string entityLogicalName)
		{
			if (string.IsNullOrWhiteSpace(entityLogicalName))
			{
				throw new ArgumentNullException(nameof(entityLogicalName));
			}

			Provider = provider ?? throw new ArgumentNullException(nameof(provider));
			EntityLogicalName = entityLogicalName;
			Expression = Expression.Constant(this);
		}

		public Query(IQueryProvider provider, Expression expression)
		{
			Provider = provider ?? throw new ArgumentNullException(nameof(provider));
			Expression = expression ?? throw new ArgumentNullException(nameof(expression));
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (Provider is QueryProvider provider)
			{
				return provider.GetEnumerator<T>(Expression);
			}

			throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The provider '{0}' is not of the expected type '{1}'.", Provider, typeof(QueryProvider)));
		}

		[SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.", Target = "CS$1$0000")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public Type ElementType => typeof(T);

		public IQueryProvider Provider { get; }

		public Expression Expression { get; }
	}
}
