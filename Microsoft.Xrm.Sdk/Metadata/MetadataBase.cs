using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Specifies the base class for classes that contains metadata information.</summary>
    [KnownType(typeof(RelationshipMetadataBase))]
    [DataContract(Name = "MetadataBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    [KnownType(typeof(AttributeMetadata))]
    [KnownType(typeof(EntityMetadata))]
    [KnownType(typeof(OptionSetMetadata))]
    public abstract class MetadataBase : IExtensibleDataObject
    {
        private Guid? _id;
        private bool? _hasChanged;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Gets or sets a unique identifier for the metadata item.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Guid&gt;
        /// The unique identifier for the metadata item.</returns>
        [DataMember]
        public Guid? MetadataId
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        /// <summary>Gets whether the item of metadata has changed.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if metadata item has changed since the last query; otherwise, false.</returns>
        [DataMember(Order = 60)]
        public bool? HasChanged
        {
            get
            {
                return this._hasChanged;
            }
            set
            {
                this._hasChanged = value;
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