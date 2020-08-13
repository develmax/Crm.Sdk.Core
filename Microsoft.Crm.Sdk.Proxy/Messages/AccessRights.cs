using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the possible access rights for a user.</summary>
  [Flags]
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum AccessRights
  {
    /// <summary>No access. Value = 0.</summary>
    [EnumMember] None = 0,
    /// <summary>The right to read the specified type of record. Value = 1.</summary>
    [EnumMember] ReadAccess = 1,
    /// <summary>The right to update the specified record. Value = 2.</summary>
    [EnumMember] WriteAccess = 2,
    /// <summary>The right to append the specified record to another object. Value = 0x10.</summary>
    [EnumMember] AppendAccess = 4,
    /// <summary>The right to append another record to the specified object. Value = 16.</summary>
    [EnumMember] AppendToAccess = 16, // 0x00000010
    /// <summary>The right to create a record. Value = 0x20.</summary>
    [EnumMember] CreateAccess = 32, // 0x00000020
    /// <summary>The right to delete the specified record. Value = 0x10000.</summary>
    [EnumMember] DeleteAccess = 65536, // 0x00010000
    /// <summary>The right to share the specified record. Value = 0x40000.</summary>
    [EnumMember] ShareAccess = 262144, // 0x00040000
    /// <summary>The right to assign the specified record to another user or team. Value = 0x80000.</summary>
    [EnumMember] AssignAccess = 524288, // 0x00080000
  }
}
