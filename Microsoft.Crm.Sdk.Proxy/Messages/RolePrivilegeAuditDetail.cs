// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RolePrivilegeAuditDetail
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

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
