using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    /// <summary>An enumeration that specifies the type of deleted metadata to retrieve.</summary>
    [Flags]
    [DataContract(Name = "DeletedMetadataFilters", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
    public enum DeletedMetadataFilters
    {
        /// <summary>Deleted Entity metadata. Value = 1.</summary>
        [EnumMember(Value = "Entity")] Entity = 1,
        /// <summary>Deleted Attribute metadata. Value = 2.</summary>
        [EnumMember(Value = "Attribute")] Attribute = 2,
        /// <summary>Deleted Relationship metadata. Value = 4.</summary>
        [EnumMember(Value = "Relationship")] Relationship = 4,
        /// <summary>Deleted Label metadata. Value = 8.</summary>
        [EnumMember(Value = "Label")] Label = 8,
        /// <summary>Deleted OptionSet metadata. Value = 16.</summary>
        [EnumMember(Value = "OptionSet")] OptionSet = 16, // 0x00000010
        /// <summary>The value used if not set. Equals <see cref="F:Microsoft.Xrm.Sdk.Metadata.Query.DeletedMetadataFilters.Entity"></see></summary>
        Default = Entity, // 0x00000001
        /// <summary>All deleted metadata. Value = 31.</summary>
        All = Default | OptionSet | Label | Relationship | Attribute, // 0x0000001F
    }
}