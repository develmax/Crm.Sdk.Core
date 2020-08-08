using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>internal</summary>
    [DataContract(Name = "ManagedPropertyType", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum ManagedPropertyType
    {
        /// <summary>internal</summary>
        [EnumMember(Value = "Operation")] Operation,
        /// <summary>internal</summary>
        [EnumMember(Value = "Attribute")] Attribute,
        /// <summary>internal</summary>
        [EnumMember(Value = "CustomEvaluator")] CustomEvaluator,
        /// <summary>internal</summary>
        [EnumMember(Value = "Custom")] Custom,
    }
}