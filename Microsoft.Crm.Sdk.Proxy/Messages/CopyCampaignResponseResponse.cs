using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.CopyCampaignResponseRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CopyCampaignResponseResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the newly created campaign response.</summary>
    /// <returns>Type: Returns_GuidThe ID of the newly created campaign response that corresponds to the CampaignResponse.ActivityId attribute, which is the primary key for the CampaignResponse entity.</returns>
    public Guid CampaignResponseId
    {
      get
      {
        return this.Results.Contains(nameof (CampaignResponseId)) ? (Guid) this.Results[nameof (CampaignResponseId)] : new Guid();
      }
    }
  }
}
