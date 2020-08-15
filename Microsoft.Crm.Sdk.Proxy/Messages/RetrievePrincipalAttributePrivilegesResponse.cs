using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrievePrincipalAttributePrivilegesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrievePrincipalAttributePrivilegesResponse : OrganizationResponse
  {
    /// <summary>Gets the collection of attribute privileges for the security principal (user or team).</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.AttributePrivilegeCollection"></see>The collection of attribute privileges for the security principal (user or team).</returns>
    public AttributePrivilegeCollection AttributePrivileges
    {
      get
      {
        return this.Results.Contains(nameof (AttributePrivileges)) ? (AttributePrivilegeCollection) this.Results[nameof (AttributePrivileges)] : (AttributePrivilegeCollection) null;
      }
    }
  }
}
