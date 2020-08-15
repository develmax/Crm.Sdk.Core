using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Contains the data that is needed to retrieve the pn_microsoftcrm or pn_CRM_Online system user ID that is associated with a given identity provider ID.</summary>
    [DataContract(Name = "RetrieveUserIdByExternalIdRequest", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public sealed class RetrieveUserIdByExternalIdRequest : DiscoveryRequest
    {
        private string _organizationName;
        private Guid _organizationId;
        private string _externalId;
        private string _release;

        /// <summary>Gets or sets the ID of the target user.</summary>
        /// <returns>Type: Returns_StringThe external ID of the user to retrieve.</returns>
        [DataMember]
        public string ExternalId
        {
            get
            {
                return this._externalId;
            }
            set
            {
                this._externalId = value;
            }
        }

        /// <summary>Gets or sets the unique name of the organization that the target system user is a member of.</summary>
        /// <returns>Type: Returns_StringThe unique name of the organization that the target system user is a member of.</returns>
        [DataMember]
        public string OrganizationName
        {
            get
            {
                return this._organizationName;
            }
            set
            {
                this._organizationName = value;
            }
        }

        /// <summary>Gets or sets the ID of the organization that the target system user is a member of.</summary>
        /// <returns>Type: Returns_GuidThe ID of the organization that the target system user is a member of.</returns>
        [DataMember]
        public Guid OrganizationId
        {
            get
            {
                return this._organizationId;
            }
            set
            {
                this._organizationId = value;
            }
        }

        /// <summary>Gets or sets the release version of the pn_microsoftcrm product.</summary>
        /// <returns>Type: Returns_StringThe release version of the pn_microsoftcrm product.</returns>
        [DataMember]
        public string Release
        {
            get
            {
                return this._release;
            }
            set
            {
                this._release = value;
            }
        }
    }
}