using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Organization;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveCurrentOrganizationResponse : OrganizationResponse
  {
    public OrganizationDetail Detail
    {
      get
      {
        return this.Results.Contains(nameof (Detail)) ? (OrganizationDetail) this.Results[nameof (Detail)] : (OrganizationDetail) null;
      }
    }
  }
}
