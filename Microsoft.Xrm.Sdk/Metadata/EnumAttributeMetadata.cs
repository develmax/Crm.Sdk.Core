using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the data for an attribute that provides options.</summary>
    [KnownType(typeof(EntityNameAttributeMetadata))]
    [KnownType(typeof(PicklistAttributeMetadata))]
    [KnownType(typeof(StateAttributeMetadata))]
    [KnownType(typeof(StatusAttributeMetadata))]
    [DataContract(Name = "EnumAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public abstract class EnumAttributeMetadata : AttributeMetadata
    {
        private OptionSetMetadata _optionSetMetadata;
        private int? _defaultValue;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.EnumAttributeMetadata"></see> class.</summary>
        protected EnumAttributeMetadata()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.EnumAttributeMetadata"></see> class.</summary>
        /// <param name="attributeType">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode"></see> The attribute type code.</param>
        /// <param name="schemaName">Type: Returns_String
        /// The schema name for the attribute.</param>
        protected EnumAttributeMetadata(AttributeTypeCode attributeType, string schemaName)
          : base(attributeType, schemaName)
        {
        }

        /// <summary>Gets or sets the default form value for the attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The default form value for the attribute..</returns>
        [DataMember]
        public int? DefaultFormValue
        {
            get
            {
                return this._defaultValue;
            }
            set
            {
                this._defaultValue = value;
            }
        }

        /// <summary>Gets or sets the available options for the attribute.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata"></see>The available options for the attribute.</returns>
        [DataMember]
        public OptionSetMetadata OptionSet
        {
            get
            {
                return this._optionSetMetadata;
            }
            set
            {
                this._optionSetMetadata = value;
            }
        }
    }
}
