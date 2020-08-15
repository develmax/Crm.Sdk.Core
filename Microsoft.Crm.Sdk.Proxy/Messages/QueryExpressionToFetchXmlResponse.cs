using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.QueryExpressionToFetchXmlRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class QueryExpressionToFetchXmlResponse : OrganizationResponse
  {
    /// <summary>Gets the results of the query conversion.</summary>
    /// <returns>Type: Returns_StringThe results of the query conversion. This returned value conforms to the schema for FetchXML.</returns>
    public string FetchXml
    {
      get
      {
        return this.Results.Contains(nameof (FetchXml)) ? (string) this.Results[nameof (FetchXml)] : (string) null;
      }
    }
  }
}
