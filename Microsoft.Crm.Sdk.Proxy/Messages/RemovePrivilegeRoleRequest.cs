// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RemovePrivilegeRoleRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  remove a privilege from an existing role.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RemovePrivilegeRoleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the role from which the privilege is to be removed.</summary>
    /// <returns>Type:  Returns_GuidThe ID of the role from which the privilege is to be removed. This corresponds to the Role.RoleId property, which is the primary key for the Role entity.</returns>
    public Guid RoleId
    {
      get
      {
        return this.Parameters.Contains(nameof (RoleId)) ? (Guid) this.Parameters[nameof (RoleId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (RoleId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the privilege that is to be removed from the existing role.</summary>
    /// <returns>Type:  Returns_GuidThe ID of the privilege that is to be removed from the existing role. This corresponds to the Privilege.PrivilegeId property, which is the primary key for the Privilege entity.</returns>
    public Guid PrivilegeId
    {
      get
      {
        return this.Parameters.Contains(nameof (PrivilegeId)) ? (Guid) this.Parameters[nameof (PrivilegeId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (PrivilegeId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RemovePrivilegeRoleRequest"></see> class.</summary>
    public RemovePrivilegeRoleRequest()
    {
      this.RequestName = "RemovePrivilegeRole";
      this.RoleId = new Guid();
      this.PrivilegeId = new Guid();
    }
  }
}
