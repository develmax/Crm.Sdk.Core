using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Organization;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveCurrentOrganizationRequest : OrganizationRequest
  {
    public EndpointAccessType AccessType
    {
      get
      {
        return this.Parameters.Contains(nameof (AccessType)) ? (EndpointAccessType) this.Parameters[nameof (AccessType)] : EndpointAccessType.Default;
      }
      set
      {
        this.Parameters[nameof (AccessType)] = (object) value;
      }
    }

    public RetrieveCurrentOrganizationRequest()
    {
      this.RequestName = "RetrieveCurrentOrganization";
      this.AccessType = EndpointAccessType.Default;
    }
  }
}
