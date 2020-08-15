using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute of type DateTime.</summary>
    [DataContract(Name = "DateTimeAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class DateTimeAttributeMetadata : AttributeMetadata
    {
        private static readonly DateTime _minDateTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly DateTime _maxDateTime = new DateTime(9999, 12, 30, 23, 59, 59, DateTimeKind.Utc);

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.DateTimeAttributeMetadata"></see> class</summary>
        public DateTimeAttributeMetadata()
          : this(new DateTimeFormat?())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.DateTimeAttributeMetadata"></see> class</summary>
        /// <param name="format">Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.DateTimeFormat"></see>&gt;.
        /// The date/time display format.</param>
        public DateTimeAttributeMetadata(DateTimeFormat? format)
          : this(format, (string)null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.DateTimeAttributeMetadata"></see> class</summary>
        /// <param name="format">Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.DateTimeFormat"></see>&gt;.
        /// The date/time display format.</param>
        /// <param name="schemaName">Type: Returns_String.
        /// The schema name of the attribute.</param>
        public DateTimeAttributeMetadata(DateTimeFormat? format, string schemaName)
          : base(AttributeTypeCode.DateTime, schemaName)
        {
            this.Format = format;
        }

        /// <summary>Gets the minimum supported value for this attribute.</summary>
        /// <returns>Type: Returns_DateTimeThe minimum supported date for this attribute.</returns>
        public static DateTime MinSupportedValue
        {
            get
            {
                return DateTimeAttributeMetadata._minDateTime;
            }
        }

        /// <summary>Gets the maximum supported value for this attribute.</summary>
        /// <returns>Type: Returns_DateTimeThe maximum supported date for this attribute.</returns>
        public static DateTime MaxSupportedValue
        {
            get
            {
                return DateTimeAttributeMetadata._maxDateTime;
            }
        }

        /// <summary>Gets or sets the date/time display format.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.DateTimeFormat"></see>&gt;
        /// The date/time display format.</returns>
        [DataMember]
        public DateTimeFormat? Format { get; set; }

        /// <summary>Gets or sets the input method editor (IME) mode for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.ImeMode"></see>&gt;
        /// The input method editor mode for the attribute.</returns>
        [DataMember]
        public Microsoft.Xrm.Sdk.Metadata.ImeMode? ImeMode { get; set; }

        /// <summary>Gets the bitmask value that describes the source(s) of data used in a calculated attribute or whether the data sources are invalid.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt; The value that indicates the source of data for a calculated or rollup attribute.</returns>
        [DataMember(Order = 70)]
        public int? SourceTypeMask { get; internal set; }

        /// <summary>Gets or sets the formula definition for calculated and rollup attributes.</summary>
        /// <returns>Type: Returns_StringThe formula definition for calculated and rollup attributes.</returns>
        [DataMember(Order = 70)]
        public string FormulaDefinition { get; set; }
    }
}
