using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute of type lookup.</summary>
    [DataContract(Name = "LookupAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class LookupAttributeMetadata : AttributeMetadata
    {
        private string[] _targets;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.LookupAttributeMetadata"></see> class</summary>
        public LookupAttributeMetadata()
            : base(AttributeTypeCode.Lookup)
        {
        }

        /// <summary>Gets or sets the target entity types for the lookup.</summary>
        /// <returns>Type: Returns_String[]
        /// The array of target entity types for the lookup.</returns>
        [DataMember]
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        public string[] Targets
        {
            get
            {
                return this._targets;
            }
            set
            {
                this._targets = value;
            }
        }
    }
}