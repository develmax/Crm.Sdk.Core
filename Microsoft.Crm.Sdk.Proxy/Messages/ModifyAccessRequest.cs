using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to replace the access rights on the target record for the specified security principal (user or team).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ModifyAccessRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the entity that is the target of the request to modify access. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The entity that is the target of the request to modify access. This must be an entity reference to an entity that supports this message. For a list of supported entity types, see the <see cref="T:Microsoft.Crm.Sdk.Messages.ModifyAccessRequest"></see> class.</returns>
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

    /// <summary>Gets or sets the team or user whose access to the specified record is modified. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.PrincipalAccess"></see>The team or user whose access to the specified record is modified.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ModifyAccessRequest"></see> class.</summary>
    public ModifyAccessRequest()
    {
      this.RequestName = "ModifyAccess";
      this.Target = (EntityReference) null;
      this.PrincipalAccess = (PrincipalAccess) null;
    }
  }
}
