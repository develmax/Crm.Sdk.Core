using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute of type Boolean. </summary>
    [DataContract(Name = "BooleanOptionSetMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class BooleanOptionSetMetadata : OptionSetMetadataBase
    {
        private OptionMetadata _trueOption;
        private OptionMetadata _falseOption;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.BooleanOptionSetMetadata"></see> class</summary>
        public BooleanOptionSetMetadata()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.BooleanOptionSetMetadata"></see> class</summary>
        /// <param name="falseOption">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionMetadata"></see> The option metadata for the false option.</param>
        /// <param name="trueOption">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionMetadata"></see> The option metadata for the true option.</param>
        public BooleanOptionSetMetadata(OptionMetadata trueOption, OptionMetadata falseOption)
        {
            this.TrueOption = trueOption;
            this.FalseOption = falseOption;
        }

        /// <summary>Gets or sets option displayed when the attribute is true.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionMetadata"></see>The option metadata for the true option..</returns>
        [DataMember]
        public OptionMetadata TrueOption
        {
            get
            {
                return this._trueOption;
            }
            set
            {
                this._trueOption = value;
            }
        }

        /// <summary>Gets or sets option displayed when the attribute is false.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionMetadata"></see>The option metadata for the false option..</returns>
        [DataMember]
        public OptionMetadata FalseOption
        {
            get
            {
                return this._falseOption;
            }
            set
            {
                this._falseOption = value;
            }
        }
    }
}