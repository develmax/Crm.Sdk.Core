using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the list of database partitions that are used to store audited history data.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAuditPartitionListRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveAuditPartitionListRequest"></see> class.</summary>
    public RetrieveAuditPartitionListRequest()
    {
      this.RequestName = "RetrieveAuditPartitionList";
    }
  }
}
