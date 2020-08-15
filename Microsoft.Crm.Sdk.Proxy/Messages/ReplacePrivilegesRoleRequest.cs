using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  replace the privilege set of an existing role.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ReplacePrivilegesRoleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the role for which the privileges are to be replaced.</summary>
    /// <returns>Type: Returns_GuidThe ID of the role for which the privileges are to be replaced. This corresponds to the Role.RoleId property, which is the primary key for the Role entity.</returns>
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

    /// <summary>Gets or sets an array that contains the IDs and depths of the privileges that replace the existing privileges.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.RolePrivilege"></see>The array that contains the IDs and depths of the privileges that replace the existing privileges.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ReplacePrivilegesRoleRequest"></see> class.</summary>
    public ReplacePrivilegesRoleRequest()
    {
      this.RequestName = "ReplacePrivilegesRole";
      this.RoleId = new Guid();
      this.Privileges = (RolePrivilege[]) null;
    }
  }
}
