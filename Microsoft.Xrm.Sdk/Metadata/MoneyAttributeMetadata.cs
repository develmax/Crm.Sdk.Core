using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute type Money.</summary>
    [DataContract(Name = "MoneyAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class MoneyAttributeMetadata : AttributeMetadata
    {
        /// <summary>The minimum supported value for this attribute is -922337000000000.</summary>
        public const double MinSupportedValue = -922337203685477.0;
        /// <summary>The maximum supported value for this attribute is 922337000000000.</summary>
        public const double MaxSupportedValue = 922337203685477.0;
        /// <summary>The minimum supported precision for this attribute is 0.</summary>
        public const int MinSupportedPrecision = 0;
        /// <summary>The maximum supported precision for this attribute is 4.</summary>
        public const int MaxSupportedPrecision = 4;

        /// <summary>Initializes a new instance of the<see cref="T:Microsoft.Xrm.Sdk.Metadata.MoneyAttributeMetadata"></see> class</summary>
        public MoneyAttributeMetadata()
          : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the<see cref="T:Microsoft.Xrm.Sdk.Metadata.MoneyAttributeMetadata"></see> class</summary>
        /// <param name="schemaName">Type: Returns_String.
        /// The schema name of the attribute.</param>
        public MoneyAttributeMetadata(string schemaName)
          : base(AttributeTypeCode.Money, schemaName)
        {
        }

        /// <summary>Gets or sets the input method editor (IME) mode for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.ImeMode"></see>&gt;
        /// The input method editor (IME) mode for the attribute..</returns>
        [DataMember]
        public Microsoft.Xrm.Sdk.Metadata.ImeMode? ImeMode { get; set; }

        /// <summary>Gets or sets the maximum value for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Double&gt;
        /// The maximum value for the attribute.</returns>
        [DataMember]
        public double? MaxValue { get; set; }

        /// <summary>Gets or sets the minimum value for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Double&gt;
        /// The minimum value for the attribute.</returns>
        [DataMember]
        public double? MinValue { get; set; }

        /// <summary>Gets or sets the precision for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The precision for the attribute.</returns>
        [DataMember]
        public int? Precision { get; set; }

        /// <summary>Gets or sets the precision source for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The precision source for the attribute.</returns>
        [DataMember]
        public int? PrecisionSource { get; set; }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Stringinternal</returns>
        [DataMember]
        public string CalculationOf { get; set; }

        /// <summary>Gets or sets the formula definition for calculated and rollup attributes.</summary>
        /// <returns>Type: Returns_StringThe formula definition for calculated and rollup attributes.</returns>
        [DataMember(Order = 70)]
        public string FormulaDefinition { get; set; }

        /// <summary>Gets the bitmask value that describes the source(s) of data used in a calculated attribute or whether the data sources are invalid.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt; The value that indicates the source of data for a calculated or rollup attribute.</returns>
        [DataMember(Order = 70)]
        public int? SourceTypeMask { get; internal set; }

        /// <summary>Gets whether the attribute represents the base currency or the transaction currency.</summary>
        /// <returns>Type : Returns_Nullable&lt;Returns_Boolean&gt;true if the attribute is the base currency; otherwise, false.</returns>
        [DataMember(Order = 70)]
        public bool? IsBaseCurrency { get; internal set; }
    }
}