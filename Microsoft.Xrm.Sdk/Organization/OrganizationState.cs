using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
    [DataContract(Name = "OrganizationState", Namespace = "http://schemas.microsoft.com/xrm/2014/Contracts")]
    public enum OrganizationState
    {
        [EnumMember] Enabled,
        [EnumMember] Disabled,
    }
}