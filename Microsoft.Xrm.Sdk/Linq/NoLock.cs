using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Microsoft.Xrm.Sdk.Linq
{
	public static class QueryableNoLock
	{
		private static readonly Dictionary<Type, MethodInfo> _methodsMap = new Dictionary<Type, MethodInfo>();
		private static readonly MethodInfo _noLock = typeof(QueryableNoLock).GetMethod(nameof(QueryableNoLock.NoLock));

		private static MethodInfo GetMethod(Type type)
		{
			if (!_methodsMap.TryGetValue(type, out var value))
			{
				lock (_noLock)
				{
					if (!_methodsMap.TryGetValue(type, out value))
					{
						value = _noLock.MakeGenericMethod(type);

						_methodsMap.Add(type, value);
					}
				}
			}

			return value;
		}

		public static IQueryable<TSource> NoLock<TSource>(this IQueryable<TSource> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var genericMethod = GetMethod(typeof(TSource));

			var expression = Expression.Call(null, genericMethod, source.Expression);

			return source.Provider.CreateQuery<TSource>(expression);
		}
	}
}
