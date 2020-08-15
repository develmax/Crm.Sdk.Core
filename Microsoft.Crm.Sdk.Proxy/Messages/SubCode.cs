using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the possible values for a subcode, used in scheduling appointments.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum SubCode
  {
    /// <summary>Specifies free time with no specified restrictions. Value = 0.</summary>
    [EnumMember] Unspecified,
    /// <summary>A schedulable block of time. Value = 1.</summary>
    [EnumMember] Schedulable,
    /// <summary>A block of time that is committed to perform an action. Value = 2.</summary>
    [EnumMember] Committed,
    /// <summary>A block of time that is tentatively scheduled but not committed. Value = 3.</summary>
    [EnumMember] Uncommitted,
    /// <summary>A block of time that cannot be committed due to a scheduled break. Value = 4.</summary>
    [EnumMember] Break,
    /// <summary>A block of time that cannot be scheduled due to a scheduled holiday. Value = 5.</summary>
    [EnumMember] Holiday,
    /// <summary>A block of time that cannot be scheduled due to a scheduled vacation. Value = 6.</summary>
    [EnumMember] Vacation,
    /// <summary>A block of time that is already scheduled for an appointment. Value = 7.</summary>
    [EnumMember] Appointment,
    /// <summary>Specifies to filter a resource start time. Value = 8.</summary>
    [EnumMember] ResourceStartTime,
    /// <summary>A restriction for a resource for the specified service. Value = 9.</summary>
    [EnumMember] ResourceServiceRestriction,
    /// <summary>Specifies the capacity of a resource for the specified time interval. Value = 10.</summary>
    [EnumMember] ResourceCapacity,
    /// <summary>Specifies that a service is restricted during the specified block of time. Value = 11.</summary>
    [EnumMember] ServiceRestriction,
    /// <summary>An override to the service cost for the specified time block. Value = 12.</summary>
    [EnumMember] ServiceCost,
  }
}
