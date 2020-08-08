using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Contains a dictionary of Returns_ServiceEndpoint objects.</summary>
    [Serializable]
    public sealed class ServiceEndpointDictionary : Dictionary<string, ServiceEndpoint>
    {
        /// <summary>constructor_initializes<see cref="T:Microsoft.Xrm.Sdk.Client.ServiceEndpointDictionary"></see> class.</summary>
        public ServiceEndpointDictionary()
        {
        }

        private ServiceEndpointDictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}