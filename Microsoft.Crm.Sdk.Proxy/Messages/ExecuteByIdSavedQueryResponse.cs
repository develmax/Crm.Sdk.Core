using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.ExecuteByIdSavedQueryRequest"></see> class. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExecuteByIdSavedQueryResponse : OrganizationResponse
  {
    /// <summary>Gets the results of the saved query (view).</summary>
    /// <returns>Type: Returns_StringThe the results of the saved query (view).</returns>
    public string String
    {
      get
      {
        return this.Results.Contains(nameof (String)) ? (string) this.Results[nameof (String)] : (string) null;
      }
    }
  }
}
