// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.CopyCampaignResponseRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

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
