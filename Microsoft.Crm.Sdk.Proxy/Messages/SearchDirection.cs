using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the possible values for the search direction in an appointment request.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum SearchDirection
  {
    /// <summary>Search forward in the calendar. Value = 0.</summary>
    [EnumMember] Forward,
    /// <summary>Search backward in the calendar. Value = 1.</summary>
    [EnumMember] Backward,
  }
}
