// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.ListMemberType
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

namespace Microsoft.Crm.Sdk
{
  /// <summary>Contains integer flags that are used for the List.MemberType attribute, used to indicate whether a list specifies accounts, contacts, or leads.</summary>
  public static class ListMemberType
  {
    /// <summary>A list of accounts. Value = 1.</summary>
    public const int Account = 1;
    /// <summary>A list of contacts. Value = 2.</summary>
    public const int Contact = 2;
    /// <summary>A list of leads. Value = 4.</summary>
    public const int Lead = 4;
  }
}
