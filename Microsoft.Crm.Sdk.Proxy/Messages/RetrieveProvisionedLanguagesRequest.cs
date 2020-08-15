using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the list of provisioned languages. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveProvisionedLanguagesRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the  RetrieveProvisionedLanguagesRequest class</summary>
    public RetrieveProvisionedLanguagesRequest()
    {
      this.RequestName = "RetrieveProvisionedLanguages";
    }
  }
}
