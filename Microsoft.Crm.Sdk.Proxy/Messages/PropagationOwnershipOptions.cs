// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.PropagationOwnershipOptions
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the possible values for propagation ownership options.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum PropagationOwnershipOptions
  {
    /// <summary>There is no change in ownership for the created activities. Value = 0.</summary>
    [EnumMember] None,
    /// <summary>All created activities are assigned to the caller of the API. Value = 1.</summary>
    [EnumMember] Caller,
    /// <summary>Created activities are assigned to respective owners of target members. Value = 2.</summary>
    [EnumMember] ListMemberOwner,
  }
}
