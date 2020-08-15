using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveLicenseInfoRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveLicenseInfoResponse : OrganizationResponse
  {
    /// <summary>Gets the number of unused licenses.</summary>
    /// <returns>Type: Returns_Int32The number of unused licenses.</returns>
    public int AvailableCount
    {
      get
      {
        return this.Results.Contains(nameof (AvailableCount)) ? (int) this.Results[nameof (AvailableCount)] : 0;
      }
    }

    /// <summary>Gets the number of licenses that have been granted to users.</summary>
    /// <returns>Type: Returns_Int32The number of licenses that have been granted to users.</returns>
    public int GrantedLicenseCount
    {
      get
      {
        return this.Results.Contains(nameof (GrantedLicenseCount)) ? (int) this.Results[nameof (GrantedLicenseCount)] : 0;
      }
    }
  }
}
