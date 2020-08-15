using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains properties representing actions that may be performed on the referenced entity in a one-to-many entity relationship.</summary>
    [DataContract(Name = "CascadeConfiguration", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class CascadeConfiguration : IExtensibleDataObject
    {
        private CascadeType? _cascadeAssign;
        private CascadeType? _cascadeDelete;
        private CascadeType? _cascadeMerge;
        private CascadeType? _cascadeReparent;
        private CascadeType? _cascadeShare;
        private CascadeType? _cascadeUnshare;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>The referenced entity record owner is changed.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.CascadeType"></see>&gt;
        /// The referenced entity record owner is changed.</returns>
        [DataMember]
        public CascadeType? Assign
        {
            get
            {
                return this._cascadeAssign;
            }
            set
            {
                this._cascadeAssign = value;
            }
        }

        /// <summary>The referenced entity record is deleted.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.CascadeType"></see>&gt;
        /// The referenced entity record is deleted.</returns>
        [DataMember]
        public CascadeType? Delete
        {
            get
            {
                return this._cascadeDelete;
            }
            set
            {
                this._cascadeDelete = value;
            }
        }

        /// <summary>The record is merged with another record.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.CascadeType"></see>&gt;
        /// The record is merged with another record..</returns>
        [DataMember]
        public CascadeType? Merge
        {
            get
            {
                return this._cascadeMerge;
            }
            set
            {
                this._cascadeMerge = value;
            }
        }

        /// <summary>The value of the referencing attribute in a parental relationship changes. changes.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.CascadeType"></see>&gt;
        /// The value of the referencing attribute in a parental relationship changes. changes.</returns>
        [DataMember]
        public CascadeType? Reparent
        {
            get
            {
                return this._cascadeReparent;
            }
            set
            {
                this._cascadeReparent = value;
            }
        }

        /// <summary>The referenced entity record is shared with another user.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.CascadeType"></see>&gt;
        /// The referenced entity record is shared with another user.</returns>
        [DataMember]
        public CascadeType? Share
        {
            get
            {
                return this._cascadeShare;
            }
            set
            {
                this._cascadeShare = value;
            }
        }

        /// <summary>Sharing is removed for the referenced entity record.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.CascadeType"></see>&gt;
        /// Sharing is removed for the referenced entity record.</returns>
        [DataMember]
        public CascadeType? Unshare
        {
            get
            {
                return this._cascadeUnshare;
            }
            set
            {
                this._cascadeUnshare = value;
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
