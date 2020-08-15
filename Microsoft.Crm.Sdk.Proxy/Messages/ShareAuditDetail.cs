using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Represents a shared audit detail record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ShareAuditDetail : AuditDetail
  {
    /// <summary>Gets or sets the security principal (user or team) that shares the audit detail record.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The user or team that shares the record.</returns>
    [DataMember]
    public EntityReference Principal { get; set; }

    /// <summary>Gets or sets the privileges of the user before a change.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.AccessRights"></see>The privileges of the user before a change. </returns>
    [DataMember]
    public AccessRights OldPrivileges { get; set; }

    /// <summary>Gets or sets the privileges of the user after a change.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.AccessRights"></see>The privileges of the user after a change.</returns>
    [DataMember]
    public AccessRights NewPrivileges { get; set; }
  }
}
