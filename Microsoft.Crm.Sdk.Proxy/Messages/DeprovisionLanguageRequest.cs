using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  deprovision a language. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class DeprovisionLanguageRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the language to deprovision. Required.</summary>
    /// <returns>Type:  Returns_Int32The language to deprovision. Required.</returns>
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

    /// <summary>constructor_initializes<see cref="T:Microsoft.Crm.Sdk.Messages.DeprovisionLanguageRequest"></see> class</summary>
    public DeprovisionLanguageRequest()
    {
      this.RequestName = "DeprovisionLanguage";
      this.Language = 0;
    }
  }
}
