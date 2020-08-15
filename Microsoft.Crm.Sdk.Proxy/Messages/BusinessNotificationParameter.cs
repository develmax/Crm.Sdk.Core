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
