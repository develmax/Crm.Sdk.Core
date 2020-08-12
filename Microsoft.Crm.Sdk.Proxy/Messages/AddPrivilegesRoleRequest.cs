// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.AddPrivilegesRoleRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  add a set of existing privileges to an existing role. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddPrivilegesRoleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the role for which you want to add the privileges. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the role for which you want to add the privileges. This corresponds to the Role.RoleId attribute, which is the primary key for the Role entity.</returns>
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

    /// <summary>Gets or sets the IDs and depths of the privileges you want to add. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.RolePrivilege"></see>The IDs and depths of the privileges you want to add.</returns>
    public RolePrivilege[] Privileges
    {
      get
      {
        return this.Parameters.Contains(nameof (Privileges)) ? (RolePrivilege[]) this.Parameters[nameof (Privileges)] : (RolePrivilege[]) null;
      }
      set
      {
        this.Parameters[nameof (Privileges)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.AddPrivilegesRoleRequest"></see> class.</summary>
    public AddPrivilegesRoleRequest()
    {
      this.RequestName = "AddPrivilegesRole";
      this.RoleId = new Guid();
      this.Privileges = (RolePrivilege[]) null;
    }
  }
}
