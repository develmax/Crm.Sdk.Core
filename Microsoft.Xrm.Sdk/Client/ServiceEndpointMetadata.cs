using System.Collections.ObjectModel;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Container class for metadata information about a service.</summary>
    public sealed class ServiceEndpointMetadata
    {
        private ServiceEndpointDictionary _serviceEndpoints = new ServiceEndpointDictionary();
        //private Collection<MetadataConversionError> _metadataConversionErrors = new Collection<MetadataConversionError>();

        /// <summary>Gets the service endpoint URIs.</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceEndpointDictionary"></see>The service endpoint URIs.</returns>
        public ServiceEndpointDictionary ServiceEndpoints
        {
            get
            {
                return this._serviceEndpoints;
            }
        }

        /// <summary>Gets the WSDL metadata for the service.</summary>
        /// <returns>Type:  Returns_MetadataSetThe WSDL metadata for the service.</returns>
        //public MetadataSet ServiceMetadata { get; set; }

        /// <summary>Gets the errors that occurred during metadata retrieval from the service.</summary>
        /// <returns>Type: Returns_Collection  The errors that occurred during metadata retrieval from the service.</returns>
        /*public Collection<MetadataConversionError> MetadataConversionErrors
        {
            get
            {
                return this._metadataConversionErrors;
            }
        }*/

        /// <summary>Gets the primary and alternate URLs for the service.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceUrls"></see>The primary and alternate URLs for the service.</returns>
        public ServiceUrls ServiceUrls { get; internal set; }
    }
}