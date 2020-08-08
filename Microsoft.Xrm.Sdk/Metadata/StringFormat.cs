using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>deprecated Describes the formatting of a string attribute for the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see>.<see cref="P:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata.Format"></see> property.</summary>
    [DataContract(Name = "StringFormat", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum StringFormat
    {
        /// <summary>Specifies to display the string as an e-mail. Value = 0.</summary>
        [EnumMember(Value = "Email")] Email,
        /// <summary>Specifies to display the string as text. Value = 1.</summary>
        [EnumMember(Value = "Text")] Text,
        /// <summary>Specifies to display the string as a text area. Value = 2.</summary>
        [EnumMember(Value = "TextArea")] TextArea,
        /// <summary>Specifies to display the string as a URL. Value = 3.</summary>
        [EnumMember(Value = "Url")] Url,
        /// <summary>Specifies to display the string as a ticker symbol. Value = 4.</summary>
        [EnumMember(Value = "TickerSymbol")] TickerSymbol,
        /// <summary>Specifies to display the string as a phonetic guide. Value = 5.</summary>
        [EnumMember(Value = "PhoneticGuide")] PhoneticGuide,
        /// <summary>Specifies to display the string as a version number. Value = 6.</summary>
        [EnumMember(Value = "VersionNumber")] VersionNumber,
        /// <summary>internal</summary>
        [EnumMember(Value = "Phone")] Phone,
    }
}