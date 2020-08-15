using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to grant a security principal (user or team) access to the specified record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GrantAccessRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the entity that is the target of the request to grant access. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The entity reference to the record that is the target of the request to grant access. This property value must be an entity reference for an entity that supports this message. For a list of supported entity types, see <see cref="T:Microsoft.Crm.Sdk.Messages.GrantAccessRequest"></see>.</returns>
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

    /// <summary>Gets or sets the team or user that is granted access to the specified record. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.PrincipalAccess"></see>The team or user that is granted access to the target record.</returns>
    public PrincipalAccess PrincipalAccess
    {
      get
      {
        return this.Parameters.Contains(nameof (PrincipalAccess)) ? (PrincipalAccess) this.Parameters[nameof (PrincipalAccess)] : (PrincipalAccess) null;
      }
      set
      {
        this.Parameters[nameof (PrincipalAccess)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.GrantAccessRequest"></see> class.</summary>
    public GrantAccessRequest()
    {
      this.RequestName = "GrantAccess";
      this.Target = (EntityReference) null;
      this.PrincipalAccess = (PrincipalAccess) null;
    }
  }
}
