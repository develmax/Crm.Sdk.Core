using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Describes the current state of an organization.</summary>
    [DataContract(Name = "OrganizationState", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public enum OrganizationState
    {
        /// <summary>The organization is enabled. Value = 0.</summary>
        [EnumMember] Enabled,
        /// <summary>The organization is disabled. Value = 1.</summary>
        [EnumMember] Disabled,
    }
}