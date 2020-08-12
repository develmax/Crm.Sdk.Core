// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RibbonLocationFilters
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the values for ribbon filters for an entity.</summary>
  [Flags]
  [DataContract(Name = "RibbonLocationFilters", Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum RibbonLocationFilters
  {
    /// <summary>Retrieve just the form ribbon. Value = 1.</summary>
    [EnumMember(Value = "Form")] Form = 1,
    /// <summary>Retrieve just the ribbon displayed for entity grids. Value = 2.</summary>
    [EnumMember(Value = "HomepageGrid")] HomepageGrid = 2,
    /// <summary>Retrieve just the ribbon displayed when the entity is displayed in a subgrid or associated view. Value = 4.</summary>
    [EnumMember(Value = "SubGrid")] SubGrid = 4,
    /// <summary>Retrieve all Ribbons. Equivalent to Default. Value = 7.</summary>
    All = SubGrid | HomepageGrid | Form, // 0x00000007
    /// <summary>Retrieve all Ribbons. Equivalent to All. Value = 7.</summary>
    Default = All, // 0x00000007
  }
}
