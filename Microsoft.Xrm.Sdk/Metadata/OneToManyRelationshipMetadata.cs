using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for a one-to-many entity relationship.</summary>
    [DataContract(Name = "OneToManyRelationshipMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class OneToManyRelationshipMetadata : RelationshipMetadataBase
    {
        private AssociatedMenuConfiguration _associatedMenuConfiguration;
        private CascadeConfiguration _cascadeConfiguration;
        private string _referencedAttribute;
        private string _referencedEntity;
        private string _referencingAttribute;
        private string _referencingEntity;
        private bool? _isHierarchical;

        /// <summary>constructor_initializes<see cref="T:Microsoft.Xrm.Sdk.Metadata.OneToManyRelationshipMetadata"></see> class</summary>
        public OneToManyRelationshipMetadata()
          : base(RelationshipType.OneToManyRelationship)
        {
        }

        /// <summary>Gets or sets the associated menu configuration.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.AssociatedMenuConfiguration"></see>The associated menu configuration.</returns>
        [DataMember]
        public AssociatedMenuConfiguration AssociatedMenuConfiguration
        {
            get
            {
                return this._associatedMenuConfiguration;
            }
            set
            {
                this._associatedMenuConfiguration = value;
            }
        }

        /// <summary>Gets or sets cascading behaviors for the entity relationship.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.CascadeConfiguration"></see>The cascading behaviors for the entity relationship.</returns>
        [DataMember]
        public CascadeConfiguration CascadeConfiguration
        {
            get
            {
                return this._cascadeConfiguration;
            }
            set
            {
                this._cascadeConfiguration = value;
            }
        }

        /// <summary>Get or set the name of primary attribute for the referenced entity.</summary>
        /// <returns>Type: Returns_String
        /// The name of primary attribute for the referenced entity..</returns>
        [DataMember]
        public string ReferencedAttribute
        {
            get
            {
                return this._referencedAttribute;
            }
            set
            {
                this._referencedAttribute = value;
            }
        }

        /// <summary>Get or set the name of the referenced entity.</summary>
        /// <returns>Type: Returns_String
        /// The name of the referenced entity.</returns>
        [DataMember]
        public string ReferencedEntity
        {
            get
            {
                return this._referencedEntity;
            }
            set
            {
                this._referencedEntity = value;
            }
        }

        /// <summary>Get or set the name of the referencing attribute.</summary>
        /// <returns>Type: Returns_String
        /// The name of the referencing attribute.</returns>
        [DataMember]
        public string ReferencingAttribute
        {
            get
            {
                return this._referencingAttribute;
            }
            set
            {
                this._referencingAttribute = value;
            }
        }

        /// <summary>Gets or sets the name of the referencing entity.</summary>
        /// <returns>Type: Returns_String
        /// The name of the referencing entity.</returns>
        [DataMember]
        public string ReferencingEntity
        {
            get
            {
                return this._referencingEntity;
            }
            set
            {
                this._referencingEntity = value;
            }
        }

        /// <summary>Gets or sets whether this relationship is the designated hierarchical self-referential relationship for this entity.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if this relationships is the designated hierarchical self-referential relationship for this entity; otherwise, false.</returns>
        [DataMember]
        public bool? IsHierarchical
        {
            get
            {
                return this._isHierarchical;
            }
            set
            {
                this._isHierarchical = value;
            }
        }
    }
}
