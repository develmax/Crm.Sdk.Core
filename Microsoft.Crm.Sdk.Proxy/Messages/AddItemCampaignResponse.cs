using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the  <see cref="T:Microsoft.Crm.Sdk.Messages.AddItemCampaignRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddItemCampaignResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the resulting campaign item.</summary>
    /// <returns>Type:  Returns_GuidThe ID of the resulting campaign item.</returns>
    public Guid CampaignItemId
    {
      get
      {
        return this.Results.Contains(nameof (CampaignItemId)) ? (Guid) this.Results[nameof (CampaignItemId)] : new Guid();
      }
    }
  }
}
