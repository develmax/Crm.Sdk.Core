using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>A collection of service endpoints.</summary>
    [CollectionDataContract(Name = "EndpointCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public sealed class EndpointCollection : DataCollection<EndpointType, string>
    {
    }
}