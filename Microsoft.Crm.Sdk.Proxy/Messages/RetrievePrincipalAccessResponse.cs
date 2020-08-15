using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrievePrincipalAccessRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrievePrincipalAccessResponse : OrganizationResponse
  {
    /// <summary>Gets the access rights that the security principal (team or user) has to the specified record.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.AccessRights"></see>The access rights that the security principal (team or user) has to the specified record.</returns>
    public AccessRights AccessRights
    {
      get
      {
        return this.Results.Contains(nameof (AccessRights)) ? (AccessRights) this.Results[nameof (AccessRights)] : AccessRights.None;
      }
    }
  }
}
