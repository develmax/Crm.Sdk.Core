using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Describes the security type for the relationship.</summary>
    [Flags]
    [DataContract(Name = "SecurityTypes", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum SecurityTypes
    {
        /// <summary>No security privileges are checked during create or update operations. Value = 0.</summary>
        [EnumMember(Value = "None")] None = 0,
        /// <summary>The <see cref="F:Microsoft.Xrm.Sdk.Metadata.PrivilegeType.Append"></see> and <see cref="F:Microsoft.Xrm.Sdk.Metadata.PrivilegeType.AppendTo"></see> privileges are checked for create or update operations. Value = 1.</summary>
        [EnumMember(Value = "Append")] Append = 1,
        /// <summary>Security for the referencing entity record is derived from the referenced entity record. Value = 2.</summary>
        [EnumMember(Value = "ParentChild")] ParentChild = 2,
        /// <summary>Security for the referencing entity record is derived from a pointer record. Value = 4.</summary>
        [EnumMember(Value = "Pointer")] Pointer = 4,
        /// <summary>The referencing entity record inherits security from the referenced security record. Value = 8.</summary>
        [EnumMember(Value = "Inheritance")] Inheritance = 8,
    }
}