using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Identifies the type of service available at an endpoint.</summary>
    [DataContract(Name = "EndpointType", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public enum EndpointType
    {
        /// <summary>The organization service. Value = 0.</summary>
        [EnumMember] OrganizationService,
        /// <summary>The organization data service. Value = 1.</summary>
        [EnumMember] OrganizationDataService,
        /// <summary>The Web application service. Value = 2.</summary>
        [EnumMember] WebApplication,
    }
}