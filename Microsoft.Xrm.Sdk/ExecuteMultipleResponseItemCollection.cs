using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains a collection of <see cref="T:Microsoft.Xrm.Sdk.ExecuteMultipleResponseItem"></see> instances.</summary>
    [CollectionDataContract(Name = "OrganizationResponseCollection", Namespace = "http://schemas.microsoft.com/xrm/2012/Contracts")]
    public sealed class ExecuteMultipleResponseItemCollection : DataCollection<ExecuteMultipleResponseItem>
    {
    }
}