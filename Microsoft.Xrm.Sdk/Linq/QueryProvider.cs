using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Xrm.Sdk.Client;

namespace Microsoft.Xrm.Sdk.Linq
{
	internal sealed partial class QueryProvider : IQueryProvider
	{
		public QueryProvider(OrganizationServiceContext context)
		{
			OrganizationServiceContext = context;
		}

		private OrganizationServiceContext OrganizationServiceContext { get; }

		IQueryable IQueryProvider.CreateQuery(Expression expression)
		{
			ClientExceptionHelper.ThrowIfNull(expression, nameof(expression));
			return CreateQuery(expression);
		}

		IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(Expression expression)
		{
			ClientExceptionHelper.ThrowIfNull(expression, nameof(expression));
			return CreateQuery<TElement>(expression);
		}

		TResult IQueryProvider.Execute<TResult>(Expression expression)
		{
			ClientExceptionHelper.ThrowIfNull(expression, nameof(expression));
			return Execute<TResult>(expression).FirstOrDefault();
		}

		object IQueryProvider.Execute(Expression expression)
		{
			ClientExceptionHelper.ThrowIfNull(expression, nameof(expression));
			return Execute<object>(expression).FirstOrDefault();
		}
		private IQueryable CreateQuery(Expression expression)
		{
			return CreateQueryInstance(expression.Type.GetGenericArguments()[0], new object[] {this, expression});
		}

		private IQueryable CreateQuery(Type entityType)
		{
			CheckEntitySubclass(entityType);
			var nameForType = KnownProxyTypesProvider.GetInstance(true).GetNameForType(entityType);
			return CreateQueryInstance(entityType, new object[] {this, nameForType});
		}

		private IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			return new Query<TElement>(this, expression);
		}

		public IEnumerator<TElement> GetEnumerator<TElement>(Expression expression)
		{
			return Execute<TElement>(expression).GetEnumerator();
		}

		private IQueryable CreateQueryInstance(Type elementType, object[] args)
		{
			try
			{
				return Activator.CreateInstance(typeof(Query<>).MakeGenericType(elementType), args) as IQueryable;
			}
			catch (TargetInvocationException ex)
			{
				if (ex.InnerException != null)
				{
					throw ex.InnerException;
				}

				throw;
			}
		}

		private void CheckEntitySubclass(Type entityType)
		{
			if (!entityType.IsSubclassOf(typeof(Entity)))
			{
				throw new ArgumentException($"The specified type '{entityType}' must be a subclass of '{typeof(Entity)}'.");
			}

			if (!string.IsNullOrWhiteSpace(KnownProxyTypesProvider.GetInstance(true).GetNameForType(entityType)))
			{
				return;
			}

			throw new ArgumentException($"The specified type '{entityType}' is not a known entity type.");
		}
	}
}
