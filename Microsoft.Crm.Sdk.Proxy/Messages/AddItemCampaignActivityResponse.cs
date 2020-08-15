using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.AddItemCampaignActivityRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddItemCampaignActivityResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the resulting campaign activity item.</summary>
    /// <returns>Type: Returns_GuidThe ID of the resulting campaign activity item.</returns>
    public Guid CampaignActivityItemId
    {
      get
      {
        return this.Results.Contains(nameof (CampaignActivityItemId)) ? (Guid) this.Results[nameof (CampaignActivityItemId)] : new Guid();
      }
    }
  }
}
