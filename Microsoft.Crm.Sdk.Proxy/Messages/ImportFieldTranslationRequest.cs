using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to import translations from a compressed file.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ImportFieldTranslationRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the compressed translations file. Required.</summary>
    /// <returns>Type: Returns_Byte[] The compressed translations file.</returns>
    public byte[] TranslationFile
    {
      get
      {
        return this.Parameters.Contains(nameof (TranslationFile)) ? (byte[]) this.Parameters[nameof (TranslationFile)] : (byte[]) null;
      }
      set
      {
        this.Parameters[nameof (TranslationFile)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ImportFieldTranslationRequest"></see> class</summary>
    public ImportFieldTranslationRequest()
    {
      this.RequestName = "ImportFieldTranslation";
      this.TranslationFile = (byte[]) null;
    }
  }
}
