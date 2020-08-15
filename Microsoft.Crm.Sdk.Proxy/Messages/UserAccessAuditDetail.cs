using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class UserAccessAuditDetail : AuditDetail
  {
    /// <summary>internal</summary>
    /// <returns>Type: Returns_Int32</returns>
    [DataMember]
    public int Interval { get; set; }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_DateTime</returns>
    [DataMember]
    public DateTime AccessTime { get; set; }
  }
}
