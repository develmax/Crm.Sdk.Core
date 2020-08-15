using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Represents audited changes to the privileges of a security role.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RolePrivilegeAuditDetail : AuditDetail
  {
    private DataCollection<Guid> _invalidNewPrivileges;

    /// <summary>Gets or sets the role’s old privileges.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.RolePrivilege"></see>The old privileges for the role.</returns>
    [DataMember]
    public RolePrivilege[] OldRolePrivileges { get; set; }

    /// <summary>Gets or sets the role’s new privileges.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.RolePrivilege"></see>The new privileges for the role.</returns>
    [DataMember]
    public RolePrivilege[] NewRolePrivileges { get; set; }

    /// <summary>Gets the collection of invalid privileges for the role.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;Returns_Guid&gt;The collection of invalid privileges for the role.</returns>
    [DataMember]
    public DataCollection<Guid> InvalidNewPrivileges
    {
      get
      {
        if (this._invalidNewPrivileges == null)
          this._invalidNewPrivileges = new DataCollection<Guid>();
        return this._invalidNewPrivileges;
      }
    }
  }
}
