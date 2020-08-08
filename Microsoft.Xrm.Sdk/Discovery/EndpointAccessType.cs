using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Indicates the type of network access an endpoint has.</summary>
    [DataContract(Name = "EndpointAccessType", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public enum EndpointAccessType
    {
        /// <summary>Default access. The actual access is determined by the endpoint URL. Value = 0.</summary>
        [EnumMember] Default,
        /// <summary>Internet access. Value = 1.</summary>
        [EnumMember] Internet,
        /// <summary>Intranet access. Value = 2.</summary>
        [EnumMember] Intranet,
    }
}