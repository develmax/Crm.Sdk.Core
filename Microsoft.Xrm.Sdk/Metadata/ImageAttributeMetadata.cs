using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute type Image.</summary>
    [DataContract(Name = "ImageAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2013/Metadata")]
    public sealed class ImageAttributeMetadata : AttributeMetadata
    {
        private bool? _isPrimaryImageAttribute;
        private short? _maxHeight;
        private short? _maxWidth;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.ImageAttributeMetadata"></see> class.</summary>
        public ImageAttributeMetadata()
          : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.ImageAttributeMetadata"></see> class.</summary>
        /// <param name="schemaName">Type: Returns_String
        /// The schema name for the attribute.</param>
        public ImageAttributeMetadata(string schemaName)
        {
            this.AttributeType = new AttributeTypeCode?(AttributeTypeCode.Virtual);
            this.AttributeTypeName = AttributeTypeDisplayName.ImageType;
            this.SchemaName = schemaName;
        }

        /// <summary>Gets or sets whether the attribute is the primary image for the entity.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the attribute is the primary image for the entity; otherwise, false.</returns>
        [DataMember]
        public bool? IsPrimaryImage
        {
            get
            {
                return this._isPrimaryImageAttribute;
            }
            set
            {
                this._isPrimaryImageAttribute = value;
            }
        }

        /// <summary>Gets the maximum height of the image.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int16&gt;
        /// The maximum height for the image.</returns>
        [DataMember]
        public short? MaxHeight
        {
            get
            {
                return this._maxHeight;
            }
            internal set
            {
                this._maxHeight = value;
            }
        }

        /// <summary>Gets the maximum width of the image.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int16&gt;
        /// The maximum width for the image.</returns>
        [DataMember]
        public short? MaxWidth
        {
            get
            {
                return this._maxWidth;
            }
            internal set
            {
                this._maxWidth = value;
            }
        }
    }
}