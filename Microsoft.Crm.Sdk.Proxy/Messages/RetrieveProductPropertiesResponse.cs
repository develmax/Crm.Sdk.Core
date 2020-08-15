using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveProductPropertiesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveProductPropertiesResponse : OrganizationResponse
  {
    /// <summary>Gets the property instances (dynamic property instances) for a product associated to an opportunity, quote, order, and invoice.</summary>
    /// <returns>Type <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>Property instances (dynamic property instances) for a product associated to an opportunity, quote, order, and invoice.</returns>
    public EntityCollection EntityCollection
    {
      get
      {
        return this.Results.Contains(nameof (EntityCollection)) ? (EntityCollection) this.Results[nameof (EntityCollection)] : (EntityCollection) null;
      }
    }
  }
}
