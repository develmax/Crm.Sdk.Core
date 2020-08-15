using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ProcessOneMemberBulkOperationResponse : OrganizationResponse
  {
    /// <summary>internal</summary>
    /// <returns>Type: Returns_Int32</returns>
    public int ProcessResult
    {
      get
      {
        return this.Results.Contains(nameof (ProcessResult)) ? (int) this.Results[nameof (ProcessResult)] : 0;
      }
    }
  }
}
