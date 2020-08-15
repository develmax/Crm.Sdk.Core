using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute type Integer.</summary>
    [DataContract(Name = "IntegerAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class IntegerAttributeMetadata : AttributeMetadata
    {
        /// <summary>The minimum supported value is -2147483648.</summary>
        public const int MinSupportedValue = -2147483648;
        /// <summary>The maximum supported value is 2147483647.</summary>
        public const int MaxSupportedValue = 2147483647;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.IntegerAttributeMetadata"></see> class</summary>
        public IntegerAttributeMetadata()
          : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.IntegerAttributeMetadata"></see> class</summary>
        /// <param name="schemaName">Type: Returns_String
        /// The schema name for the attribute.</param>
        public IntegerAttributeMetadata(string schemaName)
          : base(AttributeTypeCode.Integer, schemaName)
        {
        }

        /// <summary>Gets or sets the format options for the integer attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.IntegerFormat"></see>&gt;
        /// The format options for the integer attribute.</returns>
        [DataMember]
        public IntegerFormat? Format { get; set; }

        /// <summary>Gets or sets the maximum value for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The maximum value for the attribute.</returns>
        [DataMember]
        public int? MaxValue { get; set; }

        /// <summary>Gets or sets the minimum value for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The minimum value for the attribute.</returns>
        [DataMember]
        public int? MinValue { get; set; }

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
