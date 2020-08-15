using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve all attribute data changes for a specific entity.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveRecordChangeHistoryRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target audit record. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>.</returns>
    public EntityReference Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Gets or sets the paging information for the retrieved data. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.PagingInfo"></see>The paging information for the retrieved data.</returns>
    public PagingInfo PagingInfo
    {
      get
      {
        return this.Parameters.Contains(nameof (PagingInfo)) ? (PagingInfo) this.Parameters[nameof (PagingInfo)] : (PagingInfo) null;
      }
      set
      {
        this.Parameters[nameof (PagingInfo)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveRecordChangeHistoryRequest"></see> class.</summary>
    public RetrieveRecordChangeHistoryRequest()
    {
      this.RequestName = "RetrieveRecordChangeHistory";
      this.Target = (EntityReference) null;
    }
  }
}
