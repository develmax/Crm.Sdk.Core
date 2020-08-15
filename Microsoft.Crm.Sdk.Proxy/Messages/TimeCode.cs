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
