using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.SearchRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SearchResponse : OrganizationResponse
  {
    /// <summary>Gets the results of the search.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.SearchResults"></see>The results of the search.</returns>
    public SearchResults SearchResults
    {
      get
      {
        return this.Results.Contains(nameof (SearchResults)) ? (SearchResults) this.Results[nameof (SearchResults)] : (SearchResults) null;
      }
    }
  }
}
