using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute type Picklist. </summary>
    [DataContract(Name = "PicklistAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class PicklistAttributeMetadata : EnumAttributeMetadata
    {
        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata"></see> class</summary>
        public PicklistAttributeMetadata()
            : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata"></see> class</summary>
        /// <param name="schemaName">Type: Returns_String
        /// The schema name of the attribute.</param>
        public PicklistAttributeMetadata(string schemaName)
            : base(AttributeTypeCode.Picklist, schemaName)
        {
        }

        /// <summary>Gets or sets the formula definition for calculated and rollup attributes.</summary>
        /// <returns>Type: Returns_StringThe formula definition for calculated and rollup attributes.</returns>
        [DataMember(Order = 70)]
        public string FormulaDefinition { get; set; }

        /// <summary>Gets the bitmask value that describes the source(s) of data used in a calculated attribute or whether the data sources are invalid.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt; The value that indicates the source of data for a calculated or rollup attribute.</returns>
        [DataMember(Order = 70)]
        public int? SourceTypeMask { get; internal set; }
    }
}