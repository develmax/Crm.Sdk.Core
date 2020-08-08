using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Represents an organization service fault.</summary>
    [DataContract(Name = "OrganizationServiceFault", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [Serializable]
    public sealed class OrganizationServiceFault : BaseServiceFault
    {
        private string _traceText;
        private OrganizationServiceFault _innerFault;

        /// <summary>Gets the text of the fault trace.</summary>
        /// <returns>Type: Returns_StringThe text of the fault trace.</returns>
        [DataMember]
        public string TraceText
        {
            get
            {
                return this._traceText;
            }
            set
            {
                this._traceText = value;
            }
        }

        /// <summary>Gets the fault instance that caused the current fault.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationServiceFault"></see>The fault instance that caused the current fault.</returns>
        [DataMember]
        public OrganizationServiceFault InnerFault
        {
            get
            {
                return this._innerFault;
            }
            set
            {
                this._innerFault = value;
            }
        }

        [IgnoreDataMember]
        internal override BaseServiceFault InnerServiceFault
        {
            get
            {
                return (BaseServiceFault)this._innerFault;
            }
            set
            {
                this._innerFault = (OrganizationServiceFault)value;
            }
        }
    }
}