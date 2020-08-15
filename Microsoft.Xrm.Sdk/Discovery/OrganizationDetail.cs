using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Provides detailed information on an organization.</summary>
    [DataContract(Name = "OrganizationDetail", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public sealed class OrganizationDetail : IExtensibleDataObject
    {
        private EndpointCollection _endpoints = new EndpointCollection();
        private Guid _organizationId;
        private string _friendlyName;
        private string _organizationVersion;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Gets or sets global unique identifier of the organization.</summary>
        /// <returns>Type: Returns_GuidThe global unique identifier of the organization.</returns>
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

        /// <summary>Gets or sets the friendly name of the organization.</summary>
        /// <returns>Type: Returns_String The friendly name of the organization.</returns>
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

        /// <summary>Gets or sets the version of the organization.</summary>
        /// <returns>Type: Returns_String The version of the organization.</returns>
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

        /// <summary>Gets or sets the organization name used in the URL for the organization Web service.</summary>
        /// <returns>Type: Returns_String The organization name used in the URL for the organization Web service.</returns>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Returned as string for compatibility")]
        [DataMember]
        public string UrlName { get; set; }

        /// <summary>Gets or sets the unique name of the organization.</summary>
        /// <returns>Type: Returns_StringThe unique name of the organization.</returns>
        [DataMember]
        public string UniqueName { get; set; }

        /// <summary>Gets a collection that identifies the service type and address for each endpoint of the organization.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Discovery.EndpointCollection"></see>The collection that identifies the service type and address for each endpoint of the organization.</returns>
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

        /// <summary>Gets or sets the state of the organization.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Discovery.OrganizationState"></see>The state of the organization.</returns>
        [DataMember]
        public OrganizationState State { get; set; }

        /// <summary>Gets or sets extra data of the organization. </summary>
        /// <returns>Type: Returns_ExtensionDataObject Extra data of the organization.</returns>
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