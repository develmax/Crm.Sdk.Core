using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    /// <summary>Describes the type of comparison for two values in a metadata condition expression. </summary>
    [DataContract(Name = "MetadataConditionOperator", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
    public enum MetadataConditionOperator
    {
        /// <summary>The values are compared for equality. Value = 0.</summary>
        [EnumMember(Value = "Equals")] Equals,
        /// <summary>The two values are not equal. Value = 1.</summary>
        [EnumMember(Value = "NotEquals")] NotEquals,
        /// <summary>The value exists in a list of values. Value = 2.</summary>
        [EnumMember(Value = "In")] In,
        /// <summary>The given value is not matched to a value in a list. Value = 3.</summary>
        [EnumMember(Value = "NotIn")] NotIn,
        /// <summary>The value is greater than the compared value. Value = 4.</summary>
        [EnumMember(Value = "GreaterThan")] GreaterThan,
        /// <summary>The value is less than the compared value. Value = 5.</summary>
        [EnumMember(Value = "LessThan")] LessThan,
    }
}