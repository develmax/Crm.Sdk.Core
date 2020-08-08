using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Contains the response from processing <see cref="T:Microsoft.Xrm.Sdk.Discovery.RetrieveOrganizationRequest"></see>. </summary>
    [DataContract(Name = "RetrieveOrganizationResponse", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public sealed class RetrieveOrganizationResponse : DiscoveryResponse
    {
        /// <summary>Contains detailed information about the target organization.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Discovery.OrganizationDetail"></see>The details about the organization.</returns>
        [DataMember]
        public OrganizationDetail Detail { get; set; }
    }
}