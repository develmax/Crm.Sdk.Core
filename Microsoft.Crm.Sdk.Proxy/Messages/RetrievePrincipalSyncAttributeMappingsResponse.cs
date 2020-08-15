using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrievePrincipalSyncAttributeMappingsResponse : OrganizationResponse
  {
    public AttributeMappingCollection AttributeMappings
    {
      get
      {
        return this.Results.Contains(nameof (AttributeMappings)) ? (AttributeMappingCollection) this.Results[nameof (AttributeMappings)] : (AttributeMappingCollection) null;
      }
    }
  }
}
