using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Describes the formatting of a <see cref="T:Microsoft.Xrm.Sdk.Metadata.DateTimeAttributeMetadata"></see> attribute.</summary>
    [DataContract(Name = "DateTimeFormat", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum DateTimeFormat
    {
        /// <summary>Display the date only. Value = 0.</summary>
        [EnumMember(Value = "DateOnly")] DateOnly,
        /// <summary>Display the date and time. Value = 1.</summary>
        [EnumMember(Value = "DateAndTime")] DateAndTime,
    }
}
