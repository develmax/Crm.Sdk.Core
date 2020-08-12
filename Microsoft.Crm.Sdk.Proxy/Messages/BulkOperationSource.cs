// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.BulkOperationSource
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the possible sources of a bulk operation.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum BulkOperationSource
  {
    /// <summary>The bulk operation is to distribute a quick campaign to members of a list of accounts, contacts, or leads that are selected by a query. Value = 0.</summary>
    [EnumMember] QuickCampaign,
    /// <summary>The bulk operation is for distributing a campaign activity to members of a list. Value = 1.</summary>
    [EnumMember] CampaignActivity,
  }
}
