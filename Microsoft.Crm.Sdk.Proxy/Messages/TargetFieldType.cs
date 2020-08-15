using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Indicates the attribute type for the target of the <see cref="T:Microsoft.Crm.Sdk.Messages.InitializeFromRequest"></see> message.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum TargetFieldType
  {
    /// <summary>Initialize all possible attribute values. Value = 0.</summary>
    [EnumMember] All,
    /// <summary>Initialize the attribute values that are valid for create. Value = 1.</summary>
    [EnumMember] ValidForCreate,
    /// <summary>initialize the attribute values that are valid for update. Value = 2.</summary>
    [EnumMember] ValidForUpdate,
    /// <summary>Initialize the attribute values that are valid for read. Value = 3.</summary>
    [EnumMember] ValidForRead,
  }
}
