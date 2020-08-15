using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute of type String.</summary>
    [DataContract(Name = "StringAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class StringAttributeMetadata : AttributeMetadata
    {
        /// <summary>The minimum supported length is 1 character.</summary>
        public const int MinSupportedLength = 1;
        /// <summary>The maximum supported length is 4000 characters.</summary>
        public const int MaxSupportedLength = 4000;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see> class</summary>
        public StringAttributeMetadata()
          : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see> class</summary>
        /// <param name="schemaName">Type: Returns_String.
        /// The schema name of the attribute to create.</param>
        public StringAttributeMetadata(string schemaName)
          : base(AttributeTypeCode.String, schemaName)
        {
        }

        /// <summary>Gets or sets the format for the string</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormat"></see>&gt;
        /// The format of the string attribute.</returns>
        [DataMember]
        public StringFormat? Format { get; set; }

        /// <summary>Gets or sets the format for the string.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormatName"></see>The format for the string attribute.</returns>
        [DataMember(Order = 60)]
        public StringFormatName FormatName { get; set; }

        /// <summary>Gets or sets the IME mode for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.ImeMode"></see>&gt;
        /// The input method editor mode.</returns>
        [DataMember]
        public Microsoft.Xrm.Sdk.Metadata.ImeMode? ImeMode { get; set; }

        /// <summary>Gets or sets the maximum length for the string.</summary>
        /// <returns>Type: Returns_Nullable&lt;int&gt;
        /// The maximum length.</returns>
        [DataMember]
        public int? MaxLength { get; set; }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Stringinternal</returns>
        [DataMember]
        public string YomiOf { get; set; }

        /// <summary>Gets whether the attribute supports localizable values</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the attribute supports localizable values; otherwise, false.</returns>
        [DataMember(Order = 70)]
        public bool? IsLocalizable { get; internal set; }

        internal int? DatabaseLength { get; set; }

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
