using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>internal</summary>
    [SuppressMessage("Microsoft.Naming", "CA1704")]
    [CollectionDataContract(Name = "QuickFindResultCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class QuickFindResultCollection : DataCollection<QuickFindResult>
    {
    }
}