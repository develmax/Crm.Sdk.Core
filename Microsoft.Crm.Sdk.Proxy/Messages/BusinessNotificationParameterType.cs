using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  public enum BusinessNotificationParameterType
  {
    [EnumMember] None,
    [EnumMember] String,
    [EnumMember] Attribute,
  }
}
