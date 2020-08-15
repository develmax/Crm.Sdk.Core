using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create a copy of the campaign response.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CopyCampaignResponseRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the campaign response to copy from. Required.</summary>
    /// <returns>Type:<see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see> The campaign response to copy from.</returns>
    public EntityReference CampaignResponseId
    {
      get
      {
        return this.Parameters.Contains(nameof (CampaignResponseId)) ? (EntityReference) this.Parameters[nameof (CampaignResponseId)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (CampaignResponseId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.CopyCampaignResponseRequest"></see> class.</summary>
    public CopyCampaignResponseRequest()
    {
      this.RequestName = "CopyCampaignResponse";
      this.CampaignResponseId = (EntityReference) null;
    }
  }
}
