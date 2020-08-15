using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute type Boolean. </summary>
    [DataContract(Name = "BooleanAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class BooleanAttributeMetadata : AttributeMetadata
    {
        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.BooleanAttributeMetadata"></see> class</summary>
        public BooleanAttributeMetadata()
          : this((string)null, (BooleanOptionSetMetadata)null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.BooleanAttributeMetadata"></see> class</summary>
        /// <param name="schemaName">Type: Returns_String
        /// The schema name of the attribute.</param>
        public BooleanAttributeMetadata(string schemaName)
          : this(schemaName, (BooleanOptionSetMetadata)null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.BooleanAttributeMetadata"></see> class</summary>
        /// <param name="optionSet">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.BooleanOptionSetMetadata"></see> The definition of the options</param>
        public BooleanAttributeMetadata(BooleanOptionSetMetadata optionSet)
          : this((string)null, optionSet)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.BooleanAttributeMetadata"></see> class</summary>
        /// <param name="optionSet">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.BooleanOptionSetMetadata"></see> The definition of the options</param>
        /// <param name="schemaName">Type: Returns_String
        /// The schema name of the attribute.</param>
        public BooleanAttributeMetadata(string schemaName, BooleanOptionSetMetadata optionSet)
          : base(AttributeTypeCode.Boolean, schemaName)
        {
            this.OptionSet = optionSet;
        }

        /// <summary>Gets or sets the default value for a Boolean option set.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;
        /// The default value for a Boolean option set.</returns>
        [DataMember]
        public bool? DefaultValue { get; set; }

        /// <summary>Gets or sets the formula definition for calculated and rollup attributes.</summary>
        /// <returns>Type: Returns_StringThe formula definition for calculated and rollup attributes.</returns>
        [DataMember(Order = 70)]
        public string FormulaDefinition { get; set; }

        /// <summary>Gets the bitmask value that describes the source(s) of data used in a calculated attribute or whether the data sources are invalid.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt; The value that indicates the source of data for a calculated or rollup attribute.</returns>
        [DataMember(Order = 70)]
        public int? SourceTypeMask { get; internal set; }

        /// <summary>Gets or sets the options for a boolean attribute.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.BooleanOptionSetMetadata"></see> The definition of the options.</returns>
        [DataMember]
        public BooleanOptionSetMetadata OptionSet { get; set; }
    }
}