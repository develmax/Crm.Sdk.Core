using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.FetchXmlToQueryExpressionRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class FetchXmlToQueryExpressionResponse : OrganizationResponse
  {
    /// <summary>Gets the results of the query conversion.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryExpression"></see>The results of the query conversion.</returns>
    public QueryExpression Query
    {
      get
      {
        return this.Results.Contains(nameof (Query)) ? (QueryExpression) this.Results[nameof (Query)] : (QueryExpression) null;
      }
    }
  }
}
