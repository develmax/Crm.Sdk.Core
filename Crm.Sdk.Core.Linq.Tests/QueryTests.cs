using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using Model.For.Test;
using Moq;

namespace Crm.Sdk.Core.Linq.Tests
{
	[TestClass()]
	public class QueryTests
	{
		[TestMethod()]
		public void Create()
		{
			var crm = new Mock<IOrganizationService>();
			//crm
			//	.Setup(s => s.RetrieveMultiple(It.IsAny<QueryBase>()))
			//	.Returns<QueryBase>(q => new EntityCollection());

			var context = new OrganizationServiceContext(crm.Object);

			var query = context.CreateQuery<Contact>();
		}

		[TestMethod()]
		public void Create_ToList()
		{
			var crm = CreateOrganizationService(request => { });

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.ToList();
		}

		[TestMethod()]
		public void Where_ToList()
		{
			var crm = CreateOrganizationService(request => { });

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => true).ToList();

			Assert.AreEqual(0, a.Count);
		}

		private IOrganizationService CreateOrganizationService(Action<OrganizationRequest> action)
		{
			var crm = new Mock<IOrganizationService>();
			crm
				.Setup(s => s.Execute(It.IsAny<OrganizationRequest>()))
				.Returns<OrganizationRequest>(q =>
				{
					action(q);

					var responce = new RetrieveMultipleResponse()
					{
						Results = new ParameterCollection
						{
							{ "EntityCollection", new EntityCollection() }
						}
					};
					return responce;
				});
			return crm.Object;
		}

		[TestMethod()]
		public void Select_ToList()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {Columns = { "firstname" }}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(qe, queryExpression);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Select(x => x.FirstName).ToList();
		}

		[TestMethod()]
		public void Select_1_ToList()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {Columns = { "firstname" }}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(qe, queryExpression);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Select(x => new {x.FirstName}).ToList();
		}

		[TestMethod()]
		public void Where_ToList1()
		{
			var filter = new FilterExpression(LogicalOperator.And)
			{
				Conditions =
				{
					new ConditionExpression("firstname", ConditionOperator.Equal, "test")
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(filter, queryExpression.Criteria);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => x.FirstName == "test").ToList();
		}

		[TestMethod()]
		public void Where_Select_ToList()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {Columns = { "firstname" }},
				Criteria =
				{
					Conditions =
					{
						new ConditionExpression("firstname", ConditionOperator.Equal, "test")
					}
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(qe, queryExpression);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => x.FirstName == "test").Select(x => x.FirstName).ToList();
		}

		[TestMethod()]
		public void Where_Select_new_ToList()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {Columns = { "firstname" }},
				Criteria =
				{
					Conditions =
					{
						new ConditionExpression("firstname", ConditionOperator.Equal, "test")
					}
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(qe, queryExpression);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => x.FirstName == "test").Select(x => new {x.FirstName}).ToList();
		}
		
		[TestMethod()]
		public void Where2_ToList()
		{
			const string nameConstant = "test";

			var filter = new FilterExpression(LogicalOperator.And)
			{
				Conditions =
				{
					new ConditionExpression("firstname", ConditionOperator.Equal, nameConstant)
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(filter, queryExpression.Criteria);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => x.FirstName == nameConstant).ToList();
		}

		[TestMethod()]
		public void Where21_ToList1()
		{
			var filter = new FilterExpression(LogicalOperator.And)
			{
				Conditions =
				{
					new ConditionExpression("firstname", ConditionOperator.Equal, "test")
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(filter, queryExpression.Criteria);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => "test" == x.FirstName).ToList();
		}

		[TestMethod()]
		public void Where22_ToList()
		{
			const string nameConstant = "test";

			var filter = new FilterExpression(LogicalOperator.And)
			{
				Conditions =
				{
					new ConditionExpression("firstname", ConditionOperator.Equal, nameConstant)
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(filter, queryExpression.Criteria);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => nameConstant == x.FirstName).ToList();
		}

		[TestMethod()]
		public void Where3_ToList()
		{
			string name = "test";

			var filter = new FilterExpression(LogicalOperator.And)
			{
				Conditions =
				{
					new ConditionExpression("firstname", ConditionOperator.Equal, name)
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(filter, queryExpression.Criteria);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => x.FirstName == name).ToList();
		}

		[TestMethod()]
		public void Where_3_1_ToList()
		{
			string name = "test";

			var filter = new FilterExpression(LogicalOperator.And)
			{
				Conditions =
				{
					new ConditionExpression("firstname", ConditionOperator.Equal, name)
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(filter, queryExpression.Criteria);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => name == x.FirstName).ToList();
		}

		[TestMethod()]
		public void Where4_ToList()
		{
			var tuple = new Tuple<string>("test");

			var filter = new FilterExpression(LogicalOperator.And)
			{
				Conditions =
				{
					new ConditionExpression("firstname", ConditionOperator.Equal, tuple.Item1)
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(filter, queryExpression.Criteria);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => x.FirstName == tuple.Item1).ToList();
		}

		[TestMethod()]
		public void Where_MoreConditions_OR_ToList()
		{
			var filter = new FilterExpression(LogicalOperator.And)
			{
				Filters =
				{
					new FilterExpression()
					{
						FilterOperator = LogicalOperator.Or,
						Conditions =
						{
							new ConditionExpression("firstname", ConditionOperator.Equal, "test"),
							new ConditionExpression("firstname", ConditionOperator.Equal, "test1")
						}
					}
				}
			};
			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(filter, queryExpression.Criteria);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => x.FirstName == "test" || x.FirstName == "test1").ToList();
		}

		[TestMethod()]
		public void Where_MoreConditions_AND_OR_ToList()
		{
			var filter = new FilterExpression(LogicalOperator.And)
			{

				Filters =
				{
					new FilterExpression()
					{
						Conditions =
						{
							new ConditionExpression("lastname", ConditionOperator.Equal, "test1")
						},
						Filters =
						{
							new FilterExpression(LogicalOperator.Or)
							{
								Conditions =
								{
									new ConditionExpression("firstname", ConditionOperator.Equal, "test"),
									new ConditionExpression("firstname", ConditionOperator.Equal, "test1")
								}
							}
						}
					}
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(filter, queryExpression.Criteria);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => x.LastName == "test1" && (x.FirstName == "test" || x.FirstName == "test1")).ToList();
		}

		[TestMethod()]
		public void Join_Inner_ToList()
		{
			var queryTest = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = true},
				LinkEntities =
				{
					new LinkEntity("contact", "systemuser", "ownerid", "systemuserid", JoinOperator.Inner)
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(queryTest, queryExpression);
			});

			var context = new OrganizationServiceContext(crm);

			var query = 
					from contact in context.CreateQuery<Contact>()
					join user in context.CreateQuery<SystemUser>() on contact.OwnerId equals user.SystemUserId
					select new {contact, user};

			var a = query.ToList();
		}

		[TestMethod()]
		public void Join_Inner_Select_ToList()
		{
			var queryTest = new QueryExpression("contact")
			{
				ColumnSet = {Columns = { "lastname" }},
				LinkEntities =
				{
					new LinkEntity("contact", "systemuser", "ownerid", "systemuserid", JoinOperator.Inner)
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(queryTest, queryExpression);
			});

			var context = new OrganizationServiceContext(crm);

			var query = 
				from contact in context.CreateQuery<Contact>()
				join user in context.CreateQuery<SystemUser>() on contact.OwnerId equals user.SystemUserId
				select contact.LastName;

			var a = query.ToList();
		}
		
		[TestMethod()]
		public void Join_Inner_Select_New_ToList()
		{
			var queryTest = new QueryExpression("contact")
			{
				ColumnSet = {Columns = { "lastname" }},
				LinkEntities =
				{
					new LinkEntity("contact", "systemuser", "ownerid", "systemuserid", JoinOperator.Inner)
				}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(queryTest, queryExpression);
			});

			var context = new OrganizationServiceContext(crm);

			var query = 
				from contact in context.CreateQuery<Contact>()
				join user in context.CreateQuery<SystemUser>() on contact.OwnerId equals user.SystemUserId
				select new {contact.LastName, user.FirstName};

			var a = query.ToList();
		}

		//[TestMethod()]
		//public void Where_MoreConditions_OR_AND_ToList()
		//{
		//	var filter = new FilterExpression(LogicalOperator.Or)
		//	{
		//		Conditions =
		//		{
		//			new ConditionExpression("LastName", ConditionOperator.Equal, "test1")
		//		},
		//		Filters =
		//		{
		//			new FilterExpression(LogicalOperator.And)
		//			{
		//				Conditions =
		//				{
		//					new ConditionExpression("FirstName", ConditionOperator.Equal, "test"),
		//					new ConditionExpression("FirstName", ConditionOperator.Equal, "test1")
		//				}
		//			}
		//		}
		//	};

		//	var crm = new Mock<IOrganizationService>();
		//	crm
		//		.Setup(s => s.RetrieveMultiple(It.IsAny<QueryBase>()))
		//		.Returns<QueryBase>(q =>
		//		{
		//			var q1 = (QueryExpression)q;
		//			Assert.AreEqual("contact", q1.EntityName);

		//			EqualEx.AreEqual(filter, q1.Criteria);

		//			return new EntityCollection();
		//		});

		//	var provider = new QueryProvider(crm.Object, _map, _converters);

		//	var query = new Queryable<Contact>(provider);

		//	var a = query.Where(x => x.LastName == "test1" || (x.FirstName == "test" && x.FirstName == "test1")).ToList();
		//}

		//[TestMethod()]
		//public void Where_MoreConditions_AND_ToList()
		//{
		//	var crm = new Mock<IOrganizationService>();
		//	crm
		//		.Setup(s => s.RetrieveMultiple(It.IsAny<QueryBase>()))
		//		.Returns<QueryBase>(q =>
		//		{
		//			var q1 = (QueryExpression)q;
		//			Assert.AreEqual("contact", q1.EntityName);

		//			Assert.AreEqual(LogicalOperator.And, q1.Criteria.FilterOperator);
		//			Assert.AreEqual(2, q1.Criteria.Conditions.Count);

		//			var condition = q1.Criteria.Conditions[0];
		//			Assert.AreEqual(ConditionOperator.Equal, condition.Operator);
		//			Assert.AreEqual(nameof(Contact.FirstName), condition.AttributeName);
		//			Assert.AreEqual("test", condition.Values[0]);

		//			condition = q1.Criteria.Conditions[1];
		//			Assert.AreEqual(ConditionOperator.Equal, condition.Operator);
		//			Assert.AreEqual(nameof(Contact.LastName), condition.AttributeName);
		//			Assert.AreEqual("test1", condition.Values[0]);

		//			return new EntityCollection();
		//		});

		//	var provider = new QueryProvider(crm.Object, _map, _converters);

		//	var query = new Queryable<Contact>(provider);

		//	var a = query.Where(x => x.FirstName == "test" && x.LastName == "test1").ToList();
		//}

		//[TestMethod()]
		//public void Where_Where_ToList()
		//{
		//	var filter = new FilterExpression(LogicalOperator.And)
		//	{
		//		Conditions =
		//		{
		//			new ConditionExpression("FirstName", ConditionOperator.Equal, "test"),
		//			new ConditionExpression("LastName", ConditionOperator.Equal, "test1")
		//		}
		//	};

		//	var crm = new Mock<IOrganizationService>();
		//	crm
		//		.Setup(s => s.RetrieveMultiple(It.IsAny<QueryBase>()))
		//		.Returns<QueryBase>(q =>
		//		{
		//			var q1 = (QueryExpression)q;
		//			Assert.AreEqual("contact", q1.EntityName);

		//			EqualEx.AreEqual(filter, q1.Criteria);

		//			return new EntityCollection();
		//		});

		//	var provider = new QueryProvider(crm.Object, _map, _converters);

		//	var query = new Queryable<Contact>(provider);

		//	var a = query
		//		.Where(x => x.FirstName == "test")
		//		.Where(x => x.LastName == "test1")
		//		.ToList();
		//}

		//[TestMethod()]
		//public void Where_Where_OR_ToList()
		//{
		//	var filter = new FilterExpression(LogicalOperator.And)
		//	{
		//		Conditions =
		//		{
		//			new ConditionExpression("FirstName", ConditionOperator.Equal, "test"),
		//			new ConditionExpression("LastName", ConditionOperator.Equal, "test1")
		//		}
		//	};

		//	var crm = new Mock<IOrganizationService>();
		//	crm
		//		.Setup(s => s.RetrieveMultiple(It.IsAny<QueryBase>()))
		//		.Returns<QueryBase>(q =>
		//		{
		//			var q1 = (QueryExpression)q;
		//			Assert.AreEqual("contact", q1.EntityName);

		//			EqualEx.AreEqual(filter, q1.Criteria);

		//			return new EntityCollection();
		//		});

		//	var provider = new QueryProvider(crm.Object, _map, _converters);

		//	var query = new Queryable<Contact>(provider);

		//	var a = query
		//		.Where(x => x.FirstName == "test")
		//		.Where(x => x.LastName == "test1")
		//		.ToList();
		//}
	}
}