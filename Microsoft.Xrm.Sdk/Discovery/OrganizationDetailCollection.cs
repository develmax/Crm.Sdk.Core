using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Provides a collection of <see cref="T:Microsoft.Xrm.Sdk.Discovery.OrganizationDetail"></see> instances.</summary>
    [CollectionDataContract(Name = "OrganizationDetailCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public sealed class OrganizationDetailCollection : DataCollection<OrganizationDetail>
    {
    }
}