using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Contains the data that is needed to  retrieve information about an organization.</summary>
    [DataContract(Name = "RetrieveOrganizationRequest", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public sealed class RetrieveOrganizationRequest : DiscoveryRequest
    {
        /// <summary>Gets or sets the unique name of the organization.</summary>
        /// <returns>Type: Returns_StringThe organization unique name.</returns>
        [DataMember]
        public string UniqueName { get; set; }

        /// <summary>Indicates the applicable version of pn_microsoftcrm.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Discovery.OrganizationRelease"></see>The release to retrieve.</returns>
        [DataMember(IsRequired = false)]
        public OrganizationRelease Release { get; set; }

        /// <summary>Gets or sets the access type of the organization’s service endpoint.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Discovery.EndpointAccessType"></see>The access type.</returns>
        [DataMember(IsRequired = false)]
        public EndpointAccessType AccessType { get; set; }
    }
}