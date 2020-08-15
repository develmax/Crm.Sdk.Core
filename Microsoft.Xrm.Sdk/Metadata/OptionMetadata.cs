using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains metadata representing an option within an Option set.</summary>
    [KnownType(typeof(StatusOptionMetadata))]
    [DataContract(Name = "OptionMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    [KnownType(typeof(StateOptionMetadata))]
    public class OptionMetadata : MetadataBase
    {
        private int? _optionValue;
        private Label _label;
        private Label _description;
        private bool? _isManaged;

        /// <summary>constructor_initializes<see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionMetadata"></see> class</summary>
        public OptionMetadata()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionMetadata"></see> class</summary>
        /// <param name="value">Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The value of the option.</param>
        public OptionMetadata(int value)
          : this()
        {
            this.Value = new int?(value);
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionMetadata"></see> class</summary>
        /// <param name="value">Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The value of the option.</param>
        /// <param name="label">Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The label containing the text for the option..</param>
        public OptionMetadata(Label label, int? value)
        {
            this.Label = label;
            this.Value = value;
        }

        /// <summary>Gets or sets the value of the option.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The value of the option.</returns>
        [DataMember]
        public int? Value
        {
            get
            {
                return this._optionValue;
            }
            set
            {
                this._optionValue = value;
            }
        }

        /// <summary>Gets or sets the label containing the text for the option.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The label containing the text for the option..</returns>
        [DataMember]
        public Label Label
        {
            get
            {
                return this._label;
            }
            set
            {
                this._label = value;
            }
        }

        /// <summary>Gets or sets the label containing the description for the option.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The label containing the description for the option..</returns>
        [DataMember]
        public Label Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        /// <summary>Gets whether the option is part of a managed solution.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the option is part of a managed solution.; otherwise, false</returns>
        [DataMember]
        public bool? IsManaged
        {
            get
            {
                return this._isManaged;
            }
            internal set
            {
                this._isManaged = value;
            }
        }
    }
}