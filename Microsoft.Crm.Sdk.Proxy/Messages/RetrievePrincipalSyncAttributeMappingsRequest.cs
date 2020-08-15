using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrievePrincipalSyncAttributeMappingsRequest : OrganizationRequest
  {
    public EntityReference Principal
    {
      get
      {
        return this.Parameters.Contains(nameof (Principal)) ? (EntityReference) this.Parameters[nameof (Principal)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Principal)] = (object) value;
      }
    }

    public RetrievePrincipalSyncAttributeMappingsRequest()
    {
      this.RequestName = "RetrievePrincipalSyncAttributeMappings";
      this.Principal = (EntityReference) null;
    }
  }
}
