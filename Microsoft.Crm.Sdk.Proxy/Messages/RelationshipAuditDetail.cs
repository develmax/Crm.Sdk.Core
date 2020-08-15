using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the audited details of a change in a relationship.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RelationshipAuditDetail : AuditDetail
  {
    private DataCollection<EntityReference> _targetRecords;

    /// <summary>Gets or sets the relationship name before the change occurs.</summary>
    /// <returns>Type: Returns_StringThe relationship name.</returns>
    [DataMember]
    public string RelationshipName { get; set; }

    /// <summary>Provides the collection of relationship records that were added or removed.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>&gt;The collection of records.</returns>
    [DataMember]
    public DataCollection<EntityReference> TargetRecords
    {
      get
      {
        if (this._targetRecords == null)
          this._targetRecords = new DataCollection<EntityReference>();
        return this._targetRecords;
      }
    }
  }
}
