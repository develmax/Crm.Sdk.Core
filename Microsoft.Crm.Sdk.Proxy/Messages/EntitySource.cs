using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Describes which members of a bulk operation to retrieve.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum EntitySource
  {
    /// <summary>Retrieve account entities. Value = 0.</summary>
    [EnumMember] Account,
    /// <summary>Retrieve contact entities. Value = 1.</summary>
    [EnumMember] Contact,
    /// <summary>Retrieve lead entities. Value = 2.</summary>
    [EnumMember] Lead,
    /// <summary>Retrieve all entities. Value = 3.</summary>
    [EnumMember] All,
  }
}
