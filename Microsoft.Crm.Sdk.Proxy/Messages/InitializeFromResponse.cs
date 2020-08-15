using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.InitializeFromRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class InitializeFromResponse : OrganizationResponse
  {
    /// <summary>Gets the initialized instance.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The initialized instance. To create a record, pass this value to the <see cref="M:Microsoft.Xrm.Sdk.IOrganizationService.Create(Microsoft.Xrm.Sdk.Entity)"></see> method or to a <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateRequest"></see> message.</returns>
    public Entity Entity
    {
      get
      {
        return this.Results.Contains(nameof (Entity)) ? (Entity) this.Results[nameof (Entity)] : (Entity) null;
      }
    }
  }
}
