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
