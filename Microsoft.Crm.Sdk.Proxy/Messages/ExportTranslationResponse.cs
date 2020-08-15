using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.ExportTranslationRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExportTranslationResponse : OrganizationResponse
  {
    /// <summary>Gets the file that represents the data that is exported for translation.</summary>
    /// <returns>Type: Returns_Byte[]The file that represents the data that is exported for translation.</returns>
    public byte[] ExportTranslationFile
    {
      get
      {
        return this.Results.Contains(nameof (ExportTranslationFile)) ? (byte[]) this.Results[nameof (ExportTranslationFile)] : (byte[]) null;
      }
    }
  }
}
