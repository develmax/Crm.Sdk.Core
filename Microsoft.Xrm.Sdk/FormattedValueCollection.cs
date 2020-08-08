using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains a collection of formatted values for the attributes for an entity.</summary>
    [CollectionDataContract(Name = "FormattedValueCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class FormattedValueCollection : DataCollection<string, string>
    {
    }
}