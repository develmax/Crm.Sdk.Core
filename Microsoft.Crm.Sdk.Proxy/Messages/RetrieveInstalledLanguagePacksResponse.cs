using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveInstalledLanguagePacksRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveInstalledLanguagePacksResponse : OrganizationResponse
  {
    /// <summary>Gets an array of locale ID values that represent the installed language packs.</summary>
    /// <returns>Type: Returns_Int32[]An array of locale ID values that represent the installed language packs.</returns>
    public int[] RetrieveInstalledLanguagePacks
    {
      get
      {
        return this.Results.Contains(nameof (RetrieveInstalledLanguagePacks)) ? (int[]) this.Results[nameof (RetrieveInstalledLanguagePacks)] : (int[]) null;
      }
    }
  }
}
