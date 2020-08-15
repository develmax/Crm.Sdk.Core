using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveAvailableLanguagesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAvailableLanguagesResponse : OrganizationResponse
  {
    /// <summary>Gets an array of locale ID values representing the language packs that are installed on the server.</summary>
    /// <returns>Type: Returns_Int32[]An array of locale id values representing the language packs that are installed on the server.</returns>
    public int[] LocaleIds
    {
      get
      {
        return this.Results.Contains(nameof (LocaleIds)) ? (int[]) this.Results[nameof (LocaleIds)] : (int[]) null;
      }
    }
  }
}
