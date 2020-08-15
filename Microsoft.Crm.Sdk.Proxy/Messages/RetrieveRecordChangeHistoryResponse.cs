using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveRecordChangeHistoryRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveRecordChangeHistoryResponse : OrganizationResponse
  {
    /// <summary>Contains the history of data changes for the target entity. </summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.AuditDetailCollection"></see>The history of data changes for the target entity.</returns>
    public AuditDetailCollection AuditDetailCollection
    {
      get
      {
        return this.Results.Contains(nameof (AuditDetailCollection)) ? (AuditDetailCollection) this.Results[nameof (AuditDetailCollection)] : (AuditDetailCollection) null;
      }
    }
  }
}
