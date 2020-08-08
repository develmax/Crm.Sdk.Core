using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Describes the type of operation for the privilege</summary>
    [DataContract(Name = "PrivilegeType", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum PrivilegeType
    {
        /// <summary>Specifies no privilege. Value = 0.</summary>
        [EnumMember(Value = "None")] None,
        /// <summary>The create privilege. Value = 1.</summary>
        [EnumMember(Value = "Create")] Create,
        /// <summary>The read privilege. Value = 2.</summary>
        [EnumMember(Value = "Read")] Read,
        /// <summary>The write privilege. Value = 3.</summary>
        [EnumMember(Value = "Write")] Write,
        /// <summary>The delete privilege. Value = 4.</summary>
        [EnumMember(Value = "Delete")] Delete,
        /// <summary>The assign privilege. Value = 5.</summary>
        [EnumMember(Value = "Assign")] Assign,
        /// <summary>The share privilege. Value = 6.</summary>
        [EnumMember(Value = "Share")] Share,
        /// <summary>The append privilege. Value = 7.</summary>
        [EnumMember(Value = "Append")] Append,
        /// <summary>The append to privilege. Value = 8.</summary>
        [EnumMember(Value = "AppendTo")] AppendTo,
    }
}