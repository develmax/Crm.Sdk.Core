using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveOrganizationResourcesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveOrganizationResourcesResponse : OrganizationResponse
  {
    /// <summary>Gets the data that describes the resources used by an organization. </summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.OrganizationResources"></see>The data that describes the resources used by an organization.</returns>
    public OrganizationResources OrganizationResources
    {
      get
      {
        return this.Results.Contains(nameof (OrganizationResources)) ? (OrganizationResources) this.Results[nameof (OrganizationResources)] : (OrganizationResources) null;
      }
    }
  }
}
