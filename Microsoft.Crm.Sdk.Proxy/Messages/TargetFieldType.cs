// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.TargetFieldType
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Indicates the attribute type for the target of the <see cref="T:Microsoft.Crm.Sdk.Messages.InitializeFromRequest"></see> message.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum TargetFieldType
  {
    /// <summary>Initialize all possible attribute values. Value = 0.</summary>
    [EnumMember] All,
    /// <summary>Initialize the attribute values that are valid for create. Value = 1.</summary>
    [EnumMember] ValidForCreate,
    /// <summary>initialize the attribute values that are valid for update. Value = 2.</summary>
    [EnumMember] ValidForUpdate,
    /// <summary>Initialize the attribute values that are valid for read. Value = 3.</summary>
    [EnumMember] ValidForRead,
  }
}
