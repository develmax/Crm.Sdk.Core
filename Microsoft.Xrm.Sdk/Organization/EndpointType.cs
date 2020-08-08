using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
    [DataContract(Name = "EndpointType", Namespace = "http://schemas.microsoft.com/xrm/2014/Contracts")]
    public enum EndpointType
    {
        [EnumMember] OrganizationService,
        [EnumMember] OrganizationDataService,
        [EnumMember] WebApplication,
    }
}