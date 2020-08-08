using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Represents a discovery service fault.</summary>
    [DataContract(Name = "DiscoveryServiceFault", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [Serializable]
    public sealed class DiscoveryServiceFault : BaseServiceFault
    {
        private DiscoveryServiceFault _innerFault;

        /// <summary>Gets or sets the fault instance that caused the current fault.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DiscoveryServiceFault"></see>The fault instance that caused the current fault.</returns>
        [DataMember]
        public DiscoveryServiceFault InnerFault
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
                this._innerFault = (DiscoveryServiceFault)value;
            }
        }
    }
}