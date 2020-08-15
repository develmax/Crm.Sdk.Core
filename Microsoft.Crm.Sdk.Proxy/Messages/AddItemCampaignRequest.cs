using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary> Contains the data that is needed to add an item to a campaign.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddItemCampaignRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the campaign. Required.</summary>
    /// <returns>Type:  Returns_GuidThe ID of the campaign.</returns>
    public Guid CampaignId
    {
      get
      {
        return this.Parameters.Contains(nameof (CampaignId)) ? (Guid) this.Parameters[nameof (CampaignId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (CampaignId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the record to be added to the campaign. Required.</summary>
    /// <returns>Type:  Returns_GuidThe ID of the record to be added to the campaign.</returns>
    public Guid EntityId
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityId)) ? (Guid) this.Parameters[nameof (EntityId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (EntityId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the name of the type of entity that is used in the operation. Required.</summary>
    /// <returns>Type:  Returns_String The name of the type of entity that is used in the operation.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AddItemCampaignRequest"></see> class.</summary>
    public AddItemCampaignRequest()
    {
      this.RequestName = "AddItemCampaign";
      this.CampaignId = new Guid();
      this.EntityId = new Guid();
      this.EntityName = (string) null;
    }
  }
}
