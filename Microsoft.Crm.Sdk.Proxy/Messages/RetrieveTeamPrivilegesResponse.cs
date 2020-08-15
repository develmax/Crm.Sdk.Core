using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveTeamPrivilegesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveTeamPrivilegesResponse : OrganizationResponse
  {
    /// <summary>Gets the list of privileges that the team holds for a record.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.RolePrivilege"></see> array. The list of privileges that the team holds for a record.</returns>
    public RolePrivilege[] RolePrivileges
    {
      get
      {
        return this.Results.Contains(nameof (RolePrivileges)) ? (RolePrivilege[]) this.Results[nameof (RolePrivileges)] : (RolePrivilege[]) null;
      }
    }
  }
}
