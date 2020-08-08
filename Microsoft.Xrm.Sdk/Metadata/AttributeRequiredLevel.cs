using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Describes the requirement level for an attribute.</summary>
    [DataContract(Name = "AttributeRequiredLevel", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum AttributeRequiredLevel
    {
        /// <summary>No requirements are specified. Value = 0.</summary>
        [EnumMember(Value = "None")] None,
        /// <summary>The attribute is required to have a value. Value = 1.</summary>
        [EnumMember(Value = "SystemRequired")] SystemRequired,
        /// <summary>The attribute is required to have a value. Value = 2.</summary>
        [EnumMember(Value = "ApplicationRequired")] ApplicationRequired,
        /// <summary>It is recommended that the attribute has a value. Value = 3.</summary>
        [EnumMember(Value = "Recommended")] Recommended,
    }
}