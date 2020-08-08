using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>internal</summary>
    [DataContract(Name = "ManagedPropertyEvaluationPriority", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum ManagedPropertyEvaluationPriority
    {
        /// <summary>internal</summary>
        [EnumMember(Value = "None")] None,
        /// <summary>internal</summary>
        [EnumMember(Value = "Low")] Low,
        /// <summary>internal</summary>
        [EnumMember(Value = "Normal")] Normal,
        /// <summary>internal</summary>
        [EnumMember(Value = "High")] High,
        /// <summary>internal</summary>
        [EnumMember(Value = "Essential")] Essential,
    }
}