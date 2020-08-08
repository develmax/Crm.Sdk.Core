using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains metadata that defines a set of options.</summary>
    [DataContract(Name = "OptionSetMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class OptionSetMetadata : OptionSetMetadataBase
    {
        private OptionMetadataCollection _options;

        /// <summary>constructor_initializes<see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata"></see> class</summary>
        public OptionSetMetadata()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata"></see> class</summary>
        /// <param name="options">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionMetadataCollection"></see>The options available in the option set.</param>
        public OptionSetMetadata(OptionMetadataCollection options)
        {
            this._options = options;
        }

        /// <summary>Gets the options available in the option set.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionMetadataCollection"></see>The options available in the option set.</returns>
        [DataMember]
        public OptionMetadataCollection Options
        {
            get
            {
                if (this._options == null)
                    this._options = new OptionMetadataCollection();
                return this._options;
            }
            private set
            {
                this._options = value;
            }
        }
    }
}