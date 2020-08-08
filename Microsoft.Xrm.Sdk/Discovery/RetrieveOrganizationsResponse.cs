using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Contains the response from processing <see cref="T:Microsoft.Xrm.Sdk.Discovery.RetrieveOrganizationsRequest"></see>. </summary>
    [DataContract(Name = "RetrieveOrganizationsResponse", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public sealed class RetrieveOrganizationsResponse : DiscoveryResponse
    {
        private OrganizationDetailCollection _details = new OrganizationDetailCollection();

        /// <summary>Contains detailed information about the target organizations.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Discovery.OrganizationDetailCollection"></see>The details about the organization.</returns>
        [DataMember]
        public OrganizationDetailCollection Details
        {
            get
            {
                return this._details;
            }
            internal set
            {
                this._details = value;
            }
        }
    }
}