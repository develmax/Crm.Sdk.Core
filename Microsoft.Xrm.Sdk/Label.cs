using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains a collection of translations for a label.</summary>
    [DataContract(Name = "Label", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class Label : IExtensibleDataObject
    {
        private LocalizedLabelCollection _locLabels;
        private LocalizedLabel _userLocLabel;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Label"></see> class.</summary>
        public Label()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Label"></see> class.</summary>
        /// <param name="label">Type: Returns_String. The string for the user localized label.</param>
        /// <param name="languageCode">Type: Returns_Int32. The language code for the label. </param>
        public Label(string label, int languageCode)
        {
            this._locLabels = new LocalizedLabelCollection();
            this._locLabels.Add(new LocalizedLabel(label, languageCode));
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Label"></see> class.</summary>
        /// <param name="userLocalizedLabel">Type: <see cref="T:Microsoft.Xrm.Sdk.LocalizedLabel"></see>. The label for the language of the current user.</param>
        /// <param name="labels">Type: <see cref="T:Microsoft.Xrm.Sdk.LocalizedLabel"></see>[]. An array of localized labels.</param>
        public Label(LocalizedLabel userLocalizedLabel, LocalizedLabel[] labels)
        {
            this._userLocLabel = userLocalizedLabel;
            if (labels == null)
                return;
            this._locLabels = new LocalizedLabelCollection((IList<LocalizedLabel>)labels);
        }

        /// <summary>Gets the collection of localized labels.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.LocalizedLabelCollection"></see> The collection of localized labels.</returns>
        [DataMember]
        public LocalizedLabelCollection LocalizedLabels
        {
            get
            {
                if (this._locLabels == null)
                    this._locLabels = new LocalizedLabelCollection();
                return this._locLabels;
            }
            private set
            {
                this._locLabels = value;
            }
        }

        /// <summary>Gets or set the label for the language of the current user.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.LocalizedLabel"></see>The label for the language of the current user.</returns>
        [DataMember]
        public LocalizedLabel UserLocalizedLabel
        {
            get
            {
                return this._userLocLabel;
            }
            set
            {
                this._userLocLabel = value;
            }
        }

        /// <summary>ExtensionData</summary>
        /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return this._extensionDataObject;
            }
            set
            {
                this._extensionDataObject = value;
            }
        }
    }
}
