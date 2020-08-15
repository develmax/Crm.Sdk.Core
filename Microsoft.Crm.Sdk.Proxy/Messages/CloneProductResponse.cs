using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.CloneProductRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CloneProductResponse : OrganizationResponse
  {
    /// <summary>Gets the cloned product record.</summary>
    /// <returns>Type <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The cloned product record.</returns>
    public EntityReference ClonedProduct
    {
      get
      {
        return this.Results.Contains(nameof (ClonedProduct)) ? (EntityReference) this.Results[nameof (ClonedProduct)] : (EntityReference) null;
      }
    }
  }
}
