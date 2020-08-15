using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.CopyCampaignRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CopyCampaignResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the newly created campaign.</summary>
    /// <returns>Type: Returns_GuidThe ID of the newly created campaign that corresponds to the Campaign.CampaignId attribute, which is the primary key for the Campaign entity.</returns>
    public Guid CampaignCopyId
    {
      get
      {
        return this.Results.Contains(nameof (CampaignCopyId)) ? (Guid) this.Results[nameof (CampaignCopyId)] : new Guid();
      }
    }
  }
}
