// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.BusinessNotificationParameter
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  public sealed class BusinessNotificationParameter
  {
    /// <returns>Returns <see cref="T:Microsoft.Crm.Sdk.Messages.BusinessNotificationParameterType"></see>.</returns>
    [DataMember]
    public BusinessNotificationParameterType ParameterType { get; set; }

    /// <returns>Returns <see cref="T:System.String"></see>.</returns>
    [DataMember]
    public string Data { get; set; }
  }
}
