using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute type BigInt.</summary>
    [DataContract(Name = "BigIntAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class BigIntAttributeMetadata : AttributeMetadata
    {
        /// <summary>The minimum supported value for this attribute is -9223372036854775808.</summary>
        public const long MinSupportedValue = -9223372036854775808;
        /// <summary>The maximum supported value for this attribute is 9223372036854775807.</summary>
        public const long MaxSupportedValue = 9223372036854775807;
        private long? _maxValue;
        private long? _minValue;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.BigIntAttributeMetadata"></see> class</summary>
        public BigIntAttributeMetadata()
          : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.BigIntAttributeMetadata"></see> class</summary>
        /// <param name="schemaName">Type: Returns_String
        /// The Schema Name for the attribute.</param>
        public BigIntAttributeMetadata(string schemaName)
          : base(AttributeTypeCode.BigInt, schemaName)
        {
        }

        /// <summary>Gets or sets the maximum value for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int64&gt;
        /// The maximum value for the attribute.</returns>
        [DataMember]
        public long? MaxValue
        {
            get
            {
                return this._maxValue;
            }
            internal set
            {
                this._maxValue = value;
            }
        }

        /// <summary>Gets or sets the minimum value for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int64&gt;
        /// The minimum value for the attribute.</returns>
        [DataMember]
        public long? MinValue
        {
            get
            {
                return this._minValue;
            }
            internal set
            {
                this._minValue = value;
            }
        }
    }
}
