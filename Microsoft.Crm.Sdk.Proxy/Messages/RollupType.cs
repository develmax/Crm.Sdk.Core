using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the possible values for the <see cref="P:Microsoft.Crm.Sdk.Messages.RollupRequest.RollupType"></see> property in the <see cref="T:Microsoft.Crm.Sdk.Messages.RollupRequest"></see> class, which you use to retrieve all the entity records for a specified record. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum RollupType
  {
    /// <summary>A rollup record is not requested. This member only retrieves the records that are directly related to a parent record. Value = 0.</summary>
    [EnumMember] None,
    /// <summary>A rollup record that is directly related to a parent record and to any direct child of a parent record. Value = 1.</summary>
    [EnumMember] Related,
    /// <summary>A rollup record that is directly related to a parent record and to any descendent record of a parent record, for example, children, grandchildren, and great-grandchildren records. Value = 2.</summary>
    [EnumMember] Extended,
  }
}
