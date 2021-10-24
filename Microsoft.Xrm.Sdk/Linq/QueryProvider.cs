using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Xrm.Sdk.Linq
{
	internal sealed class QueryProvider : IQueryProvider
	{
		private static readonly string[] _followingRoot = new string[1];
		private static readonly IEnumerable<string> _followingFirst = _followingRoot.Concat(new[] {nameof(Enumerable.ToList) });
		private static readonly IEnumerable<string> _followingTake = _followingFirst.Concat(new[]
		{
			nameof(Queryable.Select),
			nameof(Queryable.First),
			nameof(Queryable.FirstOrDefault),
			nameof(Queryable.Single),
			nameof(Queryable.SingleOrDefault),
			nameof(Queryable.Distinct)
		});
		private static readonly IEnumerable<string> _followingSkip = _followingTake.Concat(new[]
		{
			nameof(Queryable.Take)
		});
		private static readonly IEnumerable<string> _followingSelect = _followingSkip.Concat(new[]
		{
			nameof(Queryable.Skip)
		});
		private static readonly IEnumerable<string> _followingOrderBy = _followingSelect.Concat(new[]
		{
			nameof(Queryable.Select),
			nameof(Queryable.Where),
			nameof(Queryable.OrderBy),
			nameof(Queryable.OrderByDescending),
			nameof(Queryable.ThenBy),
			nameof(Queryable.ThenByDescending)
		});
		private static readonly IEnumerable<string> _followingWhere = _followingOrderBy.Concat(new[]
		{
			nameof(Queryable.SelectMany)
		});
		private static readonly IEnumerable<string> _followingJoin = _followingWhere.Concat(new[]
		{
			nameof(Queryable.Join)
		});
		private static readonly IEnumerable<string> _followingGroupJoin = _followingRoot.Concat(new[]
		{
			nameof(Queryable.SelectMany)
		});
		private static readonly Dictionary<string, HashSet<string>> _followingMethodLookup = new Dictionary<string, HashSet<string>>
		{
			{nameof(Queryable.Join), _followingJoin.ToHashSet()},
			{nameof(Queryable.GroupJoin), _followingGroupJoin.ToHashSet()},
			{nameof(Queryable.Where), _followingWhere.ToHashSet()},
			{nameof(Queryable.OrderBy), _followingOrderBy.ToHashSet()},
			{nameof(Queryable.OrderByDescending), _followingOrderBy.ToHashSet()},
			{nameof(Queryable.ThenBy), _followingOrderBy.ToHashSet()},
			{nameof(Queryable.ThenByDescending), _followingOrderBy.ToHashSet()},
			{nameof(Queryable.Select), _followingSelect.ToHashSet()},
			{nameof(Queryable.Skip), _followingSkip.ToHashSet()},
			{nameof(Queryable.Take), _followingTake.ToHashSet()},
			{nameof(Queryable.First), _followingFirst.ToHashSet()},
			{nameof(Queryable.FirstOrDefault), _followingFirst.ToHashSet()},
			{nameof(Queryable.Single), _followingFirst.ToHashSet()},
			{nameof(Queryable.SingleOrDefault), _followingFirst.ToHashSet()},
			{nameof(Queryable.SelectMany), _followingOrderBy.ToHashSet()},
			{nameof(Queryable.Distinct), _followingSkip.ToHashSet()},
			{nameof(Queryable.Cast), new[] {"Select"}.ToHashSet()}
		};
		private static readonly string[] _supportedMethods = 
		{
			"Equals",
			"Contains",
			"StartsWith",
			"EndsWith"
		};
		private static readonly HashSet<string> _validMethods = _supportedMethods.Concat(new[]
		{
			"Compare",
			"Like",
			"GetValueOrDefault"
		}).ToHashSet();
		private static readonly string[] _validProperties = {"Id", "Value"};
		private static readonly Dictionary<ExpressionType, ConditionOperator> _conditionLookup = new Dictionary<ExpressionType, ConditionOperator>
		{
			{ExpressionType.Equal, ConditionOperator.Equal},
			{ExpressionType.GreaterThan, ConditionOperator.GreaterThan},
			{ExpressionType.GreaterThanOrEqual, ConditionOperator.GreaterEqual},
			{ExpressionType.LessThan, ConditionOperator.LessThan},
			{ExpressionType.LessThanOrEqual, ConditionOperator.LessEqual},
			{ExpressionType.NotEqual, ConditionOperator.NotEqual}
		};
		private static readonly Dictionary<ConditionOperator, ConditionOperator> _operatorNegationLookup = new Dictionary<ConditionOperator, ConditionOperator>
		{
			{ConditionOperator.Equal, ConditionOperator.NotEqual},
			{ConditionOperator.NotEqual, ConditionOperator.Equal},
			{ConditionOperator.GreaterThan, ConditionOperator.LessEqual},
			{ConditionOperator.GreaterEqual, ConditionOperator.LessThan},
			{ConditionOperator.LessThan, ConditionOperator.GreaterEqual},
			{ConditionOperator.LessEqual, ConditionOperator.GreaterThan},
			{ConditionOperator.Like, ConditionOperator.NotLike},
			{ConditionOperator.NotLike, ConditionOperator.Like},
			{ConditionOperator.Null, ConditionOperator.NotNull},
			{ConditionOperator.NotNull, ConditionOperator.Null}
		};
		private static readonly Dictionary<ExpressionType, LogicalOperator> _booleanLookup = new Dictionary<ExpressionType, LogicalOperator>
		{
			{ExpressionType.And, LogicalOperator.And},
			{ExpressionType.Or, LogicalOperator.Or},
			{ExpressionType.AndAlso, LogicalOperator.And},
			{ExpressionType.OrElse, LogicalOperator.Or}
		};
		private static readonly Dictionary<LogicalOperator, LogicalOperator> _logicalOperatorNegationLookup = new Dictionary<LogicalOperator, LogicalOperator>
		{
			{LogicalOperator.And, LogicalOperator.Or},
			{LogicalOperator.Or, LogicalOperator.And}
		};

		public QueryProvider(OrganizationServiceContext context)
		{
			OrganizationServiceContext = context;
		}

		private OrganizationServiceContext OrganizationServiceContext { get; }

		private IQueryable CreateQuery(Type entityType)
		{
			CheckEntitySubclass(entityType);
			var nameForType = KnownProxyTypesProvider.GetInstance(true).GetNameForType(entityType);
			return CreateQueryInstance(entityType, new object[] {this, nameForType});
		}

		private IQueryable CreateQuery(Expression expression)
		{
			return CreateQueryInstance(expression.Type.GetGenericArguments()[0], new object[] {this, expression});
		}

		IQueryable IQueryProvider.CreateQuery(Expression expression)
		{
			ClientExceptionHelper.ThrowIfNull(expression, nameof(expression));
			return CreateQuery(expression);
		}

		private IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			return new Query<TElement>(this, expression);
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

		private IEnumerable<TElement> Execute<TElement>(Expression expression)
		{
			NavigationSource source = null;
			var linkLookups = new List<LinkLookup>();
			return Execute<TElement>(GetQueryExpression(expression, out var throwIfSequenceIsEmpty, out var throwIfSequenceNotSingle, out var projection, ref source, ref linkLookups), throwIfSequenceIsEmpty, throwIfSequenceNotSingle, projection, source, linkLookups);
		}

		private IEnumerable<TElement> Execute<TElement>(QueryExpression qe, bool throwIfSequenceIsEmpty, bool throwIfSequenceNotSingle, Projection projection, NavigationSource source, List<LinkLookup> linkLookups)
		{
			return new PagedItemCollection<TElement>(Execute(qe, throwIfSequenceIsEmpty, throwIfSequenceNotSingle, projection, source, linkLookups, out var pagingCookie, out var moreRecords).Cast<TElement>(), qe, pagingCookie, moreRecords);
		}

		private IEnumerable Execute(QueryExpression qe, bool throwIfSequenceIsEmpty, bool throwIfSequenceNotSingle, Projection projection, NavigationSource source, List<LinkLookup> linkLookups, out string pagingCookie, out bool moreRecords)
		{
			IEnumerable<Entity> entities = null;
			pagingCookie = null;
			moreRecords = false;
			OrganizationRequest request;
			if (source != null)
			{
				request = new RetrieveRequest
				{
					Target = source.Target,
					ColumnSet = new ColumnSet(),
					RelatedEntitiesQuery = new RelationshipQueryCollection { { source.Relationship, qe } }
				};
			}
			else
			{
				request = new RetrieveMultipleRequest
				{
					Query = qe
				};
			}

			var nullable1 = new int?();
			if (qe.PageInfo != null)
			{
				nullable1 = qe.PageInfo.Count;
			}

			var a = AdjustPagingInfo(request, qe, source);

			EntityCollection entityCollection1;
			if (!a.Adjust)
			{
				entityCollection1 = AdjustEntityCollection(request, qe, source);
			}
			else
			{
				entityCollection1 = a.MoreRecordAfterAdjust
					? RetrieveEntityCollection(request, source)
					: new EntityCollection();
			}

			if (throwIfSequenceIsEmpty && (entityCollection1 == null || entityCollection1.Entities.Count == 0))
			{
				throw new InvalidOperationException("Sequence contains no elements");
			}

			if (throwIfSequenceNotSingle && entityCollection1 != null && entityCollection1.Entities.Count > 1)
			{
				throw new InvalidOperationException("Sequence contains more than one element");
			}

			if (entityCollection1 != null)
			{
				pagingCookie = entityCollection1.PagingCookie;
				moreRecords = entityCollection1.MoreRecords;
				var count = entityCollection1.Entities.Count;
				var entityCollection2 = entityCollection1;
				while (moreRecords)
				{
					if (nullable1.HasValue)
					{
						var nullable2 = nullable1;
						var num = count;
						if ((nullable2.GetValueOrDefault() <= num ? 0 : 1) != 0)
						{
							qe.PageInfo.Count = nullable1.Value - count;
							goto label_16;
						}
					}
					if (nullable1.HasValue)
					{
						var nullable2 = nullable1;
						if ((nullable2.GetValueOrDefault() <= 0 ? 0 : 1) != 0)
						{
							break;
						}
					}
					label_16:
					if (string.IsNullOrEmpty(pagingCookie))
					{
						throw new NotSupportedException($"Paging cookie required to retrieve more records. Update your query to retrieve with total records below {RetrievalUpperLimitWithoutPagingCookie}");
					}

					qe.PageInfo.PagingCookie = entityCollection2.PagingCookie;
					++qe.PageInfo.PageNumber;
					qe.PageInfo.Count = qe.PageInfo.Count < RetrievalUpperLimitWithoutPagingCookie ? qe.PageInfo.Count : RetrievalUpperLimitWithoutPagingCookie;
					entityCollection2 = RetrieveEntityCollection(request, source);
					if (entityCollection2 != null && entityCollection2.Entities.Count > 0)
					{
						pagingCookie = entityCollection2.PagingCookie;
						moreRecords = entityCollection2.MoreRecords;
						count += entityCollection2.Entities.Count;
						entityCollection1.Entities.AddRange(entityCollection2.Entities);
					}
					else
					{
						break;
					}
				}
				entities = entityCollection1.Entities;
			}
			return projection != null ? ExecuteAnonymousType(entities, projection, linkLookups) : entities.Select(AttachToContext);
		}

		private EntityCollection RetrieveEntityCollection(OrganizationRequest request, NavigationSource source)
		{
			if (request == null || string.IsNullOrEmpty(request.RequestName) || request.RequestName != "Retrieve" && request.RequestName != "RetrieveMultiple")
			{
				throw new ArgumentException("Invalid request", nameof(request));
			}

			if (source != null)
			{
				var retrieveResponse = (RetrieveResponse)OrganizationServiceContext.Execute(request);
				return retrieveResponse.Entity.RelatedEntities.Contains(source.Relationship) ? retrieveResponse.Entity.RelatedEntities[source.Relationship] : null;
			}

			var responce = OrganizationServiceContext.Execute(request);

			return ((RetrieveMultipleResponse) responce).EntityCollection;
		}

		private static string ResetPagingNumber(string pagingCookie, int newPage)
		{
			if (string.IsNullOrEmpty(pagingCookie))
			{
				return pagingCookie;
			}

			return PagingCookieHelper.ToPagingCookie(PagingCookieHelper.ToContinuationToken(pagingCookie, newPage), out _);
		}

		private static void ResetPagingInfo(PagingInfo pagingInfo, string pagingCookie, int skipValue)
		{
			if (string.IsNullOrEmpty(pagingCookie))
			{
				pagingInfo.PageNumber = skipValue;
				pagingInfo.Count = 1;
			}
			else
			{
				pagingInfo.PagingCookie = ResetPagingNumber(pagingCookie, 1);
				pagingInfo.PageNumber = skipValue + 1;
				pagingInfo.Count = 1;
			}
		}

		private static bool IsPagingCookieNull(EntityCollection entityCollection)
		{
			return entityCollection != null && string.IsNullOrEmpty(entityCollection.PagingCookie);
		}

		private (bool Adjust, bool MoreRecordAfterAdjust) AdjustPagingInfo(OrganizationRequest request, QueryExpression qe, NavigationSource source)
		{
			if (request == null || qe?.PageInfo == null || !string.IsNullOrEmpty(qe.PageInfo.PagingCookie))
			{
				return (true, true);
			}

			var pageInfo = qe.PageInfo;
			EntityCollection entityCollection = null;
			var pageNumber = pageInfo.PageNumber;
			var count = Math.Min(pageInfo.Count, RetrievalUpperLimitWithoutPagingCookie);
			if (pageNumber > 0)
			{
				var num2 = pageNumber / RetrievalUpperLimitWithoutPagingCookie;
				var skipValue = pageNumber % RetrievalUpperLimitWithoutPagingCookie;
				if (num2 > 0)
				{
					for (var index = 0; index < num2; ++index)
					{
						ResetPagingInfo(pageInfo, entityCollection?.PagingCookie, RetrievalUpperLimitWithoutPagingCookie);
						entityCollection = RetrieveEntityCollection(request, source);
						if (IsPagingCookieNull(entityCollection))
						{
							pageInfo.PageNumber = pageNumber;
							pageInfo.Count = count;
							return (false, true);
						}
						if (entityCollection != null && !entityCollection.MoreRecords)
						{
							return (true, false);
						}
					}
				}
				if (skipValue > 0 && !IsPagingCookieNull(entityCollection))
				{
					ResetPagingInfo(pageInfo, entityCollection?.PagingCookie, skipValue);
					entityCollection = RetrieveEntityCollection(request, source);
					if (IsPagingCookieNull(entityCollection))
					{
						pageInfo.PageNumber = pageNumber;
						pageInfo.Count = count;
						return (false, true);
					}
					if (entityCollection != null && !entityCollection.MoreRecords)
					{
						return (true, false);
					}
				}
				pageInfo.PagingCookie = ResetPagingNumber(entityCollection.PagingCookie, 1);
				pageInfo.PageNumber = 2;
				pageInfo.Count = count;
			}
			if (pageInfo.PageNumber == 0)
			{
				pageInfo.PageNumber = 1;
			}

			return (true, true);
		}

		private EntityCollection AdjustEntityCollection(OrganizationRequest request, QueryExpression qe, NavigationSource source)
		{
			if (request == null || qe?.PageInfo == null || !string.IsNullOrEmpty(qe.PageInfo.PagingCookie))
			{
				return new EntityCollection();
			}

			var pageInfo = qe.PageInfo;
			var pageNumber = pageInfo.PageNumber;
			var count = pageInfo.Count;
			if (pageNumber >= RetrievalUpperLimitWithoutPagingCookie)
			{
				throw new NotSupportedException($"Skipping records beyond {RetrievalUpperLimitWithoutPagingCookie} is not supported");
			}

			pageInfo.PageNumber = 1;
			if (count > 0)
			{
				pageInfo.Count = pageNumber + count > RetrievalUpperLimitWithoutPagingCookie ? RetrievalUpperLimitWithoutPagingCookie : pageNumber + count;
			}

			var entityCollection1 = RetrieveEntityCollection(request, source);
			if (entityCollection1 != null && !string.IsNullOrEmpty(entityCollection1.PagingCookie))
			{
				throw new InvalidOperationException("Queries with valid paging cookie should not be executed in this strategy");
			}

			if (pageNumber <= 0)
			{
				return entityCollection1;
			}

			var entityCollection2 = pageNumber >= entityCollection1.Entities.Count ? new EntityCollection() : new EntityCollection(entityCollection1.Entities.Skip(pageNumber).ToList());
			entityCollection2.EntityName = entityCollection1.EntityName;
			entityCollection2.MoreRecords = entityCollection1.MoreRecords;
			return entityCollection2;
		}

		private int RetrievalUpperLimitWithoutPagingCookie => 5000;

		private IEnumerable ExecuteAnonymousType(IEnumerable<Entity> entities, Projection projection, List<LinkLookup> linkLookups)
		{
			var project = CompileExpression(projection.Expression);
			return entities.Select(entity => new
			{
				entity = entity,
				args = BuildProjection(projection, entity, linkLookups)
			}).Select(_param1 => new
			{
				__TransparentIdentifier3 = _param1,
				element = DynamicInvoke(project, _param1.args)
			}).Select(_param0 => new
			{
				__TransparentIdentifier4 = _param0,
				result = _param0.element as Entity
			}).Select(_param1 => _param1.result == null || !(_param1.result.Id != Guid.Empty) ? _param1.__TransparentIdentifier4.element : AttachToContext(_param1.result));
		}

		[SecuritySafeCritical]
		private Delegate CompileExpression(LambdaExpression expression)
		{
			try
			{
				new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
				return expression.Compile();
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
			}
		}

		[SecuritySafeCritical]
		private object DynamicInvoke(Delegate project, params object[] args)
		{
			try
			{
				new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
				return project.DynamicInvoke(args);
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
			}
		}

		[SecuritySafeCritical]
		private object ConstructorInvoke(ConstructorInfo ci, object[] parameters)
		{
			try
			{
				new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Assert();
				return ci.Invoke(parameters);
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
			}
		}

		private Entity AttachToContext(Entity entity)
		{
			return OrganizationServiceContext.MergeEntity(entity);
		}

		private object[] BuildProjection(Projection projection, Entity entity, List<LinkLookup> linkLookups)
		{
			if (entity == null)
			{
				return null;
			}

			if (linkLookups.Count == 0)
			{
				return new object[]
				{
					AttachToContext(entity)
				};
			}

			var parameters = projection.Expression.Parameters;
			if (linkLookups.Count != 2 || parameters.Count != 2)
			{
				return parameters.Select(parameter => BuildProjection(null, projection.MethodName, parameter.Type, entity, linkLookups)).ToArray();
			}

			return new[]
			{
				linkLookups[1].Link.JoinOperator == JoinOperator.LeftOuter ? BuildProjection(null, projection.MethodName, parameters[0].Type, entity, linkLookups) : entity,
				BuildProjectionParameter(parameters[1].Type, entity, linkLookups[1])
			};
		}

		private object BuildProjection(string environment, string projectingMethodName, Type entityType, Entity entity, List<LinkLookup> linkLookups)
		{
			if (IsEntity(entityType))
			{
				return BuildProjectionParameter(null, projectingMethodName, entityType, entity, linkLookups) ?? entity;
			}

			var constructors = entityType.GetConstructors();
			if (IsAnonymousType(entityType) && constructors.Length != 1)
			{
				throw new InvalidOperationException("The result selector of the 'Join' operation is not returning a valid anonymous type.");
			}

			var ci = constructors.First();
			var parameters = ci.GetParameters();
			if (parameters.Length != 2)
			{
				throw new InvalidOperationException("The result selector of the 'Join' operation must return an anonymous type of two properties.");
			}

			var parameterInfo1 = parameters[0];
			var parameterInfo2 = parameters[1];
			if (IsEntity(parameterInfo1.ParameterType) && IsEntity(parameterInfo2.ParameterType))
			{
				var obj1 = BuildProjectionParameter(parameterInfo1, environment, projectingMethodName, parameterInfo1.ParameterType, entity, linkLookups);
				var obj2 = BuildProjectionParameter(parameterInfo2, environment, projectingMethodName, parameterInfo2.ParameterType, entity, linkLookups);
				return ConstructorInvoke(ci, new[] {obj1, obj2});
			}
			if (IsEntity(parameterInfo2.ParameterType))
			{
				var obj1 = BuildProjectionParameter(parameterInfo1, environment, projectingMethodName, entity, linkLookups);
				var obj2 = BuildProjectionParameter(parameterInfo2, environment, projectingMethodName, parameterInfo2.ParameterType, entity, linkLookups);
				return ConstructorInvoke(ci, new[] {obj1, obj2});
			}
			if (IsEntity(parameterInfo1.ParameterType))
			{
				var obj1 = BuildProjectionParameter(parameterInfo1, environment, projectingMethodName, parameterInfo1.ParameterType, entity, linkLookups);
				var obj2 = BuildProjectionParameter(parameterInfo2, environment, projectingMethodName, entity, linkLookups);
				return ConstructorInvoke(ci, new[] {obj1, obj2});
			}
			throw new InvalidOperationException($"Invalid left '{parameterInfo1.ParameterType.Name}' and right '{parameterInfo2.ParameterType.Name}' parameters.");
		}

		private object BuildProjectionParameter(ParameterInfo parameter, string environment, string projectingMethodName, Entity entity, List<LinkLookup> linkLookups)
		{
			return parameter.ParameterType.IsGenericType && parameter.ParameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>) ? null : BuildProjection(GetEnvironment(parameter, environment), projectingMethodName, parameter.ParameterType, entity, linkLookups);
		}

		private object BuildProjectionParameter(ParameterInfo pi, string environment, string projectingMethodName, Type entityType, Entity entity, List<LinkLookup> linkLookups)
		{
			return BuildProjectionParameter(GetEnvironment(pi, environment), projectingMethodName, entityType, entity, linkLookups);
		}

		private object BuildProjectionParameter(string environment, string projectingMethodName, Type entityType, Entity entity, List<LinkLookup> linkLookups)
		{
			var link = projectingMethodName == "SelectMany" ? linkLookups.SingleOrDefault(l => l.SelectManyEnvironment != null && l.SelectManyEnvironment == environment) : linkLookups.SingleOrDefault(l => l.Environment == environment);
			if (link != null)
			{
				return BuildProjectionParameter(entityType, entity, link);
			}

			throw new InvalidOperationException("The projection property does not match an existing entity binding.");
		}

		private object BuildProjectionParameter(Type entityType, Entity entity, LinkLookup link)
		{
			if (link.Link == null)
			{
				return entity;
			}

			var entity1 = entityType == typeof (Entity) ? new Entity(link.Link.LinkToEntityName) : (Entity)Activator.CreateInstance(entityType);
			var entityAlias = $"{link.Link.EntityAlias}.";
			var aliasIndex = entityAlias.Length;

			foreach (var attribute in entity.Attributes)
			{
				if (attribute.Value is AliasedValue value && attribute.Key.StartsWith(entityAlias, StringComparison.Ordinal))
				{
					entity1.Attributes.Add(attribute.Key.Substring(aliasIndex), value);
				}
			}

			return entity1;
		}

		private static string GetEnvironment(ParameterInfo pi, string environment)
		{
			return environment == null ? pi.Name : $"{environment}.{pi.Name}";
		}

		private bool IsValidFollowingMethod(string method, string next)
		{
			return _followingMethodLookup.TryGetValue(method, out var source) && source.Contains(next);
		}

		private bool IsSupportedMethod(string method)
		{
			return _followingMethodLookup.ContainsKey(method);
		}

		private QueryExpression GetQueryExpression(Expression expression, out bool throwIfSequenceIsEmpty, out bool throwIfSequenceNotSingle, out Projection projection, ref NavigationSource source, ref List<LinkLookup> linkLookups)
		{
			throwIfSequenceIsEmpty = false;
			throwIfSequenceNotSingle = false;
			projection = null;
			var skip = new int?();
			var take = new int?();
			var qe = new QueryExpression();
			var list = expression.GetMethodsPostorder().ToList();
			var isFirstJoin = list.Count > 0 && (list[0].Method.Name == nameof(Queryable.Join) || list[0].Method.Name == nameof(Queryable.GroupJoin));
			string beforeMethodName = null;
			for (var i = 0; i < list.Count; ++i)
			{
				var mce = list[i];
				var methodName = mce.Method.Name;
				if (!IsSupportedMethod(methodName))
				{
					throw new NotSupportedException($"The method '{methodName}' is not supported.");
				}

				if (beforeMethodName != null && !IsValidFollowingMethod(beforeMethodName, methodName))
				{
					throw new NotSupportedException($"The method '{methodName}' cannot follow the method '{beforeMethodName}' or is not supported. Try writing the query in terms of supported methods or call the 'AsEnumerable' or 'ToList' method before calling unsupported methods.");
				}
				beforeMethodName = methodName;

				switch (methodName)
				{
					case nameof(Queryable.Join):
					{
						var data = TranslateJoin(qe, list, ref i);
						projection = data.projection;
						linkLookups = data.linkLookups;
						break;
					}
					case nameof(Queryable.GroupJoin):
					{
						var data = TranslateGroupJoin(qe, list, ref i);
						projection = data.projection;
						linkLookups = data.linkLookups;
						break;
					}
					case nameof(Queryable.FirstOrDefault):
					{
						take = 1;
						var methodData = GetMethodCallBody(mce);
						if (methodData.Body == null)
						{
							break;
						}
						TranslateWhere(qe, methodData.parameterName, methodData.Body, linkLookups);
						break;
					}
					case nameof(Queryable.SingleOrDefault):
					{
						take = 2;
						throwIfSequenceNotSingle = true;

						var methodData = GetMethodCallBody(mce);
						if (methodData.Body == null)
						{
							break;
						}
						TranslateWhere(qe, methodData.parameterName, methodData.Body, linkLookups);
						break;
					}
					case nameof(Queryable.First):
					{
						take = 1;
						throwIfSequenceIsEmpty = true;
						var methodData = GetMethodCallBody(mce);
						if (methodData.Body == null)
						{
							break;
						}
						TranslateWhere(qe, methodData.parameterName, methodData.Body, linkLookups);
						break;
					}
					case nameof(Queryable.Single):
					{
						throwIfSequenceIsEmpty = true;
						take = 2;
						throwIfSequenceNotSingle = true;
						var methodData = GetMethodCallBody(mce);
						if (methodData.Body == null)
						{
							break;
						}
						TranslateWhere(qe, methodData.parameterName, methodData.Body, linkLookups);
						break;
					}
					case nameof(Queryable.Where):
					{
						var methodData = GetMethodCallBody(mce);
						TranslateWhere(qe, methodData.parameterName, methodData.Body, linkLookups);
						break;
					}
					case nameof(Queryable.OrderBy):
					case nameof(Queryable.ThenBy):
					{	
						var methodData = GetMethodCallBody(mce);
						TranslateOrderBy(qe, methodData.Body, methodData.parameterName, OrderType.Ascending, linkLookups);
						break;
					}
					case nameof(Queryable.OrderByDescending):
					case nameof(Queryable.ThenByDescending):
					{	
						var methodData = GetMethodCallBody(mce);
						TranslateOrderBy(qe, methodData.Body, methodData.parameterName, OrderType.Descending, linkLookups);
						break;
					}
					case nameof(Queryable.Select):
						if (linkLookups != null && !isFirstJoin)
						{
							linkLookups.Clear();
						}

						TranslateEntityName(qe, expression);
						var operand1 = (mce.Arguments[1] as UnaryExpression).Operand as LambdaExpression;
						projection = new Projection(methodName, operand1);
						var expression1 = TranslateSelect(list, i, qe, operand1, ref source);
						if (expression1 != null)
						{
							return GetQueryExpression(expression1, out throwIfSequenceIsEmpty, out throwIfSequenceNotSingle, out projection, ref source, ref linkLookups);
						}

						break;
					case nameof(Queryable.Skip):
						skip = (int)(mce.Arguments[1] as ConstantExpression).Value;
						if (skip.HasValue)
						{
							var nullable = skip;
							if ((nullable.GetValueOrDefault() >= 0 ? 0 : nullable.HasValue ? 1 : 0) != 0)
							{
								throw new NotSupportedException("Skip operator does not support negative values.");
							}
						}
						break;
					case nameof(Queryable.Take):
						take = (int)(mce.Arguments[1] as ConstantExpression).Value;
						if (take.HasValue)
						{
							var nullable = take;
							if ((nullable.GetValueOrDefault() > 0 ? 0 : nullable.HasValue ? 1 : 0) != 0)
							{
								throw new NotSupportedException("Take/Top operators only support positive values.");
							}
						}
						break;
					case nameof(Enumerable.Distinct):
						qe.Distinct = true;
						break;
					case nameof(Queryable.SelectMany):
					{
						if (linkLookups != null && !isFirstJoin)
						{
							linkLookups.Clear();
						}

						TranslateEntityName(qe, expression);
						var operand2 = (mce.Arguments[1] as UnaryExpression).Operand as LambdaExpression;
						return GetQueryExpression(TranslateSelectMany(list, i, qe, operand2, ref source), out throwIfSequenceIsEmpty, out throwIfSequenceNotSingle, out projection, ref source, ref linkLookups);
					}
				}
			}

			if (projection != null)
			{
				TranslateSelect(qe, projection.Expression, linkLookups);
				FixOrderBy(qe, projection.Expression);
			}

			BuildPagingInfo(qe, skip, take);

			FixEntityName(qe, expression);
			FixColumnSet(qe);
			return qe;
		}

		private void BuildPagingInfo(QueryExpression qe, int? skip, int? take)
		{
			if (!skip.HasValue && !take.HasValue)
			{
				return;
			}

			if (qe.PageInfo == null)
			{
				qe.PageInfo = new PagingInfo();
			}

			if (skip > 0)
			{
				qe.PageInfo.PageNumber = skip.Value;
			}

			if (take > 0)
			{
				qe.PageInfo.Count = take.Value;
			}
		}

		private void FixOrderBy(QueryExpression qe, LambdaExpression exp)
		{
		}

		private void FixEntityName(QueryExpression qe, Expression expression)
		{
			TranslateEntityName(qe, expression);
		}

		private void FixColumnSet(QueryExpression qe)
		{
			qe.ColumnSet = qe.ColumnSet == null || qe.ColumnSet.Columns.Count == 0 ? new ColumnSet(true) : qe.ColumnSet;
		}

		private struct JoinData
		{
			public ConstantExpression Outer => (ConstantExpression) _methodCallExpression.Arguments[0];
			public ConstantExpression Inner => (ConstantExpression) _methodCallExpression.Arguments[1];
			public UnaryExpression OuterKeySelector => (UnaryExpression) _methodCallExpression.Arguments[2];
			public UnaryExpression InnerKeySelector => (UnaryExpression) _methodCallExpression.Arguments[3];
			public UnaryExpression ResultSelector => (UnaryExpression) _methodCallExpression.Arguments[4];
			public string MethodName => _methodCallExpression.Method.Name;

			private readonly MethodCallExpression _methodCallExpression;

			public JoinData(MethodCallExpression methodCallExpression)
			{
				_methodCallExpression = methodCallExpression;
			}
		}

		private class LinkData
		{
			public readonly string Item1;
			public readonly string Environment;
			public readonly LinkEntity Link;
			public readonly string ParameterName;

			public LinkData(string parameterName, LinkEntity link, string item1, string environment)
			{
				Item1 = item1;
				Environment = environment;
				Link = link;
				ParameterName = parameterName;
			}
		}

		private (Projection projection, List<LinkLookup> linkLookups) TranslateJoin(QueryExpression qe, List<MethodCallExpression> methods, ref int i)
		{
			var num = 0;
			var source = new List<LinkData>();
			Projection projection;
			do
			{
				var method = new JoinData(methods[i]);
				projection = new Projection(method.MethodName, method.ResultSelector.Operand as LambdaExpression);
				string str;
				string environment;
				if (i < methods.Count - 1)
				{
					environment = GetEnvironmentForParameter(projection.Expression, 0);
					str = GetEnvironmentForParameter(projection.Expression, 1);
				}
				else
				{
					environment = str = null;
				}

				var operand1 = method.OuterKeySelector.Operand as LambdaExpression;
				var name1 = operand1.Parameters[0].Name;
				var entityExpression = FindValidEntityExpression(operand1.Body, nameof(Queryable.Join));
				var attributeName1 = TranslateExpressionToAttributeName(entityExpression);
				
				var operand2 = method.InnerKeySelector.Operand as LambdaExpression;
				var name2 = operand2.Parameters[0].Name;
				var entityExpression2 = FindValidEntityExpression(operand2.Body, nameof(Queryable.Join));
				var attributeName2 = TranslateExpressionToAttributeName(entityExpression2);
				
				var entityLogicalName = (method.Inner.Value as IEntityQuery).EntityLogicalName;
				
				LinkEntity linkEntity1;
				if (source.Count == 0)
				{
					qe.EntityName = (method.Outer.Value as IEntityQuery).EntityLogicalName;

					source.Add(new LinkData(name1, null, environment, environment));

					linkEntity1 = qe.AddLink(entityLogicalName, attributeName1, attributeName2, JoinOperator.Inner);
				}
				else
				{
					if (environment != null)
					{
						source = source.Select(l => new LinkData(l.ParameterName, l.Link, l.Item1, environment + "." + l.Environment)).ToList();
					}

					var parentMember = GetUnderlyingMemberExpression(entityExpression).Member.Name;
					
					var linkEntity2 = source.Single(l => l.Item1 == parentMember).Link;
					
					linkEntity1 = linkEntity2 == null 
						? qe.AddLink(entityLogicalName, attributeName1, attributeName2, JoinOperator.Inner) 
						: linkEntity2.AddLink(entityLogicalName, attributeName1, attributeName2, JoinOperator.Inner);
				}
				linkEntity1.EntityAlias = $"{name2}_{num++}";
				source.Add(new LinkData(name2, linkEntity1, str, str));
				++i;
			}
			while (i < methods.Count && methods[i].Method.Name == "Join");
			
			--i;
			var linkLookups = source.Select(l => new LinkLookup(l.ParameterName, l.Environment, l.Link)).ToList();
			return (projection, linkLookups);
		}

		private (Projection projection, List<LinkLookup> linkLookups) TranslateGroupJoin(QueryExpression qe, List<MethodCallExpression> methods, ref int i)
		{
			var method1 = methods[i];
			var linkLookups1 = TranslateJoin(qe, methods, ref i).linkLookups;
			++i;
			if (i + 1 > methods.Count || !IsValidLeftOuterSelectManyExpression(methods[i]))
			{
				throw new NotSupportedException("The 'GroupJoin' operation must be followed by a 'SelectMany' operation where the collection selector is invoking the 'DefaultIfEmpty' method.");
			}

			var method2 = methods[i];
			LambdaExpression expression;
			if (method2.Arguments.Count == 3)
			{
				expression = (method2.Arguments[2] as UnaryExpression).Operand as LambdaExpression;
			}
			else
			{
				var parameter1 = ((method2.Arguments[1] as UnaryExpression).Operand as LambdaExpression).Parameters[0];
				var parameter2 = ((method1.Arguments[3] as UnaryExpression).Operand as LambdaExpression).Parameters[0];
				expression = Expression.Lambda(parameter2, parameter1, parameter2);
			}
			var projection = new Projection(method2.Method.Name, expression);
			var environmentForParameter1 = GetEnvironmentForParameter(projection.Expression, 0);
			var environmentForParameter2 = GetEnvironmentForParameter(projection.Expression, 1);
			
			var firstJoinLink = linkLookups1[0];
			
			var environment1 = environmentForParameter1 == null ? firstJoinLink.Environment : $"{environmentForParameter1}.{firstJoinLink.Environment}";
			var linkLookup = new LinkLookup(firstJoinLink.ParameterName, environment1, firstJoinLink.Link, firstJoinLink.Environment);
			
			var linkLookupList1 = new List<LinkLookup>();
			
			linkLookupList1.Add(linkLookup);
			linkLookupList1.Add(new LinkLookup(linkLookups1[1].ParameterName, environmentForParameter2, linkLookups1[1].Link));

			linkLookups1[1].Link.JoinOperator = JoinOperator.LeftOuter;

			return (projection, linkLookupList1);
		}

		private bool IsValidLeftOuterSelectManyExpression(MethodCallExpression mce)
		{
			return 
				mce.Method.Name == nameof(Queryable.SelectMany) && 
				mce.Arguments[1] is UnaryExpression unaryExpression1 && 
				unaryExpression1.Operand is LambdaExpression operand1 && 
				operand1.Body is MethodCallExpression body && 
				body.Method.Name == nameof(Queryable.DefaultIfEmpty) && 
				body.Arguments.Count == 1 && 
				(
					mce.Arguments.Count == 2 || 
					mce.Arguments.Count == 3 && 
					mce.Arguments[2] is UnaryExpression unaryExpression2 && 
					unaryExpression2.Operand is LambdaExpression operand2 && 
					operand2.Parameters.Count == 2
				);
		}

		private string GetEnvironmentForParameter(LambdaExpression projection, int index)
		{
			if (projection.Body is NewExpression body)
			{
				var parameter = projection.Parameters[index];
				var arguments = body.Arguments;

				for (int i = 0; i < arguments.Count; i++)
				{
					var argument = arguments[i];
					if (argument == parameter)
					{
						return body.Members[i].Name;
					}
				}
			}

			return null;
		}

		private ConditionOperator NegateOperator(ConditionOperator op)
		{
			return _operatorNegationLookup[op];
		}

		private LogicalOperator NegateOperator(LogicalOperator op)
		{
			return _logicalOperatorNegationLookup[op];
		}

		private void TranslateWhere(QueryExpression qe, string parameterName, Expression body, List<LinkLookup> linkLookups)
		{
			TranslateWhereBoolean(parameterName, body, null, GetFilter(qe), linkLookups, null, false);
		}

		private void TranslateWhere(string parameterName, BinaryExpression be, FilterExpressionWrapper parentFilter, Func<Expression, FilterExpressionWrapper> getFilter, List<LinkLookup> linkLookups, bool negate)
		{
			if (_booleanLookup.ContainsKey(be.NodeType))
			{
				parentFilter = GetFilter(FindEntityExpression(be.Left), parentFilter, getFilter);
				var parentFilter1 = new FilterExpressionWrapper(parentFilter.Filter.AddFilter(_booleanLookup[be.NodeType]), parentFilter.Alias);
				parentFilter1.Filter.FilterOperator = negate ? NegateOperator(parentFilter1.Filter.FilterOperator) : parentFilter1.Filter.FilterOperator;
				TranslateWhereBoolean(parameterName, be.Left, parentFilter1, getFilter, linkLookups, be, negate);
				TranslateWhereBoolean(parameterName, be.Right, parentFilter1, getFilter, linkLookups, be, negate);
			}
			else
			{
				if (!_conditionLookup.ContainsKey(be.NodeType))
				{
					return;
				}

				var negate1 = negate;
				if (TranslateWhere(be.Left, ref negate1) is MethodCallExpression methodCallExpression && (methodCallExpression.Method.Name == "Compare" || _supportedMethods.Contains(methodCallExpression.Method.Name)))
				{
					TranslateWhereBoolean(parameterName, methodCallExpression, parentFilter, getFilter, linkLookups, be, negate1);
				}
				else
				{
					TranslateWhereCondition(be, parentFilter, getFilter, GetLinkLookup(parameterName, linkLookups), negate);
				}
			}
		}

		private Expression TranslateWhere(Expression exp, ref bool negate)
		{
			if (!(exp is UnaryExpression unaryExpression) || unaryExpression.NodeType != ExpressionType.Not)
			{
				return exp;
			}

			negate = !negate;
			return TranslateWhere(unaryExpression.Operand, ref negate);
		}

		private void TranslateWhereBoolean(string parameterName, Expression body, FilterExpressionWrapper parentFilter, Func<Expression, FilterExpressionWrapper> getFilter, List<LinkLookup> linkLookups, BinaryExpression parent, bool negate)
		{
			switch (body)
			{
				case BinaryExpression be:
					if (be.Left is ConstantExpression left && (be.NodeType == ExpressionType.AndAlso && Equals(left.Value, true) || be.NodeType == ExpressionType.OrElse && Equals(left.Value, false)))
					{
						TranslateWhereBoolean(parameterName, be.Right, parentFilter, getFilter, linkLookups, parent, negate);
					}
					else
					{
						TranslateWhere(parameterName, be, parentFilter, getFilter, linkLookups, negate);
					}
					break;
				case MethodCallExpression mce:
					TranslateWhereMethodCall(mce, parentFilter, getFilter, GetLinkLookup(parameterName, linkLookups), parent, negate);
					break;
				case UnaryExpression unaryExpression:
					if (unaryExpression.NodeType == ExpressionType.Convert)
					{
						TranslateWhereBoolean(parameterName, unaryExpression.Operand, parentFilter, getFilter, linkLookups, parent, negate);
					}
					else
					{
						if (unaryExpression.NodeType != ExpressionType.Not)
						{
							return;
						}

						TranslateWhereBoolean(parameterName, unaryExpression.Operand, parentFilter, getFilter, linkLookups, parent, !negate);
					}
					break;
				default:
				{
					if (!(body.Type == typeof(bool)))
					{
						return;
					}

					TranslateWhere(parameterName, Expression.Equal(body, Expression.Constant(true)), parentFilter, getFilter, linkLookups, negate);
					break;
				}
			}
		}

		private string GetLinkEntityAlias(Expression expression, Func<Expression, LinkLookup> getLinkLookup)
		{
			return getLinkLookup(expression)?.Link?.EntityAlias;
		}

		private void TranslateWhereCondition(BinaryExpression be, FilterExpressionWrapper parentFilter, Func<Expression, FilterExpressionWrapper> getFilter, Func<Expression, LinkLookup> getLinkLookup, bool negate)
		{
			var entityExpression = FindValidEntityExpression(be.Left, nameof(Queryable.Where));
			var attributeName = TranslateExpressionToAttributeName(entityExpression);
			var conditionValue = TranslateExpressionToConditionValue(be.Right);
			var linkEntityAlias = GetLinkEntityAlias(entityExpression, getLinkLookup);
			ConditionExpression condition;
			if (conditionValue != null)
			{
				condition = new ConditionExpression(linkEntityAlias, attributeName, _conditionLookup[be.NodeType], conditionValue);
			}
			else if (be.NodeType == ExpressionType.Equal)
			{
				condition = new ConditionExpression(linkEntityAlias, attributeName, ConditionOperator.Null);
			}
			else if (be.NodeType == ExpressionType.NotEqual)
			{
				condition = new ConditionExpression(linkEntityAlias, attributeName, ConditionOperator.NotNull);
			}
			else
			{
				throw new NotSupportedException("Invalid 'where' condition.");
			}

			condition.Operator = negate ? NegateOperator(condition.Operator) : condition.Operator;
			AddCondition(GetFilter(entityExpression, parentFilter, getFilter), condition, null);
		}

		private void TranslateWhereMethodCall(MethodCallExpression mce, FilterExpressionWrapper parentFilter, Func<Expression, FilterExpressionWrapper> getFilter, Func<Expression, LinkLookup> getLinkLookup, BinaryExpression parent, bool negate)
		{
			if (_supportedMethods.Contains(mce.Method.Name) && mce.Arguments.Count == 1)
			{
				var entityExpression = FindValidEntityExpression(mce.Object, nameof(Queryable.Where));
				var linkEntityAlias = GetLinkEntityAlias(entityExpression, getLinkLookup);
				var attributeName = TranslateExpressionToAttributeName(entityExpression);
				var conditionValue = TranslateExpressionToConditionValue(mce.Arguments[0]);
				if (parent != null)
				{
					if (parent.NodeType == ExpressionType.NotEqual)
					{
						negate = !negate;
					}

					if ((parent.NodeType == ExpressionType.Equal || parent.NodeType == ExpressionType.NotEqual) && Equals(TranslateExpressionToConditionValue(parent.Right), false))
					{
						negate = !negate;
					}
				}
				var condition = TranslateConditionMethodExpression(mce, attributeName, conditionValue);
				condition.EntityName = linkEntityAlias;
				condition.Operator = negate ? NegateOperator(condition.Operator) : condition.Operator;
				AddCondition(GetFilter(entityExpression, parentFilter, getFilter), condition, null);
			}
			else if (mce.Method.Name == "Compare" && mce.Arguments.Count == 2)
			{
				var entityExpression = FindValidEntityExpression(mce.Arguments[0], nameof(Queryable.Where));
				var linkEntityAlias = GetLinkEntityAlias(entityExpression, getLinkLookup);
				var attributeName = TranslateExpressionToAttributeName(entityExpression);
				var conditionValue = TranslateExpressionToConditionValue(mce.Arguments[1]);
				if (parent == null || !Equals(TranslateExpressionToConditionValue(parent.Right), 0) || !_conditionLookup.TryGetValue(parent.NodeType, out var conditionOperator))
				{
					return;
				}

				var condition = new ConditionExpression(linkEntityAlias, attributeName, conditionOperator, conditionValue);
				condition.Operator = negate ? NegateOperator(condition.Operator) : condition.Operator;
				AddCondition(GetFilter(entityExpression, parentFilter, getFilter), condition, null);
			}
			else if (mce.Method.Name == "Like" && mce.Arguments.Count == 2)
			{
				var entityExpression = FindValidEntityExpression(mce.Arguments[0], nameof(Queryable.Where));
				var condition = new ConditionExpression(GetLinkEntityAlias(entityExpression, getLinkLookup), TranslateExpressionToAttributeName(entityExpression), ConditionOperator.Like, TranslateExpressionToConditionValue(mce.Arguments[1]));
				condition.Operator = negate ? NegateOperator(condition.Operator) : condition.Operator;
				AddCondition(GetFilter(entityExpression, parentFilter, getFilter), condition, null);
			}
			else
			{
				if (parent != null && !_booleanLookup.ContainsKey(parent.NodeType) || !(mce.Type.GetUnderlyingType() == typeof(bool)))
				{
					return;
				}

				var entityExpression = FindValidEntityExpression(mce, nameof(Queryable.Where));
				var condition = new ConditionExpression(GetLinkEntityAlias(entityExpression, getLinkLookup), TranslateExpressionToAttributeName(entityExpression), ConditionOperator.Equal, true);
				condition.Operator = negate ? NegateOperator(condition.Operator) : condition.Operator;
				AddCondition(GetFilter(entityExpression, parentFilter, getFilter), condition, null);
			}
		}

		private ConditionExpression TranslateConditionMethodExpression(MethodCallExpression mce, string attributeName, object value)
		{
			ConditionExpression conditionExpression;
			switch (mce.Method.Name)
			{
				case "Equals":
					conditionExpression = value == null 
						? new ConditionExpression(attributeName, ConditionOperator.Null) 
						: new ConditionExpression(attributeName, ConditionOperator.Equal, value);
					break;
				case "Contains":
					conditionExpression = new ConditionExpression(attributeName, ConditionOperator.Like, "%" + value + "%");
					break;
				case "StartsWith":
					conditionExpression = new ConditionExpression(attributeName, ConditionOperator.Like, value + "%");
					break;
				case "EndsWith":
					conditionExpression = new ConditionExpression(attributeName, ConditionOperator.Like, "%" + value);
					break;
				default:
					throw new NotSupportedException($"The method '{mce.Method.Name}' is not supported.");
			}
			return conditionExpression;
		}

		private void AddCondition(FilterExpressionWrapper filter, ConditionExpression condition, string alias)
		{
			if (filter.Alias != alias)
			{
				throw new NotSupportedException("filter conditions of different entity types, in the same expression, are not supported");
			}

			filter.Filter.AddCondition(condition);
		}

		private FilterExpressionWrapper GetFilter(Expression entityExpression, FilterExpressionWrapper parentFilter, Func<Expression, FilterExpressionWrapper> getFilter)
		{
			return parentFilter ?? getFilter(entityExpression);
		}

		private Func<Expression, LinkLookup> GetLinkLookup(string parameterName, List<LinkLookup> linkLookups)
		{
			return exp =>
			{
				var expName = GetUnderlyingParameterExpressionName(exp);
				return linkLookups.SingleOrDefault(link =>
				{
					var str = $"{parameterName}.{link.Environment}";
					if (expName == str)
					{
						return true;
					}

					return expName.StartsWith(str) && expName[str.Length] == '.';
				});
			};
		}

		private Func<Expression, FilterExpressionWrapper> GetFilter(QueryExpression qe)
		{
			return exp => new FilterExpressionWrapper(qe.Criteria, null);
		}

		private void TranslateOrderBy(QueryExpression qe, Expression exp, string parameterName, OrderType orderType, List<LinkLookup> linkLookups)
		{
			if (IsEntityExpression(exp))
			{
				ValidateRootEntity("orderBy", exp, parameterName, linkLookups);
				var attributeName = TranslateExpressionToAttributeName(exp);
				qe.AddOrder(attributeName, orderType);
			}
			else
			{
				TranslateNonEntityExpressionOrderBy(qe, exp, orderType);
			}
		}

		private void TranslateNonEntityExpressionOrderBy(QueryExpression qe, Expression exp, OrderType orderType)
		{
			throw new NotSupportedException("The 'orderBy' call must specify property names.");
		}

		private void ValidateRootEntity(string operationName, Expression exp, string parameterName, List<LinkLookup> linkLookups)
		{
			if (linkLookups == null)
			{
				return;
			}

			var parameterExpressionName = GetUnderlyingParameterExpressionName(exp);
			var linkLookup = linkLookups.SingleOrDefault(l => l.Link == null);
			if (linkLookup == null)
			{
				return;
			}

			if ($"{parameterName}.{linkLookup.Environment}" == parameterExpressionName)
			{
				return;
			}

			throw new NotSupportedException($"The '{operationName}' expression is limited to invoking the '{linkLookup.ParameterName}' parameter.");
		}

		private Expression TranslateSelect(List<MethodCallExpression> methods, int i, QueryExpression qe, LambdaExpression exp, ref NavigationSource source)
		{
			var subExpression = TranslateSelect(exp, qe, ref source);
			return subExpression == null ? null : MergeSubExpression(subExpression, methods, i);
		}

		private Expression TranslateSelect(LambdaExpression exp, QueryExpression qe, ref NavigationSource source)
		{
			if (qe.Criteria.Conditions.Count != 1 || qe.Criteria.Conditions[0].Values.Count != 1 || !(qe.Criteria.Conditions[0].Values[0] is Guid))
			{
				return null;
			}

			var condition = qe.Criteria.Conditions[0];
			var target = new EntityReference(qe.EntityName, (Guid) condition.Values[0]);
			var relationshipQuery = GetSelectRelationshipQuery(exp, true);
			if (relationshipQuery.q != null)
			{
				source = new NavigationSource(target, relationshipQuery.relationship);
				return relationshipQuery.q.Expression;
			}
			source = null;
			return null;
		}

		private void TranslateSelect(QueryExpression qe, LambdaExpression exp, List<LinkLookup> linkLookups)
		{
			var parameterName = exp.Parameters[0].Name;
			foreach (var column in TraverseSelect(exp.Body))
			{
				if (linkLookups != null)
				{
					var expName = column.ParameterName;
					var linkLookup1 = linkLookups.SingleOrDefault(l => $"{parameterName}.{l.Environment}" == expName);
					if (linkLookup1?.Link != null)
					{
						TranslateSelect(column, linkLookup1.Link.Columns);
						continue;
					}
					if (linkLookup1 == null && exp.Parameters.Count > 1)
					{
						var name = exp.Parameters[1].Name;
						var linkLookup2 = column.ParameterName == name ? linkLookups.Last() : column.ParameterName != parameterName || linkLookups.Count != 2 ? null : linkLookups.First();
						if (linkLookup2?.Link != null)
						{
							TranslateSelect(column, linkLookup2.Link.Columns);
							continue;
						}
					}
				}
				TranslateSelect(column, qe.ColumnSet);
			}
		}

		private void TranslateSelect(EntityColumn column, ColumnSet columnSet)
		{
			if (column.AllColumns)
			{
				columnSet.AllColumns = true;
			}
			else
			{
				if (columnSet.AllColumns || columnSet.Columns.Contains(column.Column))
				{
					return;
				}

				columnSet.AddColumn(column.Column);
			}
		}

		private IEnumerable<EntityColumn> TraverseSelect(Expression exp)
		{
			var column = TranslateSelectColumn(exp);
			if (column != null)
			{
				if (column.AllColumns || column.Column != null)
				{
					yield return column;
				}
			}
			else
			{
				foreach (var child in exp.GetChildren())
				{
					foreach (var entityColumn in TraverseSelect(child))
					{
						yield return entityColumn;
					}
				}
			}
		}

		private EntityColumn TranslateSelectColumn(Expression exp)
		{
			var memberExpression = exp as MemberExpression;
			var methodCallExpression = exp as MethodCallExpression;
			var pe = exp as ParameterExpression;
			if (memberExpression?.Expression != null && IsEntity(memberExpression.Expression.Type) || methodCallExpression?.Object != null && IsEntity(methodCallExpression.Object.Type))
			{
				if (memberExpression != null && memberExpression.Member.DeclaringType == typeof(Entity))
				{
					return new EntityColumn();
				}

				var attributeName = TranslateExpressionToAttributeName(exp);
				if (!string.IsNullOrEmpty(attributeName))
				{
					return new EntityColumn(GetUnderlyingParameterExpressionName(exp), attributeName);
				}
			}
			else
			{
				if (memberExpression != null && IsEntity(memberExpression.Type) || methodCallExpression != null && IsEntity(methodCallExpression.Type))
				{
					return new EntityColumn(exp.ToString(), true);
				}

				if (memberExpression != null && IsEnumerableEntity(memberExpression.Type) || methodCallExpression != null && IsEnumerableEntity(methodCallExpression.Type))
				{
					throw new NotSupportedException($"The expression '{exp}' is an invalid column projection expression. Entity collections cannot be selected.");
				}
			}
			return TranslateSelectColumn(pe);
		}

		private EntityColumn TranslateSelectColumn(ParameterExpression pe)
		{
			if (pe != null && IsEntity(pe.Type))
			{
				return new EntityColumn(pe.ToString(), true);
			}

			if (pe != null && IsEnumerableEntity(pe.Type))
			{
				throw new NotSupportedException($"The expression '{pe}' is an invalid column projection expression. Entity collections cannot be selected.");
			}

			return null;
		}

		private Expression TranslateSelectMany(List<MethodCallExpression> methods, int i, QueryExpression qe, LambdaExpression exp, ref NavigationSource source)
		{
			var subExpression = TranslateSelectMany(qe, exp, ref source);
			return subExpression == null ? null : MergeSubExpression(subExpression, methods, i);
		}

		private Expression MergeSubExpression(Expression subExpression, List<MethodCallExpression> methods, int i)
		{
			for (var index = i + 1; index < methods.Count; ++index)
			{
				var method = methods[index];
				subExpression = Expression.Call(null, method.Method, new[] {subExpression}.Concat(method.Arguments.Skip(1)));
			}
			return subExpression;
		}

		private Expression TranslateSelectMany(QueryExpression qe, LambdaExpression exp, ref NavigationSource source)
		{
			if (qe.Criteria.Conditions.Count != 1 || qe.Criteria.Conditions[0].Values.Count != 1 || !(qe.Criteria.Conditions[0].Values[0] is Guid))
			{
				throw new InvalidOperationException("A 'SelectMany' operation must be preceeded by a 'Where' operation that filters by an entity ID.");
			}

			var condition = qe.Criteria.Conditions[0];
			var target = new EntityReference(qe.EntityName, (Guid) condition.Values[0]);
			var relationshipQuery = GetSelectRelationshipQuery(exp, false);
			if (relationshipQuery.q != null)
			{
				source = new NavigationSource(target, relationshipQuery.relationship);
				return relationshipQuery.q.Expression;
			}
			source = null;
			return null;
		}

		private (IQueryable q, Relationship relationship) GetSelectRelationshipQuery(LambdaExpression exp, bool isSelect)
		{
			if (!(FindEntityExpression(exp.Body) is MemberExpression entityExpression))
			{
				return (null, null);
			}
			var defaultCustomAttribute = entityExpression.Member.GetFirstOrDefaultCustomAttribute<RelationshipSchemaNameAttribute>();
			if (defaultCustomAttribute == null)
			{
				if (isSelect)
				{
					return (null, null);
				}
				throw new InvalidOperationException($"The relationship property '{entityExpression.Member.Name}' is invalid.");
			}
			var relationship = defaultCustomAttribute.Relationship;
			var q = CreateQuery(isSelect ? entityExpression.Type : entityExpression.Type.GetGenericArguments()[0]);
			return (q, relationship);
		}

		private (string parameterName, Expression Body) GetMethodCallBody(MethodCallExpression mce)
		{
			if (mce.Arguments.Count <= 1)
			{
				return (null, null);
			}

			var firstArgument = (UnaryExpression)mce.Arguments[1];
			var operand = (LambdaExpression)firstArgument.Operand;
			return (operand.Parameters[0].Name, operand.Body);
		}

		private string TranslateExpressionToAttributeName(Expression exp)
		{
			switch (exp)
			{
				case MethodCallExpression methodCallExpression:
					var attributeName = TranslateExpressionToValue(methodCallExpression.Method.IsStatic
						? methodCallExpression.Arguments[1]
						: methodCallExpression.Arguments[0]);
					return (string)attributeName;
				case MemberExpression memberExpression:
					if (memberExpression.Expression is MemberExpression expression1)
					{
						var defaultCustomAttribute = expression1.Member.GetFirstOrDefaultCustomAttribute<AttributeLogicalNameAttribute>();
						if (defaultCustomAttribute != null)
						{
							return defaultCustomAttribute.LogicalName;
						}
					}
					else if (memberExpression.Expression is ParameterExpression expression2 && memberExpression.Member.Name == "Id" && IsStaticEntity(expression2.Type))
					{
						var defaultCustomAttribute = expression2.Type.GetProperty("Id").GetFirstOrDefaultCustomAttribute<AttributeLogicalNameAttribute>();
						if (defaultCustomAttribute != null)
						{
							return defaultCustomAttribute.LogicalName;
						}
					}
					return memberExpression.Member.GetLogicalName();
			}
			throw new InvalidOperationException("Cannot determine the attribute name.");
		}

		private bool IsEnumerableEntity(Type type)
		{
			if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(IEnumerable<>))
			{
				return false;
			}

			var genericArguments = type.GetGenericArguments();
			return genericArguments.Length == 1 && IsEntity(genericArguments[0]);
		}

		private static bool IsAnonymousType(Type type)
		{
			return 
				type.GetCustomAttributes(typeof (CompilerGeneratedAttribute), false).Any() && 
				type.Name.Contains("AnonymousType");
		}

		private bool IsEntity(Type type)
		{
			return IsDynamicEntity(type) || IsStaticEntity(type);
		}

		private bool IsDynamicEntity(Type type)
		{
			return type.IsA<Entity>();
		}

		private bool IsStaticEntity(Type type)
		{
			return type.GetLogicalName() != null;
		}

		private Expression FindValidEntityExpression(Expression exp, string operation)
		{
			if (exp is UnaryExpression unaryExpression && (unaryExpression.NodeType == ExpressionType.Convert || unaryExpression.NodeType == ExpressionType.TypeAs))
			{
				return FindValidEntityExpression(unaryExpression.Operand, operation);
			}

			if (exp is NewExpression newExpression && newExpression.Type == typeof(EntityReference) && newExpression.Arguments.Count >= 2)
			{
				return FindValidEntityExpression(newExpression.Arguments[1], operation);
			}

			if (IsEntityExpression(exp))
			{
				return exp;
			}

			switch (exp)
			{
				case MemberExpression memberExpression when _validProperties.Contains(memberExpression.Member.Name):
					return FindValidEntityExpression(memberExpression.Expression, operation);
				case MethodCallExpression methodCallExpression when _validMethods.Contains(methodCallExpression.Method.Name):
					return FindValidEntityExpression(methodCallExpression.Object, operation);
				default:
					throw new NotSupportedException($"Invalid '{operation}' condition. An entity member is invoking an invalid property or method.");
			}
		}

		private Expression FindEntityExpression(Expression exp)
		{
			return exp.FindPreorder(IsEntityExpression);
		}

		private bool IsEntityExpression(Expression e)
		{
			if (e is MethodCallExpression methodCallExpression)
			{
				if (methodCallExpression.Object != null)
				{
					return IsDynamicEntity(methodCallExpression.Object.Type);
				}

				if (methodCallExpression.Method.IsStatic)
				{
					return IsDynamicEntity(methodCallExpression.Arguments[0].Type);
				}
			}
			else if (e is MemberExpression me)
			{
				return IsEntityMemberExpression(me);
			}

			return false;
		}

		private bool IsEntityMemberExpression(MemberExpression me)
		{
			return IsEntity(me.Member.DeclaringType);
		}

		private MemberExpression GetUnderlyingMemberExpression(Expression exp)
		{
			switch (exp)
			{
				case MemberExpression memberExpression:
					return memberExpression.Expression as MemberExpression;
				case MethodCallExpression methodCallExpression:
					return methodCallExpression.Object as MemberExpression;
				default:
					throw new InvalidOperationException($"The expression '{exp}' must be a '{typeof(MemberExpression)}' or a '{typeof(MethodCallExpression)}'.");
			}
		}

		private string GetUnderlyingParameterExpressionName(Expression exp)
		{
			switch (exp)
			{
				case MemberExpression memberExpression:
					return memberExpression.Expression.ToString();
				case MethodCallExpression methodCallExpression:
					return methodCallExpression.Object.ToString();
				default:
					throw new InvalidOperationException($"The expression '{exp}' must be a '{typeof(MemberExpression)}' or a '{typeof(MethodCallExpression)}'.");
			}
		}

		private object TranslateExpressionToValue(Expression exp, params ParameterExpression[] parameters)
		{
			if (exp is ConstantExpression constantExpression)
			{
				return constantExpression.Value;
			}

			if (exp is MemberExpression memberExpression && memberExpression.Expression is ConstantExpression expression)
			{
				switch (memberExpression.Member)
				{
					case FieldInfo filedMember:
						return GetFieldValue(filedMember, expression.Value);
					case PropertyInfo propertyMember:
						return GetPropertyValue(propertyMember, expression.Value);
				}
			}
			return exp is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Convert ? TranslateExpressionToValue(unaryExpression.Operand) : DynamicInvoke(CompileExpression(Expression.Lambda(exp, parameters)));
		}

		[SecuritySafeCritical]
		private object GetFieldValue(FieldInfo fieldInfo, object target)
		{
			try
			{
				new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
				return fieldInfo.GetValue(target);
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
			}
		}

		[SecuritySafeCritical]
		private object GetPropertyValue(PropertyInfo propertyInfo, object target)
		{
			try
			{
				new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
				return propertyInfo.GetValue(target, null);
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
			}
		}

		private object TranslateExpressionToConditionValue(Expression exp, params ParameterExpression[] parameters)
		{
			var obj = TranslateExpressionToValue(exp, parameters);
			if (obj is DateTime dateTime)
			{
				obj = dateTime.ToString("u", CultureInfo.InvariantCulture);
			}
			else if (obj is EntityReference entityReference)
			{
				obj = entityReference.Id;
			}
			else if (obj is Money money)
			{
				obj = money.Value;
			}
			else if (obj is OptionSetValue optionSetValue)
			{
				obj = optionSetValue.Value;
			}
			else if (obj != null && obj.GetType().IsEnum)
			{
				obj = (int)obj;
			}

			return obj;
		}

		private void TranslateEntityName(QueryExpression qe, Expression expression)
		{
			if (qe.EntityName != null)
			{
				return;
			}

			var constantExpression = expression is MethodCallExpression ? expression.GetMethodsPreorder().Last().Arguments[0] as ConstantExpression : expression as ConstantExpression;
			if (constantExpression?.Value is IEntityQuery entityQuery)
			{
				qe.EntityName = entityQuery.EntityLogicalName;
			}
		}

		private sealed class NavigationSource
		{
			public EntityReference Target { get; }

			public Relationship Relationship { get; }

			public NavigationSource(EntityReference target, Relationship relationship)
			{
				Target = target;
				Relationship = relationship;
			}
		}

		private sealed class FilterExpressionWrapper
		{
			public FilterExpression Filter { get; }

			public string Alias { get; }

			public FilterExpressionWrapper(FilterExpression filter, string alias)
			{
				Filter = filter ?? throw new ArgumentNullException(nameof(filter));
				Alias = alias;
			}
		}

		private sealed class LinkLookup
		{
			public string ParameterName { get; }

			public string Environment { get; }

			public LinkEntity Link { get; }

			public string SelectManyEnvironment { get; }

			public LinkLookup(string parameterName, string environment, LinkEntity link, string selectManyEnvironment = null)
			{
				ParameterName = parameterName;
				Environment = environment;
				Link = link;
				SelectManyEnvironment = selectManyEnvironment;
			}
		}

		private sealed class Projection
		{
			public string MethodName { get; }

			public LambdaExpression Expression { get; }

			public Projection(string methodName, LambdaExpression expression)
			{
				MethodName = methodName;
				Expression = expression;
			}
		}

		private sealed class EntityColumn
		{
			public string ParameterName { get; }

			public string Column { get; }

			public bool AllColumns { get; }

			public EntityColumn() { }

			public EntityColumn(string parameterName, string column)
			{
				ParameterName = parameterName;
				Column = column;
			}

			public EntityColumn(string parameterName, bool allColumns)
			{
				ParameterName = parameterName;
				AllColumns = allColumns;
			}
		}
	}
}
