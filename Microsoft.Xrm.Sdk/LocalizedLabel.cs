using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains a localized label, including the label string and the language code.</summary>
    [DataContract(Name = "LocalizedLabel", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class LocalizedLabel : MetadataBase
    {
        private string _label;
        private int _languageCode;
        private bool? _isManaged;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.LocalizedLabel"></see> class.</summary>
        public LocalizedLabel()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.LocalizedLabel"></see> class setting the label string and the language code.</summary>
        /// <param name="label">Type: Returns_String
        /// The localized label string..</param>
        /// <param name="languageCode">Type: Returns_Int32
        /// The language code for the label.</param>
        public LocalizedLabel(string label, int languageCode)
        {
            this.Label = label;
            this.LanguageCode = languageCode;
        }

        /// <summary>Gets or sets the localized label string.</summary>
        /// <returns>Type: Returns_String
        /// The localized label string..</returns>
        [DataMember]
        public string Label
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

        /// <summary>Gets or sets the language code for the label.</summary>
        /// <returns>Type: Returns_Int32
        /// The language code for the label..</returns>
        [DataMember]
        public int LanguageCode
        {
            get
            {
                return this._languageCode;
            }
            set
            {
                this._languageCode = value;
            }
        }

        /// <summary>Gets or sets whether the label is managed.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the label is managed; otherwise, false.</returns>
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
