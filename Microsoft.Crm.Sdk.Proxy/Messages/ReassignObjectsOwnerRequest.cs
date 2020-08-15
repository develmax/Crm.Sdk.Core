using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  reassign all records that are owned by the security principal (user or team) to another security principal (user or team).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ReassignObjectsOwnerRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the security principal (user or team) for which to reassign all records.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The security principal (user or team) for which to reassign all records. This must be an entity reference for the SystemUser entity or Team entity.</returns>
    public EntityReference FromPrincipal
    {
      get
      {
        return this.Parameters.Contains(nameof (FromPrincipal)) ? (EntityReference) this.Parameters[nameof (FromPrincipal)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (FromPrincipal)] = (object) value;
      }
    }

    /// <summary>Gets or sets the security principal (user or team) that will be the new owner for the records.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The security principal (user or team) that will be the new owner for the records. This must be an entity reference for the SystemUser entity or Team entity.</returns>
    public EntityReference ToPrincipal
    {
      get
      {
        return this.Parameters.Contains(nameof (ToPrincipal)) ? (EntityReference) this.Parameters[nameof (ToPrincipal)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (ToPrincipal)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ReassignObjectsOwnerRequest"></see>  class.</summary>
    public ReassignObjectsOwnerRequest()
    {
      this.RequestName = "ReassignObjectsOwner";
      this.FromPrincipal = (EntityReference) null;
      this.ToPrincipal = (EntityReference) null;
    }
  }
}
