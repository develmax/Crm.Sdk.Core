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
