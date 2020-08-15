using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Represents a service fault.</summary>
    [KnownType(typeof(OrganizationServiceFault))]
    [KnownType(typeof(DiscoveryServiceFault))]
    [DataContract(Name = "BaseServiceFault", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [Serializable]
    public abstract class BaseServiceFault : IExtensibleDataObject
    {
        private DateTime _timestamp;
        private string _message;
        private int _errorCode;
        private ErrorDetailCollection _details;
        private BaseServiceFault _innerServiceFault;
        [NonSerialized]
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Gets or sets the message for the fault.</summary>
        /// <returns>Type: Returns_StringThe message for the fault.</returns>
        [DataMember]
        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                this._message = value;
            }
        }

        /// <summary>Gets or sets the fault error code.</summary>
        /// <returns>Type: Returns_Int32The fault error code.</returns>
        [DataMember]
        public int ErrorCode
        {
            get
            {
                return this._errorCode;
            }
            set
            {
                this._errorCode = value;
            }
        }

        /// <summary>Gets or sets the date and time when the fault occurred.</summary>
        /// <returns>Type: Returns_DateTimeThe date and time when the fault occurred.</returns>
        [DataMember]
        public DateTime Timestamp
        {
            get
            {
                return this._timestamp;
            }
            set
            {
                this._timestamp = value;
            }
        }

        /// <summary>Gets or sets the details of the fault.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.ErrorDetailCollection"></see>The collection of details about the fault.</returns>
        [DataMember]
        public ErrorDetailCollection ErrorDetails
        {
            get
            {
                if (this._details == null)
                    this._details = new ErrorDetailCollection();
                return this._details;
            }
            set
            {
                this._details = value;
            }
        }

        internal virtual BaseServiceFault InnerServiceFault
        {
            get
            {
                return this._innerServiceFault;
            }
            set
            {
                this._innerServiceFault = value;
            }
        }

        /// <summary>Gets or sets a structure that contains extra data.</summary>
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
