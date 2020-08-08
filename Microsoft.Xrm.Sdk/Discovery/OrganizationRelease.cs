using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Describes the release of an organization.</summary>
    [DataContract(Name = "OrganizationRelease", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public enum OrganizationRelease
    {
        /// <summary>The current release. Value = 0.</summary>
        [EnumMember] Current,
        /// <summary>The pn_CRM_2011 release. Value = 1.</summary>
        [EnumMember] V5,
    }
}