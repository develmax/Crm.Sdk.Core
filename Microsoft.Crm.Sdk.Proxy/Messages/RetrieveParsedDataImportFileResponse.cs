using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveParsedDataImportFileRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveParsedDataImportFileResponse : OrganizationResponse
  {
    /// <summary>Gets the parsed data.</summary>
    /// <returns>Type: Returns_StringThe parsed data. The returned data has the same column order as the column order in the source file.</returns>
    public string[][] Values
    {
      get
      {
        return this.Results.Contains(nameof (Values)) ? (string[][]) this.Results[nameof (Values)] : (string[][]) null;
      }
    }
  }
}
