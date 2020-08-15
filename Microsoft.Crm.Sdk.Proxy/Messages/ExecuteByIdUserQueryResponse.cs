using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.ExecuteByIdUserQueryRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExecuteByIdUserQueryResponse : OrganizationResponse
  {
    /// <summary>Gets the results of the user query (saved view).</summary>
    /// <returns>Type: Returns_StringThe results of the user query (saved view).</returns>
    public string String
    {
      get
      {
        return this.Results.Contains(nameof (String)) ? (string) this.Results[nameof (String)] : (string) null;
      }
    }
  }
}
