using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest"></see> class and its associated response class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExecuteFetchResponse : OrganizationResponse
  {
    /// <summary>deprecated</summary>
    /// <returns>Type: Returns_String</returns>
    public string FetchXmlResult
    {
      get
      {
        return this.Results.Contains(nameof (FetchXmlResult)) ? (string) this.Results[nameof (FetchXmlResult)] : (string) null;
      }
    }
  }
}
