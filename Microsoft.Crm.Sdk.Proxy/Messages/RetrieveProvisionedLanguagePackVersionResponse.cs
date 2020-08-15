using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveProvisionedLanguagePackVersionRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveProvisionedLanguagePackVersionResponse : OrganizationResponse
  {
    /// <summary>Gets the version number of the installed language pack.</summary>
    /// <returns>Type: Returns_StringThe version number of the installed language pack.</returns>
    public string Version
    {
      get
      {
        return this.Results.Contains(nameof (Version)) ? (string) this.Results[nameof (Version)] : (string) null;
      }
    }
  }
}
