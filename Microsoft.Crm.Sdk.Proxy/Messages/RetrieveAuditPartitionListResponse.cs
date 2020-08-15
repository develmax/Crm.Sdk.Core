using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveAuditPartitionListRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAuditPartitionListResponse : OrganizationResponse
  {
    /// <summary>Gets the collection of audit partition details.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.AuditPartitionDetailCollection"></see>The collection of audit partition details.</returns>
    public AuditPartitionDetailCollection AuditPartitionDetailCollection
    {
      get
      {
        return this.Results.Contains(nameof (AuditPartitionDetailCollection)) ? (AuditPartitionDetailCollection) this.Results[nameof (AuditPartitionDetailCollection)] : (AuditPartitionDetailCollection) null;
      }
    }
  }
}
