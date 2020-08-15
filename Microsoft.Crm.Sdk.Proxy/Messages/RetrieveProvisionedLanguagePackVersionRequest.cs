using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the version of a provisioned language pack. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveProvisionedLanguagePackVersionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the Locale Id for the language. Required.</summary>
    /// <returns>Type: Returns_Int32The Locale Id for the language. Required.</returns>
    public int Language
    {
      get
      {
        return this.Parameters.Contains(nameof (Language)) ? (int) this.Parameters[nameof (Language)] : 0;
      }
      set
      {
        this.Parameters[nameof (Language)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveProvisionedLanguagePackVersionRequest"></see> class</summary>
    public RetrieveProvisionedLanguagePackVersionRequest()
    {
      this.RequestName = "RetrieveProvisionedLanguagePackVersion";
      this.Language = 0;
    }
  }
}
