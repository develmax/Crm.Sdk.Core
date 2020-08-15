using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the version of an installed language pack.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveInstalledLanguagePackVersionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the value that represents the locale ID for the language pack. Required.</summary>
    /// <returns>Type: Returns_Int32The value that represents the locale ID for the language pack. Required.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveInstalledLanguagePackVersionRequest"></see> class.</summary>
    public RetrieveInstalledLanguagePackVersionRequest()
    {
      this.RequestName = "RetrieveInstalledLanguagePackVersion";
      this.Language = 0;
    }
  }
}
