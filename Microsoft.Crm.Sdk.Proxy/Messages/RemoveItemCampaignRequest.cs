// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RemoveItemCampaignRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  remove an item from a campaign.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RemoveItemCampaignRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the campaign. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the campaign. This corresponds to the Campaign.CampaignId attribute, which is the primary key for the Camaign entity.</returns>
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

    /// <summary>Gets or sets the ID of the item to be removed from the campaign. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the item to be removed from the campaign. This corresponds to the CampaignItem.CampaignItemId property, which is the primary key for the CampaignItem intersect entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RemoveItemCampaignRequest"></see> class.</summary>
    public RemoveItemCampaignRequest()
    {
      this.RequestName = "RemoveItemCampaign";
      this.CampaignId = new Guid();
      this.EntityId = new Guid();
    }
  }
}
