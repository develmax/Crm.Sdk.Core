using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Describes the formatting of an integer attribute.</summary>
    [DataContract(Name = "IntegerFormat", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum IntegerFormat
    {
        /// <summary>Specifies to display an edit field for an integer. Value = 0.</summary>
        [EnumMember(Value = "None")] None,
        /// <summary>Specifies to display the integer as a drop down list of durations. Value = 1.</summary>
        [EnumMember(Value = "Duration")] Duration,
        /// <summary>Specifies to display the integer as a drop down list of time zones. Value = 2.</summary>
        [EnumMember(Value = "TimeZone")] TimeZone,
        /// <summary>Specifies the display the integer as a drop down list of installed languages. Value = 3.</summary>
        [EnumMember(Value = "Language")] Language,
        /// <summary>Specifies a locale. Value = 4.</summary>
        [EnumMember(Value = "Locale")] Locale,
    }
}