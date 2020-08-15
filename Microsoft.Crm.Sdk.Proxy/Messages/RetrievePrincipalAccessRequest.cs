using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the access rights of the specified security principal (team or user) to the specified record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrievePrincipalAccessRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target record for which to retrieve access rights.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target record for which to retrieve access rights. This must be an entity reference for an entity that supports this message. For a list of supported entity types, see <see cref="T:Microsoft.Crm.Sdk.Messages.RetrievePrincipalAccessRequest"></see>.</returns>
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

    /// <summary>Gets or sets the security principal (team or user) for which to return the access rights to the specified record.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The security principal (team or user) for which to return the access rights to the specified record. The entity reference must be a SystemUser or Team entity.</returns>
    public EntityReference Principal
    {
      get
      {
        return this.Parameters.Contains(nameof (Principal)) ? (EntityReference) this.Parameters[nameof (Principal)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Principal)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrievePrincipalAccessRequest"></see> class.</summary>
    public RetrievePrincipalAccessRequest()
    {
      this.RequestName = "RetrievePrincipalAccess";
      this.Target = (EntityReference) null;
      this.Principal = (EntityReference) null;
    }
  }
}
