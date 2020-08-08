using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute of type State.</summary>
    [DataContract(Name = "StateAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class StateAttributeMetadata : EnumAttributeMetadata
    {
        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.StateAttributeMetadata"></see> class</summary>
        public StateAttributeMetadata()
            : base(AttributeTypeCode.State, (string)null)
        {
        }
    }
}