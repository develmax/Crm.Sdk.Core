using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains the response from a request and the base class for all organization responses.</summary>
    [SuppressMessage("Microsoft.Security", "CA9881:ClassesShouldBeSealed", Justification = "This class need to be instantiated by clients and be able to derive from it.")]
    [DataContract(Name = "OrganizationResponse", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public class OrganizationResponse : IExtensibleDataObject
    {
        private ParameterCollection _propertyBag;
        private string _messageName;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Gets or sets the name of the response.</summary>
        /// <returns>Type: Returns_StringThe name of the response.</returns>
        [DataMember]
        public string ResponseName
        {
            get
            {
                return this._messageName;
            }
            set
            {
                this._messageName = value;
            }
        }

        /// <summary>Gets an indexer for the Results collection.</summary>
        /// <returns>Type: Returns_ObjectThe indexer for the collection.</returns>
        /// <param name="parameterName">Type: Returns_String. The name of the parameter.</param>
        public object this[string parameterName]
        {
            get
            {
                return this.Results[parameterName];
            }
            set
            {
                this.Results[parameterName] = value;
            }
        }

        /// <summary>Gets the results of the request that was performed.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.ParameterCollection"></see>The results of the request that was performed.</returns>
        [DataMember]
        public ParameterCollection Results
        {
            get
            {
                if (this._propertyBag == null)
                    this._propertyBag = new ParameterCollection();
                return this._propertyBag;
            }
            set
            {
                this._propertyBag = value;
            }
        }

        /// <summary>ExtensionData</summary>
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