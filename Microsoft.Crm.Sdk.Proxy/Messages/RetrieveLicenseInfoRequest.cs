using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the number of used and available licenses for a deployment of pn_microsoftcrm.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveLicenseInfoRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the access mode for retrieving the license information.</summary>
    /// <returns>Type: Returns_Int32The access mode for retrieving the license information. Use one of the option set values for SystemUser.AccessMode. For a list of these values, the metadata for this entity. metadata_browser</returns>
    public int AccessMode
    {
      get
      {
        return this.Parameters.Contains(nameof (AccessMode)) ? (int) this.Parameters[nameof (AccessMode)] : 0;
      }
      set
      {
        this.Parameters[nameof (AccessMode)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveLicenseInfoRequest"></see> class.</summary>
    public RetrieveLicenseInfoRequest()
    {
      this.RequestName = "RetrieveLicenseInfo";
      this.AccessMode = 0;
    }
  }
}
