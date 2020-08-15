using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the resources that are used by an organization.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveOrganizationResourcesRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveOrganizationResourcesRequest"></see> class.</summary>
    public RetrieveOrganizationResourcesRequest()
    {
      this.RequestName = "RetrieveOrganizationResources";
    }
  }
}
