using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveDeprovisionedLanguagesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveDeprovisionedLanguagesResponse : OrganizationResponse
  {
    /// <summary>Gets an array of locale ID values representing disabled language packs that are installed on the server.</summary>
    /// <returns>Type: Returns_Int32[]An array of locale ID values representing disabled language packs that are installed on the server.</returns>
    public int[] RetrieveDeprovisionedLanguages
    {
      get
      {
        return this.Results.Contains(nameof (RetrieveDeprovisionedLanguages)) ? (int[]) this.Results[nameof (RetrieveDeprovisionedLanguages)] : (int[]) null;
      }
    }
  }
}
