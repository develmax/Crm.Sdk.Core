using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
    [DataContract(Name = "OrganizationDetail", Namespace = "http://schemas.microsoft.com/xrm/2014/Contracts")]
    public sealed class OrganizationDetail : IExtensibleDataObject
    {
        private EndpointCollection _endpoints = new EndpointCollection();
        private Guid _organizationId;
        private string _friendlyName;
        private string _organizationVersion;
        private ExtensionDataObject _extensionDataObject;

        public static OrganizationDetail FromDiscovery(Microsoft.Xrm.Sdk.Discovery.OrganizationDetail detail)
        {
            return new OrganizationDetail()
            {
                OrganizationId = detail.OrganizationId,
                FriendlyName = detail.FriendlyName,
                OrganizationVersion = detail.OrganizationVersion,
                UrlName = detail.UrlName,
                UniqueName = detail.UniqueName,
                Endpoints = EndpointCollection.FromDiscovery(detail.Endpoints),
                State = (OrganizationState)detail.State
            };
        }

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

        [DataMember]
        public string FriendlyName
        {
            get
            {
                return this._friendlyName;
            }
            set
            {
                this._friendlyName = value;
            }
        }

        [DataMember]
        public string OrganizationVersion
        {
            get
            {
                return this._organizationVersion;
            }
            set
            {
                this._organizationVersion = value;
            }
        }

        [DataMember]
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Returned as string for compatibility")]
        public string UrlName { get; set; }

        [DataMember]
        public string UniqueName { get; set; }

        [DataMember]
        public EndpointCollection Endpoints
        {
            get
            {
                return this._endpoints;
            }
            internal set
            {
                this._endpoints = value;
            }
        }

        [DataMember]
        public OrganizationState State { get; set; }

        public ExtensionDataObject ExtensionData
        {
            get
            {
                return this._extensionDataObject;
            }
            set
            {
                this._extensionDataObject = value;
            }
        }
    }
}
