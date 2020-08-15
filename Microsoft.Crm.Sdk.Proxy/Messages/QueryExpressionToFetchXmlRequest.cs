using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  convert a query, which is represented as a QueryExpression class, to its equivalent query, which is represented as FetchXML.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class QueryExpressionToFetchXmlRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the query to convert.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryBase"></see>The query to convert.</returns>
    public QueryBase Query
    {
      get
      {
        return this.Parameters.Contains(nameof (Query)) ? (QueryBase) this.Parameters[nameof (Query)] : (QueryBase) null;
      }
      set
      {
        this.Parameters[nameof (Query)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  the <see cref="T:Microsoft.Crm.Sdk.Messages.QueryExpressionToFetchXmlRequest"></see> class.</summary>
    public QueryExpressionToFetchXmlRequest()
    {
      this.RequestName = "QueryExpressionToFetchXml";
      this.Query = (QueryBase) null;
    }
  }
}
