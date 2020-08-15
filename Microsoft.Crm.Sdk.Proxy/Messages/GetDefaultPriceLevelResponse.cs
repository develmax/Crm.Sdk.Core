using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.GetDefaultPriceLevelRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetDefaultPriceLevelResponse : OrganizationResponse
  {
    /// <summary>Gets the price level (price list) for the current user. If a user territory is part of multiple price levels (price lists), gets multiple price levels (price lists).</summary>
    /// <returns>Returns <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The resulting price level, which is an instance of the PriceLevel class.</returns>
    public EntityCollection PriceLevels
    {
      get
      {
        return this.Results.Contains(nameof (PriceLevels)) ? (EntityCollection) this.Results[nameof (PriceLevels)] : (EntityCollection) null;
      }
    }
  }
}
