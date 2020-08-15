using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the type of license for a deployment of pn_microsoftcrm.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveDeploymentLicenseTypeRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveDeploymentLicenseTypeRequest"></see> class.</summary>
    public RetrieveDeploymentLicenseTypeRequest()
    {
      this.RequestName = "RetrieveDeploymentLicenseType";
    }
  }
}
