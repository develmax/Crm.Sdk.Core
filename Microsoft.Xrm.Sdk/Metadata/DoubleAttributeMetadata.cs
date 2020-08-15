using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute type Double.</summary>
    [DataContract(Name = "DoubleAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class DoubleAttributeMetadata : AttributeMetadata
    {
        /// <summary>The minimum supported value is -100 billion.</summary>
        public const double MinSupportedValue = -100000000000.0;
        /// <summary>The maximum supported value is 100 billion.</summary>
        public const double MaxSupportedValue = 100000000000.0;
        /// <summary>The minimum supported value for Precision is 0.</summary>
        public const int MinSupportedPrecision = 0;
        /// <summary>The maximum supported value for Precision is 5.</summary>
        public const int MaxSupportedPrecision = 5;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.DoubleAttributeMetadata"></see> class</summary>
        public DoubleAttributeMetadata()
          : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.DoubleAttributeMetadata"></see> class</summary>
        /// <param name="schemaName">Type: Returns_String
        /// The schema name for the attribute.</param>
        public DoubleAttributeMetadata(string schemaName)
          : base(AttributeTypeCode.Double, schemaName)
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
    }
}