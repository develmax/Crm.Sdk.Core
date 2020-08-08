using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Contains the data that is needed to  retrieve information on all organizations that the logged on user belongs to.</summary>
    [DataContract(Name = "RetrieveOrganizationsRequest", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public sealed class RetrieveOrganizationsRequest : DiscoveryRequest
    {
        /// <summary>Indicates the applicable version of pn_microsoftcrm.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Discovery.OrganizationRelease"></see>The release to retrieve.</returns>
        [DataMember(IsRequired = false)]
        public OrganizationRelease Release { get; set; }

        /// <summary>Gets or sets the access type of the organizations’ service endpoint.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Discovery.EndpointAccessType"></see>The access type of the organizations’ service endpoint.</returns>
        [DataMember(IsRequired = false)]
        public EndpointAccessType AccessType { get; set; }

        [DataMember(IsRequired = false)]
        public bool IsInternalCrossGeoServerRequest { get; set; }
    }
}