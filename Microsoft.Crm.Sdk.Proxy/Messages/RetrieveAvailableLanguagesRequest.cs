using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the list of language packs that are installed and enabled on the server.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAvailableLanguagesRequest : OrganizationRequest
  {
    /// <summary>constructor_initializes<see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveAvailableLanguagesRequest"></see> class.</summary>
    public RetrieveAvailableLanguagesRequest()
    {
      this.RequestName = "RetrieveAvailableLanguages";
    }
  }
}
