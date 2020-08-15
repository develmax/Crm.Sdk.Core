using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveDeploymentLicenseTypeRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveDeploymentLicenseTypeResponse : OrganizationResponse
  {
    /// <summary>Gets the license type.</summary>
    /// <returns>Type:  Returns_StringThe license type.</returns>
    public string licenseType
    {
      get
      {
        return this.Results.Contains(nameof (licenseType)) ? (string) this.Results[nameof (licenseType)] : (string) null;
      }
    }
  }
}
