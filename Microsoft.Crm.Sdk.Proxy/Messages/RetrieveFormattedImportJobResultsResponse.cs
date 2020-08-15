using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveFormattedImportJobResultsRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveFormattedImportJobResultsResponse : OrganizationResponse
  {
    /// <summary>Gets the formatted results of the import job.</summary>
    /// <returns>Type: Returns_StringThe formatted results of the import job.</returns>
    public string FormattedResults
    {
      get
      {
        return this.Results.Contains(nameof (FormattedResults)) ? (string) this.Results[nameof (FormattedResults)] : (string) null;
      }
    }
  }
}
