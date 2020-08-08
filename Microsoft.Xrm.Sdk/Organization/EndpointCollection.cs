using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
    [CollectionDataContract(Name = "EndpointCollection", Namespace = "http://schemas.microsoft.com/xrm/2014/Contracts")]
    public sealed class EndpointCollection : DataCollection<EndpointType, string>
    {
        public static EndpointCollection FromDiscovery(Microsoft.Xrm.Sdk.Discovery.EndpointCollection collection)
        {
            EndpointCollection endpointCollection = new EndpointCollection();
            foreach (KeyValuePair<Microsoft.Xrm.Sdk.Discovery.EndpointType, string> keyValuePair in (DataCollection<Microsoft.Xrm.Sdk.Discovery.EndpointType, string>)collection)
                endpointCollection.Add((EndpointType)keyValuePair.Key, keyValuePair.Value);
            return endpointCollection;
        }
    }
}