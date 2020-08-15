using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the privileges that are assigned to the specified role.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveRolePrivilegesRoleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the role for which the privileges are to be retrieved.</summary>
    /// <returns>Type: Returns_GuidThe ID of the role for which the privileges are to be retrieved. This corresponds to the Role.RoleId property, which is the primary key for the Role entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveRolePrivilegesRoleRequest"></see> class.</summary>
    public RetrieveRolePrivilegesRoleRequest()
    {
      this.RequestName = "RetrieveRolePrivilegesRole";
      this.RoleId = new Guid();
    }
  }
}
