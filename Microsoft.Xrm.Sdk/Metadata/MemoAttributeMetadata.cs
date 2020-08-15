using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for the attribute type Memo.</summary>
    [DataContract(Name = "MemoAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class MemoAttributeMetadata : AttributeMetadata
    {
        /// <summary>The minimum supported length is 1.</summary>
        public const int MinSupportedLength = 1;
        /// <summary>The maximum supported length is 1048576.</summary>
        public const int MaxSupportedLength = 1048576;
        private StringFormat? _format;
        private Microsoft.Xrm.Sdk.Metadata.ImeMode? _imeMode;
        private int? _maxLength;
        private bool? _isLocalizable;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.MemoAttributeMetadata"></see> class</summary>
        public MemoAttributeMetadata()
          : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.MemoAttributeMetadata"></see> class</summary>
        /// <param name="schemaName">Type: Returns_String
        /// The schema name of the attribute.</param>
        public MemoAttributeMetadata(string schemaName)
          : base(AttributeTypeCode.Memo, schemaName)
        {
        }

        /// <summary>Gets or sets the format options for the memo attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormat"></see>&gt;
        /// The format options for the memo attribute.</returns>
        [DataMember]
        public StringFormat? Format
        {
            get
            {
                return this._format;
            }
            set
            {
                this._format = value;
            }
        }

        /// <summary>Gets or sets the value for the input method editor mode.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.ImeMode"></see>&gt;
        /// The value for the input method editor mode..</returns>
        [DataMember]
        public Microsoft.Xrm.Sdk.Metadata.ImeMode? ImeMode
        {
            get
            {
                return this._imeMode;
            }
            set
            {
                this._imeMode = value;
            }
        }

        /// <summary>Gets or sets the maximum length for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The maximum length for the attribute.</returns>
        [DataMember]
        public int? MaxLength
        {
            get
            {
                return this._maxLength;
            }
            set
            {
                this._maxLength = value;
            }
        }

        /// <summary>Gets whether the attribute supports localizable values</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the attribute supports localizable values; otherwise, false.</returns>
        [DataMember(Order = 70)]
        public bool? IsLocalizable
        {
            get
            {
                return this._isLocalizable;
            }
            internal set
            {
                this._isLocalizable = value;
            }
        }
    }
}