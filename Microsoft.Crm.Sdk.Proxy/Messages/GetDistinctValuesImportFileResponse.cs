using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.GetDistinctValuesImportFileRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetDistinctValuesImportFileResponse : OrganizationResponse
  {
    /// <summary>Gets the distinct values for a column in the source file.</summary>
    /// <returns>Type: Returns_StringThe distinct values for a column in the source file.</returns>
    public string[] Values
    {
      get
      {
        return this.Results.Contains(nameof (Values)) ? (string[]) this.Results[nameof (Values)] : (string[]) null;
      }
    }
  }
}
