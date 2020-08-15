using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the default price level (price list) for the current user based on the user’s territory relationship with the price list. If a user territory is part of multiple price levels (price lists), this message will retrieve all those price levels (price lists). This message will return results only if the Organization.UseInbuiltRuleForDefaultPriceSelectionRule attribute is set to 0 (false).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetDefaultPriceLevelRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the logical entity name.</summary>
    /// <returns>Returns <see cref="T:System.String"></see>The logical entity name.</returns>
    public string EntityName
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityName)) ? (string) this.Parameters[nameof (EntityName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (EntityName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.GetDefaultPriceLevelRequest"></see> class.</summary>
    public GetDefaultPriceLevelRequest()
    {
      this.RequestName = "GetDefaultPriceLevel";
      this.EntityName = (string) null;
    }
  }
}
