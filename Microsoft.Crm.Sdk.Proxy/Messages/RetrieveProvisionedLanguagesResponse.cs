using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveProvisionedLanguagesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveProvisionedLanguagesResponse : OrganizationResponse
  {
    /// <summary>Gets an array of locale ID values that represent the provisioned languages.</summary>
    /// <returns>Type: Returns_Int32[] An array of locale ID values that represent the provisioned languages..</returns>
    public int[] RetrieveProvisionedLanguages
    {
      get
      {
        return this.Results.Contains(nameof (RetrieveProvisionedLanguages)) ? (int[]) this.Results[nameof (RetrieveProvisionedLanguages)] : (int[]) null;
      }
    }
  }
}
