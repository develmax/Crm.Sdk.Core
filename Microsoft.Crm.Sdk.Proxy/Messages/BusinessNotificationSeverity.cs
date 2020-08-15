using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  public enum BusinessNotificationSeverity
  {
    [EnumMember] None,
    [EnumMember] Error,
    [EnumMember] Warning,
    [EnumMember] Information,
    [EnumMember] UserDefined,
  }
}
