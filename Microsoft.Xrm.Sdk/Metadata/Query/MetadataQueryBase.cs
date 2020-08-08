using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    /// <summary>Represents the abstract base class for constructing a metadata query.</summary>
    [KnownType(typeof(MetadataQueryExpression))]
    [DataContract(Name = "MetadataQueryBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
    public abstract class MetadataQueryBase : IExtensibleDataObject
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal abstract void Accept(IMetadataQueryExpressionVisitor visitor);

        /// <summary>ExtensionData</summary>
        /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
        public ExtensionDataObject ExtensionData { get; set; }
    }
}