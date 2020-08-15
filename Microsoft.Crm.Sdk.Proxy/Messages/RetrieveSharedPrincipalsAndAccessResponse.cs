using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveSharedPrincipalsAndAccessRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveSharedPrincipalsAndAccessResponse : OrganizationResponse
  {
    /// <summary>Gets the requested security principals (teams and users) for the specified record.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.PrincipalAccess"></see>The requested security principals (teams and users) for the specified record.</returns>
    public PrincipalAccess[] PrincipalAccesses
    {
      get
      {
        return this.Results.Contains(nameof (PrincipalAccesses)) ? (PrincipalAccess[]) this.Results[nameof (PrincipalAccesses)] : (PrincipalAccess[]) null;
      }
    }
  }
}
