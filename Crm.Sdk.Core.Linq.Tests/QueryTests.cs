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
		public void ToList()
		{
			var crm = CreateOrganizationService(request => { });

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.ToList();
		}

		[TestMethod()]
		public void Count()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = false},
				PageInfo = {Count = 0, ReturnTotalRecordCount = true}
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

			var a = query.Count();
		}

		[TestMethod()]
		public void FirstOrDefault()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = true},
				PageInfo = {Count = 1, PageNumber = 1}
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

			var a = query.FirstOrDefault();
		}

		[TestMethod()]
		public void OrderBy_ToList()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = true},
				Orders = { new OrderExpression(nameof(Contact.FirstName).ToLower(), OrderType.Ascending) },
				PageInfo = {PageNumber = 1}
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

			var a = query.OrderBy(x => x.FirstName).ToList();
		}

		[TestMethod()]
		public void OrderBy_ThenBy_ToList()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = true},
				Orders =
				{
					new OrderExpression(nameof(Contact.FirstName).ToLower(), OrderType.Ascending),
					new OrderExpression(nameof(Contact.LastName).ToLower(), OrderType.Ascending),
				},
				PageInfo = {PageNumber = 1}
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

			var a = query.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
		}

		[TestMethod()]
		public void OrderByDescending_ToList()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = true},
				Orders = { new OrderExpression(nameof(Contact.FirstName).ToLower(), OrderType.Descending) },
				PageInfo = {PageNumber = 1}
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

			var a = query.OrderByDescending(x => x.FirstName).ToList();
		}

		[TestMethod()]
		public void OrderByDescending_ThenByDescending_ToList()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = true},
				Orders =
				{
					new OrderExpression(nameof(Contact.FirstName).ToLower(), OrderType.Descending),
					new OrderExpression(nameof(Contact.LastName).ToLower(), OrderType.Descending),
				},
				PageInfo = {PageNumber = 1}
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

			var a = query.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName).ToList();
		}

		[TestMethod()]
		public void OrderBy_ThenByDescending_ToList()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = true},
				Orders =
				{
					new OrderExpression(nameof(Contact.FirstName).ToLower(), OrderType.Ascending),
					new OrderExpression(nameof(Contact.LastName).ToLower(), OrderType.Descending),
				},
				PageInfo = {PageNumber = 1}
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

			var a = query.OrderBy(x => x.FirstName).ThenByDescending(x => x.LastName).ToList();
		}

		[TestMethod()]
		public void OrderByDescending_ThenBy_ToList()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = true},
				Orders =
				{
					new OrderExpression(nameof(Contact.FirstName).ToLower(), OrderType.Descending),
					new OrderExpression(nameof(Contact.LastName).ToLower(), OrderType.Ascending),
				},
				PageInfo = {PageNumber = 1}
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

			var a = query.OrderByDescending(x => x.FirstName).ThenBy(x => x.LastName).ToList();
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
		public void Select_Property_ToList()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {Columns = { "firstname" }},
				PageInfo = {PageNumber = 1}
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
		public void Select_New_ToList()
		{
			var qe = new QueryExpression("contact")
			{
				ColumnSet = {Columns = { "firstname" }},
				PageInfo = {PageNumber = 1}
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
		public void Where_Property_ToList()
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
		public void Where_Property_1_ToList()
		{
			var filter = new FilterExpression(LogicalOperator.And)
			{
				Conditions =
				{
					new ConditionExpression("firstname", ConditionOperator.Equal, "test" + "test1")
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

			var a = query.Where(x => x.FirstName == "test" + "test1").ToList();
		}
		
		[TestMethod()]
		public void Where_Property_Contains_ToList()
		{
			var filter = new FilterExpression(LogicalOperator.And)
			{
				Conditions =
				{
					new ConditionExpression("firstname", ConditionOperator.Like, "%test%")
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

			var a = query.Where(x => x.FirstName.Contains("test")).ToList();
		}

		[TestMethod()]
		public void Where_Property_StartsWith_ToList()
		{
			var filter = new FilterExpression(LogicalOperator.And)
			{
				Conditions =
				{
					new ConditionExpression("firstname", ConditionOperator.Like, "test%")
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

			var a = query.Where(x => x.FirstName.StartsWith("test")).ToList();
		}

		[TestMethod()]
		public void Where_Property_EndsWith_ToList()
		{
			var filter = new FilterExpression(LogicalOperator.And)
			{
				Conditions =
				{
					new ConditionExpression("firstname", ConditionOperator.Like, "%test")
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

			var a = query.Where(x => x.FirstName.EndsWith("test")).ToList();
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
				},
				PageInfo = {PageNumber = 1}
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
				},
				PageInfo = {PageNumber = 1}
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
		public void Where_Constant_First_1_ToList()
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
		public void Where_Constant_First_ToList()
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
		public void Where_Property_Second_ToList()
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
					new LinkEntity("contact", "systemuser", "ownerid", "systemuserid", JoinOperator.Inner){Columns = {AllColumns = true}}
				},
				PageInfo = {PageNumber = 1}
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
				},
				PageInfo = {PageNumber = 1}
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
		public void Join_Left_ToList()
		{
			var queryTest = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = true},
				LinkEntities =
				{
					new LinkEntity("contact", "systemuser", "ownerid", "systemuserid", JoinOperator.LeftOuter){Columns = {AllColumns = true}}
				},
				PageInfo = {PageNumber = 1}
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
				join user in context.CreateQuery<SystemUser>() on contact.OwnerId equals user.SystemUserId into us_in
				from userDefault in us_in.DefaultIfEmpty()
				select new {contact, userDefault};

			var a = query.ToList();
		}

		[TestMethod()]
		public void Join_Left_Select_New_ToList()
		{
			var queryTest = new QueryExpression("contact")
			{
				ColumnSet = {Columns = { "lastname" }},
				LinkEntities =
				{
					new LinkEntity("contact", "systemuser", "ownerid", "systemuserid", JoinOperator.LeftOuter) {Columns = {Columns = { "firstname" }}}
				},
				PageInfo = {PageNumber = 1}
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
				join user in context.CreateQuery<SystemUser>() on contact.OwnerId equals user.SystemUserId into us_in
				from userDefault in us_in.DefaultIfEmpty()
				select new {contact.LastName, userDefault.FirstName};

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
					new LinkEntity("contact", "systemuser", "ownerid", "systemuserid", JoinOperator.Inner){Columns = {Columns = { "firstname" }}}
				},
				PageInfo = {PageNumber = 1}
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

		[TestMethod()]
		public void Where_MoreConditions_OR_AND_ToList()
		{
			var queryTest = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = true},
				Criteria =
				{
					Filters =
					{
						new FilterExpression(LogicalOperator.Or)
						{
							Conditions =
							{
								new ConditionExpression("lastname", ConditionOperator.Equal, "test1")
							},
							Filters =
							{
								new FilterExpression(LogicalOperator.And)
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
				},
				PageInfo = {PageNumber = 1}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(queryTest, queryExpression);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => x.LastName == "test1" || (x.FirstName == "test" && x.FirstName == "test1")).ToList();
		}

		[TestMethod()]
		public void Where_MoreConditions_AND_ToList()
		{
			var queryTest = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = true},
				Criteria =
				{
					Filters =
					{
						new FilterExpression(LogicalOperator.And)
						{
							Conditions =
							{
								new ConditionExpression("firstname", ConditionOperator.Equal, "test"),
								new ConditionExpression("lastname", ConditionOperator.Equal, "test1")
							}
						}
					}
				},
				PageInfo = {PageNumber = 1}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(queryTest, queryExpression);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query.Where(x => x.FirstName == "test" && x.LastName == "test1").ToList();
		}

		[TestMethod()]
		public void Where_Where_ToList()
		{
			var queryTest = new QueryExpression("contact")
			{
				ColumnSet = {AllColumns = true},
				Criteria =
				{
					Conditions =
					{
						new ConditionExpression("firstname", ConditionOperator.Equal, "test"),
						new ConditionExpression("lastname", ConditionOperator.Equal, "test1")
					}
				},
				PageInfo = {PageNumber = 1}
			};

			var crm = CreateOrganizationService(request =>
			{
				Assert.AreEqual("RetrieveMultiple", request.RequestName);

				var queryExpression = request.Parameters["Query"] as QueryExpression;
				Assert.IsNotNull(queryExpression);

				EqualEx.AreEqual(queryTest, queryExpression);
			});

			var context = new OrganizationServiceContext(crm);

			var query = context.CreateQuery<Contact>();

			var a = query
				.Where(x => x.FirstName == "test")
				.Where(x => x.LastName == "test1")
				.ToList();
		}
	}
}