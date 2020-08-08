using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Describes the input method editor mode</summary>
    [DataContract(Name = "ImeMode", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum ImeMode
    {
        /// <summary>Specifies that the IME mode is chosen automatically. Value =0.</summary>
        [EnumMember(Value = "Auto")] Auto,
        /// <summary>Specifies that the IME mode is inactive. Value = 1.</summary>
        [EnumMember(Value = "Inactive")] Inactive,
        /// <summary>Specifies that the IME mode is active. Value = 2.</summary>
        [EnumMember(Value = "Active")] Active,
        /// <summary>Specifies that the IME mode is disabled. Value = 3.</summary>
        [EnumMember(Value = "Disabled")] Disabled,
    }
}