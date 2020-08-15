using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.DeleteAuditDataRequest"></see> class. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class DeleteAuditDataResponse : OrganizationResponse
  {
    /// <summary>Gets the number of deleted audit partitions or the number of deleted Audit records.</summary>
    /// <returns>Type: Returns_Int32The number of deleted audit partitions or records.</returns>
    public int PartitionsDeleted
    {
      get
      {
        return this.Results.Contains(nameof (PartitionsDeleted)) ? (int) this.Results[nameof (PartitionsDeleted)] : 0;
      }
    }
  }
}
