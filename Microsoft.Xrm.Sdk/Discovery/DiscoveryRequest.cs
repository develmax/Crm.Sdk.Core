using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Contains the data that is needed to  execute a request and the base class for all discovery service requests.</summary>
    [DataContract(Name = "DiscoveryRequest", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    [KnownType(typeof(RetrieveOrganizationRequest))]
    [KnownType(typeof(RetrieveOrganizationsRequest))]
    [KnownType(typeof(RetrieveUserIdByExternalIdRequest))]
    public abstract class DiscoveryRequest : IExtensibleDataObject
    {
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Gets or sets the structure that contains extra data. Optional.</summary>
        /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
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