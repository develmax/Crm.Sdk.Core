using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to replace the access rights on the target record for the specified security principal (user or team).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RevokeAccessRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target record for which you want to revoke access.  Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target record for which you want to revoke access. This property value must be an entity reference for an entity that supports this message. For a list of supported entity types, see the <see cref="T:Microsoft.Crm.Sdk.Messages.RevokeAccessRequest"></see> class.</returns>
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

    /// <summary>Gets or sets a security principal (team or user) whose access you want to revoke. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The security principal (team or user) whose access you want to revoke.</returns>
    public EntityReference Revokee
    {
      get
      {
        return this.Parameters.Contains(nameof (Revokee)) ? (EntityReference) this.Parameters[nameof (Revokee)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Revokee)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RevokeAccessRequest"></see> class.</summary>
    public RevokeAccessRequest()
    {
      this.RequestName = "RevokeAccess";
      this.Target = (EntityReference) null;
      this.Revokee = (EntityReference) null;
    }
  }
}
