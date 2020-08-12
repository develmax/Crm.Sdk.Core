using System;
using System.Linq;
using System.Net;

namespace Crm.Sdk.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var _crmUrl = "https://crm.test.ru/";
                var _organizationName = "Org";
                var config = Microsoft.Xrm.Sdk.Client.ServiceConfigurationFactory
                    .CreateConfiguration<Microsoft.Xrm.Sdk.IOrganizationService>(
                        new Uri($"{_crmUrl}{_organizationName}/XRMServices/2011/Organization.svc"));


                var clientCredentials = new System.ServiceModel.Description.ClientCredentials();
                clientCredentials.Windows.ClientCredential.UserName = "crmuser03012";
                clientCredentials.Windows.ClientCredential.Password = "123QWEasd";

                var client = new Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy(config, clientCredentials);
                //client.CallerId = new Guid("5c073647-da06-e611-80f9-005056971789");

                var q = new Microsoft.Xrm.Sdk.Query.QueryExpression("role")
                {
                    ColumnSet = {Columns = {"name", "businessunitid", "roleid"}},
                    Orders =
                    {
                        new Microsoft.Xrm.Sdk.Query.OrderExpression("name", Microsoft.Xrm.Sdk.Query.OrderType.Ascending)
                    },
                    LinkEntities =
                    {
                        new Microsoft.Xrm.Sdk.Query.LinkEntity("role", "systemuserroles", "roleid", "roleid",
                            Microsoft.Xrm.Sdk.Query.JoinOperator.Inner)
                        {
                            LinkEntities =
                            {
                                new Microsoft.Xrm.Sdk.Query.LinkEntity("systemuserroles", "systemuser", "systemuserid",
                                    "systemuserid", Microsoft.Xrm.Sdk.Query.JoinOperator.Inner)
                                {
                                    LinkCriteria =
                                    {
                                        Filters =
                                        {
                                            new Microsoft.Xrm.Sdk.Query.FilterExpression(Microsoft.Xrm.Sdk.Query
                                                .LogicalOperator.And)
                                            {
                                                Conditions =
                                                {
                                                    new Microsoft.Xrm.Sdk.Query.ConditionExpression("systemuserid",
                                                        Microsoft.Xrm.Sdk.Query.ConditionOperator.EqualUserId)
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

                var rq = new Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest()
                {
                    Query = q
                };

                /*var n = new Microsoft.Crm.Sdk.Messages.SetStateRequest
                {
                    EntityMoniker =
                        new Microsoft.Xrm.Sdk.EntityReference("lead", new Guid("c5dc1b6f-1712-e811-8229-005056977311")),
                    State = new Microsoft.Xrm.Sdk.OptionSetValue(0),
                    Status = new Microsoft.Xrm.Sdk.OptionSetValue(100000003)
                };

                var r = client.Execute(n);*/

                var result = client.RetrieveMultiple(q);
                //return result.Entities.Select(i => i.GetAttributeValue<string>("name"));
                foreach (var role in result.Entities)
                {
                    Console.WriteLine(role.GetAttributeValue<string>("name"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press key");
            Console.ReadKey();
        }
    }
}
