using System.ServiceModel;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Provides programmatic access to organization and user information. </summary>
    [ServiceContract(Name = "IDiscoveryService", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    [ServiceKnownType(typeof(DiscoveryServiceFault))]
    public interface IDiscoveryService
    {
        /// <summary>Executes a discovery service message in the form of a request, and returns a response. </summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Discovery.DiscoveryResponse"></see>. The response from processing the request. You must cast the return value of this method to the specific instance of the response that corresponds to the Request parameter.</returns>
        /// <param name="request">Type: <see cref="T:Microsoft.Xrm.Sdk.Discovery.DiscoveryRequest"></see>. A request instance that defines the action to be performed.</param>
        [OperationContract]
        [FaultContract(typeof(DiscoveryServiceFault))]
        DiscoveryResponse Execute(DiscoveryRequest request);
    }
}