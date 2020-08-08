using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains the response from execution of a message request.</summary>
    [DataContract(Name = "ExecuteMultipleResponseItem", Namespace = "http://schemas.microsoft.com/xrm/2012/Contracts")]
    public sealed class ExecuteMultipleResponseItem : IExtensibleDataObject
    {
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Gets or sets the numerical position of a message request in a request collection.</summary>
        /// <returns>Type: Returns_Int32The position of a message request in a request collection, starting at zero.</returns>
        [DataMember]
        public int RequestIndex { get; set; }

        /// <summary>Gets or sets the response that is returned from executing a message request.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationResponse"></see>The message response.</returns>
        [DataMember]
        public OrganizationResponse Response { get; set; }

        /// <summary>Gets or sets the organization service fault that occurred when a message request was executed.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationServiceFault"></see>The organization service fault.</returns>
        [DataMember]
        public OrganizationServiceFault Fault { get; set; }

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