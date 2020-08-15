using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve a list of language packs that are installed on the server that have been disabled.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveDeprovisionedLanguagesRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveDeprovisionedLanguagesRequest"></see> class.</summary>
    public RetrieveDeprovisionedLanguagesRequest()
    {
      this.RequestName = "RetrieveDeprovisionedLanguages";
    }
  }
}
