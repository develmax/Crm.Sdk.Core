using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute of type Status.</summary>
    [DataContract(Name = "StatusAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class StatusAttributeMetadata : EnumAttributeMetadata
    {
        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.StatusAttributeMetadata"></see> class</summary>
        public StatusAttributeMetadata()
            : base(AttributeTypeCode.Status, (string)null)
        {
        }
    }
}