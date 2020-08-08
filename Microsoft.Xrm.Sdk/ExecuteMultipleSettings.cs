using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Defines the execution behavior of <see cref="T:Microsoft.Xrm.Sdk.Messages.ExecuteMultipleRequest"></see>.</summary>
    [DataContract(Name = "ExecuteMultipleSettings", Namespace = "http://schemas.microsoft.com/xrm/2012/Contracts")]
    public sealed class ExecuteMultipleSettings : IExtensibleDataObject
    {
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Gets or sets a value indicating whether further execution of message requests in the <see cref="P:Microsoft.Xrm.Sdk.Messages.ExecuteMultipleRequest.Requests"></see> collection should continue if a fault is returned for the current request being processed.</summary>
        /// <returns>Type: Returns_Booleantrue if message request processing should continue; otherwise, false.</returns>
        [DataMember]
        public bool ContinueOnError { get; set; }

        /// <summary>Gets or sets a value indicating if a response for each message request processed should be returned.</summary>
        /// <returns>Type: Returns_Booleantrue if responses should be returned for each message request processed; otherwise, false.</returns>
        [DataMember]
        public bool ReturnResponses { get; set; }

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