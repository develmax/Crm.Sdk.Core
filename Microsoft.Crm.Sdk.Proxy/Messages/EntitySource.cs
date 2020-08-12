// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.EntitySource
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Describes which members of a bulk operation to retrieve.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum EntitySource
  {
    /// <summary>Retrieve account entities. Value = 0.</summary>
    [EnumMember] Account,
    /// <summary>Retrieve contact entities. Value = 1.</summary>
    [EnumMember] Contact,
    /// <summary>Retrieve lead entities. Value = 2.</summary>
    [EnumMember] Lead,
    /// <summary>Retrieve all entities. Value = 3.</summary>
    [EnumMember] All,
  }
}
