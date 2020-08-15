using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to add an item to a campaign activity.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddItemCampaignActivityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the campaign activity. Required.</summary>
    /// <returns>Type:  Returns_GuidThe ID of the campaign activity.</returns>
    public Guid CampaignActivityId
    {
      get
      {
        return this.Parameters.Contains(nameof (CampaignActivityId)) ? (Guid) this.Parameters[nameof (CampaignActivityId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (CampaignActivityId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the item to be added to the campaign activity. Required.</summary>
    /// <returns>Type:  Returns_GuidThe ID of the item to be added to the campaign activity.</returns>
    public Guid ItemId
    {
      get
      {
        return this.Parameters.Contains(nameof (ItemId)) ? (Guid) this.Parameters[nameof (ItemId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ItemId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the name of the entity type that is used in the operation. Required.</summary>
    /// <returns>Type:  Returns_StringThe name of the entity type that is used in the operation.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AddItemCampaignActivityRequest"></see> class.</summary>
    public AddItemCampaignActivityRequest()
    {
      this.RequestName = "AddItemCampaignActivity";
      this.CampaignActivityId = new Guid();
      this.ItemId = new Guid();
      this.EntityName = (string) null;
    }
  }
}
