using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.GetHeaderColumnsImportFileRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetHeaderColumnsImportFileResponse : OrganizationResponse
  {
    /// <summary>Gets the source file header columns.</summary>
    /// <returns>Type: Returns_StringThe source file header columns.</returns>
    public string[] Columns
    {
      get
      {
        return this.Results.Contains(nameof (Columns)) ? (string[]) this.Results[nameof (Columns)] : (string[]) null;
      }
    }
  }
}
