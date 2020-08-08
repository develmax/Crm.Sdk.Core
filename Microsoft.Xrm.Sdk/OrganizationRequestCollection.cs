using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains a collection of organization requests.</summary>
    [CollectionDataContract(Name = "OrganizationRequestCollection", Namespace = "http://schemas.microsoft.com/xrm/2012/Contracts")]
    public sealed class OrganizationRequestCollection : DataCollection<OrganizationRequest>
    {
    }
}