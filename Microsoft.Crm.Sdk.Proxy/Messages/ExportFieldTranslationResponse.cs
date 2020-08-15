using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExportFieldTranslationResponse : OrganizationResponse
  {
    /// <returns>Returns <see cref="T:System.Byte"></see>.</returns>
    public byte[] ExportTranslationFile
    {
      get
      {
        return this.Results.Contains(nameof (ExportTranslationFile)) ? (byte[]) this.Results[nameof (ExportTranslationFile)] : (byte[]) null;
      }
    }
  }
}
