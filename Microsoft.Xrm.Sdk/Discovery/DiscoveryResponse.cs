using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Contains the response from the request and is the base class for all discovery service responses.</summary>
    [KnownType(typeof(RetrieveOrganizationResponse))]
    [KnownType(typeof(RetrieveUserIdByExternalIdResponse))]
    [DataContract(Name = "DiscoveryResponse", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    [KnownType(typeof(RetrieveOrganizationsResponse))]
    public abstract class DiscoveryResponse : IExtensibleDataObject
    {
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Gets or sets the structure that contains extra data.</summary>
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