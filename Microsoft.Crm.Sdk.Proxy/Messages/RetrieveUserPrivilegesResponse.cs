using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveUserPrivilegesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveUserPrivilegesResponse : OrganizationResponse
  {
    /// <summary>Gets an array of privileges that the user holds.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.RolePrivilege"></see> arrayThe array of privileges that the user holds.</returns>
    public RolePrivilege[] RolePrivileges
    {
      get
      {
        return this.Results.Contains(nameof (RolePrivileges)) ? (RolePrivilege[]) this.Results[nameof (RolePrivileges)] : (RolePrivilege[]) null;
      }
    }
  }
}
