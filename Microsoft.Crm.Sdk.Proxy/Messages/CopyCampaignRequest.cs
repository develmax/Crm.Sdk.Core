using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  copy a campaign.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CopyCampaignRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the base campaign to copy from. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the base campaign to copy from that corresponds to the Campaign.CampaignId attribute, which is the primary key for the Campaign entity.</returns>
    public Guid BaseCampaign
    {
      get
      {
        return this.Parameters.Contains(nameof (BaseCampaign)) ? (Guid) this.Parameters[nameof (BaseCampaign)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (BaseCampaign)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether to save the campaign as a template. Required.</summary>
    /// <returns>Type: Returns_Booleantrue to save the campaign as a template; otherwise, false.</returns>
    public bool SaveAsTemplate
    {
      get
      {
        return this.Parameters.Contains(nameof (SaveAsTemplate)) && (bool) this.Parameters[nameof (SaveAsTemplate)];
      }
      set
      {
        this.Parameters[nameof (SaveAsTemplate)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.CopyCampaignRequest"></see> class.</summary>
    public CopyCampaignRequest()
    {
      this.RequestName = "CopyCampaign";
      this.BaseCampaign = new Guid();
      this.SaveAsTemplate = false;
    }
  }
}
