// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RemoveItemCampaignActivityRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  remove an item from a campaign activity.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RemoveItemCampaignActivityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the campaign activity. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the campaign activity. This corresponds to the CampaignActivity.ActivityId attribute, which is the primary key for the CamaignActivity entity.</returns>
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

    /// <summary>Gets or sets the ID of the item to be removed from the campaign activity. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the item to be removed from the campaign activity. This corresponds to the CampaignActivityItem.CampaignActivityItemId property, which is the primary key for the CampaignActivityItem intersect entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RemoveItemCampaignActivityRequest"></see> class.</summary>
    public RemoveItemCampaignActivityRequest()
    {
      this.RequestName = "RemoveItemCampaignActivity";
      this.CampaignActivityId = new Guid();
      this.ItemId = new Guid();
    }
  }
}
