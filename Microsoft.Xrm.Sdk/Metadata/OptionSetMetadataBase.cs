using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains data that defines a set of options.</summary>
    [KnownType(typeof(BooleanOptionSetMetadata))]
    [KnownType(typeof(OptionSetMetadata))]
    [DataContract(Name = "OptionSetMetadataBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public abstract class OptionSetMetadataBase : MetadataBase
    {
        private Label _description;
        private Label _displayName;
        private bool? _isCustomOptionSet;
        private bool? _isGlobal;
        private bool? _isManaged;
        private string _name;
        private Microsoft.Xrm.Sdk.Metadata.OptionSetType? _optionSetType;
        private BooleanManagedProperty _isCustomizable;
        private string _introducedVersion;

        /// <summary>Gets or sets a description for the option set.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The description for the option set.</returns>
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

        /// <summary>Gets or sets a display name for a global option set.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The display name for a global option set.</returns>
        [DataMember]
        public Label DisplayName
        {
            get
            {
                return this._displayName;
            }
            set
            {
                this._displayName = value;
            }
        }

        /// <summary>Gets or sets whether the option set is a custom option set.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the option set is a custom option set; otherwise, false.</returns>
        [DataMember]
        public bool? IsCustomOptionSet
        {
            get
            {
                return this._isCustomOptionSet;
            }
            set
            {
                this._isCustomOptionSet = value;
            }
        }

        /// <summary>Gets or sets whether the option set is a global option set.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the option set is a global option set; otherwise, false.</returns>
        [DataMember]
        public bool? IsGlobal
        {
            get
            {
                return this._isGlobal;
            }
            set
            {
                this._isGlobal = value;
            }
        }

        /// <summary>Gets or sets whether the option set is part of a managed solution.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the option set is part of a managed solution; otherwise, false.</returns>
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

        /// <summary>Gets or sets a property that determines whether the option set is customizable.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether the option set is customizable.</returns>
        [DataMember]
        public BooleanManagedProperty IsCustomizable
        {
            get
            {
                return this._isCustomizable;
            }
            set
            {
                this._isCustomizable = value;
            }
        }

        /// <summary>Gets or sets the name of a global option set.</summary>
        /// <returns>Type: Returns_String
        /// The name of a global option set.</returns>
        [DataMember]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        /// <summary>Gets or sets the type of option set.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetType"></see>&gt;
        /// The type of option set.</returns>
        [DataMember]
        public Microsoft.Xrm.Sdk.Metadata.OptionSetType? OptionSetType
        {
            get
            {
                return this._optionSetType;
            }
            set
            {
                this._optionSetType = value;
            }
        }

        /// <summary>introducedversion</summary>
        /// <returns>Type: Returns_String
        /// A string identifying the solution version that the solution component was added in.</returns>
        [DataMember(Order = 60)]
        public string IntroducedVersion
        {
            get
            {
                return this._introducedVersion;
            }
            internal set
            {
                this._introducedVersion = value;
            }
        }
    }
}
