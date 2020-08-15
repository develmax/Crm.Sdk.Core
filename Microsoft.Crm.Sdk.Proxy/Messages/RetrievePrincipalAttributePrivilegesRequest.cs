using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieves all the secured attribute privileges a user or team has through direct or indirect (through team membership) associations with the FieldSecurityProfile entity.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrievePrincipalAttributePrivilegesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the security principal (user or team) for which to retrieve attribute privileges. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The security principal (user or team) for which to retrieve attribute privileges. This must be a reference to a SystemUser or Team entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrievePrincipalAttributePrivilegesRequest"></see> class.</summary>
    public RetrievePrincipalAttributePrivilegesRequest()
    {
      this.RequestName = "RetrievePrincipalAttributePrivileges";
      this.Principal = (EntityReference) null;
    }
  }
}
