using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains the data needed to execute a request and the base class for all organization requests.</summary>
    [SuppressMessage("Microsoft.Security", "CA9881:ClassesShouldBeSealed", Justification = "This class need to be instantiated by clients and be able to derive from it.")]
    [DataContract(Name = "OrganizationRequest", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public class OrganizationRequest : IExtensibleDataObject
    {
        private ParameterCollection _propertyBag;
        private string _messageName;
        private Guid? _requestId;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.OrganizationRequest"></see> class.</summary>
        public OrganizationRequest()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.OrganizationRequest"></see> class setting the request name parameter.</summary>
        /// <param name="requestName">Type: Returns_String. The name of the request.</param>
        public OrganizationRequest(string requestName)
        {
            this._messageName = requestName;
        }

        /// <summary>Gets or sets the name of the request. Required, but is supplied by derived classes.</summary>
        /// <returns>Type: Returns_StringThe name of the request.</returns>
        [DataMember]
        public string RequestName
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

        /// <summary>Gets or sets the indexer for the Parameters collection.</summary>
        /// <returns>Type: Returns_Object
        /// The indexer for the request.</returns>
        /// <param name="parameterName">Type: Returns_String. The name of the parameter.</param>
        public object this[string parameterName]
        {
            get
            {
                return this.Parameters[parameterName];
            }
            set
            {
                this.Parameters[parameterName] = value;
            }
        }

        /// <summary>Gets or sets the collection of parameters for the request. Required, but is supplied by derived classes.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.ParameterCollection"></see>The collection of parameters for the request. Required, but is supplied by derived classes.</returns>
        [DataMember]
        public ParameterCollection Parameters
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

        /// <summary>Gets or sets the ID of an asynchronous operation (system job). Optional. </summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Guid&gt;The ID of an asynchronous operation (system job).</returns>
        [DataMember]
        public Guid? RequestId
        {
            get
            {
                return this._requestId;
            }
            set
            {
                this._requestId = value;
            }
        }

        /// <summary>ExtensionData Optional.</summary>
        /// <returns>Type: Returns_ExtensionDataObject
        /// The extension data.</returns>
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
