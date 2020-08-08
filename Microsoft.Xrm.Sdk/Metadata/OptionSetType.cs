using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Indicates the type of option set.</summary>
    [DataContract(Name = "OptionSetType", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum OptionSetType
    {
        /// <summary>The option set provides a list of options. Value = 0.</summary>
        [EnumMember(Value = "Picklist")] Picklist,
        /// <summary>The option set represents state options for a <see cref="T:Microsoft.Xrm.Sdk.Metadata.StateAttributeMetadata"></see> attribute. Value = 1.</summary>
        [EnumMember(Value = "State")] State,
        /// <summary>The option set represents status options for a <see cref="T:Microsoft.Xrm.Sdk.Metadata.StatusAttributeMetadata"></see> attribute. Value = 2.</summary>
        [EnumMember(Value = "Status")] Status,
        /// <summary>The option set provides two options for a <see cref="T:Microsoft.Xrm.Sdk.Metadata.BooleanAttributeMetadata"></see> attribute. Value = 3.</summary>
        [EnumMember(Value = "Boolean")] Boolean,
    }
}