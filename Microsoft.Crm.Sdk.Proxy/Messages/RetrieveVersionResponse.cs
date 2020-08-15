using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveVersionRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveVersionResponse : OrganizationResponse
  {
    /// <summary>Gets the version number of the pn_microsoftcrm_server.</summary>
    /// <returns>Type: Returns_StringThe version number of the pn_microsoftcrm_server.</returns>
    public string Version
    {
      get
      {
        return this.Results.Contains(nameof (Version)) ? (string) this.Results[nameof (Version)] : (string) null;
      }
    }
  }
}
