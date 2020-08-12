// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.TimeCode
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the possible values for a time code, used when querying a schedule.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum TimeCode
  {
    /// <summary>The time is available within the working hours of the resource. Value = 0.</summary>
    [EnumMember] Available,
    /// <summary>The time is committed to an activity. Value = 1.</summary>
    [EnumMember] Busy,
    /// <summary>The time is unavailable. Value = 2.</summary>
    [EnumMember] Unavailable,
    /// <summary>Use additional filters for the time block such as service cost or service start time. Value = 3.</summary>
    [EnumMember] Filter,
  }
}
