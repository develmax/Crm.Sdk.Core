using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute type Decimal.</summary>
    [DataContract(Name = "DecimalAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class DecimalAttributeMetadata : AttributeMetadata
    {
        /// <summary>The minimum supported value is -100 Billion.</summary>
        public const double MinSupportedValue = -100000000000.0;
        /// <summary>The maximum supported value is 100 Billion.</summary>
        public const double MaxSupportedValue = 100000000000.0;
        /// <summary>The minimum supported value for Precision is 0.</summary>
        public const int MinSupportedPrecision = 0;
        /// <summary>The maximum supported value for Precision is 10.</summary>
        public const int MaxSupportedPrecision = 10;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.DecimalAttributeMetadata"></see> class</summary>
        public DecimalAttributeMetadata()
          : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.DecimalAttributeMetadata"></see> class</summary>
        /// <param name="schemaName">Type: Returns_String
        /// The schema name of the attribute.</param>
        public DecimalAttributeMetadata(string schemaName)
          : base(AttributeTypeCode.Decimal, schemaName)
        {
        }

        /// <summary>Gets or sets the maximum value for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Decimal&gt;
        /// The maximum value for the attribute.</returns>
        [DataMember]
        public Decimal? MaxValue { get; set; }

        /// <summary>Gets or sets the minimum value for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Decimal&gt;
        /// The minimum value for the attribute.</returns>
        [DataMember]
        public Decimal? MinValue { get; set; }

        /// <summary>Gets or sets the precision for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The precision for the attribute.</returns>
        [DataMember]
        public int? Precision { get; set; }

        /// <summary>Gets or sets the input method editor (IME) mode for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.ImeMode"></see>&gt;
        /// The input method editor (IME) mode for the attribute..</returns>
        [DataMember]
        public Microsoft.Xrm.Sdk.Metadata.ImeMode? ImeMode { get; set; }

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
