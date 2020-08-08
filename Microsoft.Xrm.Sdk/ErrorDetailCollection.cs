using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains a collection of objects that provide details on an error.</summary>
    [CollectionDataContract(Name = "ErrorDetailCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [Serializable]
    public sealed class ErrorDetailCollection : DataCollection<string, object>
    {
    }
}