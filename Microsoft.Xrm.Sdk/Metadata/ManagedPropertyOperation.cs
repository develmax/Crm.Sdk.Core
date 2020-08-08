using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>internal</summary>
    [SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags", Justification = "Working around back-compat issues with enums in WCF")]
    [DataContract(Name = "ManagedPropertyOperation", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum ManagedPropertyOperation
    {
        /// <summary>internal</summary>
        [EnumMember(Value = "None")] None = 0,
        /// <summary>internal</summary>
        [EnumMember(Value = "Create")] Create = 1,
        /// <summary>internal</summary>
        [EnumMember(Value = "Update")] Update = 2,
        /// <summary>internal</summary>
        [EnumMember(Value = "CreateUpdate")] CreateUpdate = 3,
        /// <summary>internal</summary>
        [EnumMember(Value = "Delete")] Delete = 4,
        /// <summary>internal</summary>
        [EnumMember(Value = "UpdateDelete")] UpdateDelete = 6,
        /// <summary>internal</summary>
        [EnumMember(Value = "All")] All = 7,
    }
}