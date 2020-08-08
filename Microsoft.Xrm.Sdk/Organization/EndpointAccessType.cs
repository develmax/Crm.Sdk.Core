using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
    [DataContract(Name = "EndpointAccessType", Namespace = "http://schemas.microsoft.com/xrm/2014/Contracts")]
    public enum EndpointAccessType
    {
        [EnumMember] Default,
        [EnumMember] Internet,
        [EnumMember] Intranet,
    }
}