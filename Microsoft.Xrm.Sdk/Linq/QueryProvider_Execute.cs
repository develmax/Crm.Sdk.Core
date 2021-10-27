using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Xrm.Sdk.Linq
{
	internal  sealed partial class QueryProvider
	{
		private IEnumerable<TElement> Execute<TElement>(Expression expression)
		{
			NavigationSource source = null;
			var linkLookups = new List<LinkLookup>();
			var query = GetQueryExpression(expression, out var throwIfSequenceIsEmpty, out var throwIfSequenceNotSingle, out var projection, ref source, ref linkLookups);
			return Execute<TElement>(query, throwIfSequenceIsEmpty, throwIfSequenceNotSingle, projection, source, linkLookups);
		}

		private IEnumerable<TElement> Execute<TElement>(QueryExpression qe, bool throwIfSequenceIsEmpty, bool throwIfSequenceNotSingle, Projection projection, NavigationSource source, List<LinkLookup> linkLookups)
		{
			var en = Execute(qe, throwIfSequenceIsEmpty, throwIfSequenceNotSingle, projection, source, linkLookups, out var pagingCookie, out var moreRecords).Cast<TElement>();
			return new PagedItemCollection<TElement>(en, qe, pagingCookie, moreRecords);
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
			return projection != null ? ExecuteAnonymousType(entities, projection, linkLookups) : entities;
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
			}).Select(_param1 => 
				_param1.result == null || !(_param1.result.Id != Guid.Empty) 
					? _param1.__TransparentIdentifier4.element 
					: _param1.result
					);
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

		private static string ResetPagingNumber(string pagingCookie, int newPage)
		{
			if (string.IsNullOrEmpty(pagingCookie))
			{
				return pagingCookie;
			}

			return PagingCookieHelper.ToPagingCookie(PagingCookieHelper.ToContinuationToken(pagingCookie, newPage), out _);
		}

		private static bool IsPagingCookieNull(EntityCollection entityCollection)
		{
			return entityCollection != null && string.IsNullOrEmpty(entityCollection.PagingCookie);
		}

		private int RetrievalUpperLimitWithoutPagingCookie => 5000;

	}
}
