// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.SdkMessageFilterAvailability
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

namespace Microsoft.Crm.Sdk
{
  /// <summary>Contains integer values that are used for the SdkMessageFilter.Availability attribute.</summary>
  public static class SdkMessageFilterAvailability
  {
    /// <summary>The message is available only on the server. Value = 0.</summary>
    public const int Server = 0;
    /// <summary>The message is available only on the client. Value = 1.</summary>
    public const int Client = 1;
    /// <summary>The message is available on both connected and disconnected from the server. Value = 2.</summary>
    public const int All = 2;
  }
}
