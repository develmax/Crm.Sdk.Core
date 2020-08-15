using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an entity relationship.</summary>
    [DataContract(Name = "RelationshipMetadataBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    [KnownType(typeof(OneToManyRelationshipMetadata))]
    [KnownType(typeof(ManyToManyRelationshipMetadata))]
    public abstract class RelationshipMetadataBase : MetadataBase
    {
        private bool? _isCustomRelationship;
        private bool? _isValidForAdvancedFind;
        private string _schemaName;
        private Microsoft.Xrm.Sdk.Metadata.SecurityTypes? _securityTypes;
        private bool? _isManaged;
        private BooleanManagedProperty _isCustomizable;
        private RelationshipType _type;
        private string _introducedVersion;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase"></see> class</summary>
        protected RelationshipMetadataBase()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase"></see> class</summary>
        /// <param name="type">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.RelationshipType"></see>
        /// The type of relationship.</param>
        protected RelationshipMetadataBase(RelationshipType type)
        {
            this._type = type;
        }

        /// <summary>Gets whether the relationship is a custom relationship.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the relationship is a custom relationship; otherwise, false.</returns>
        [DataMember]
        public bool? IsCustomRelationship
        {
            get
            {
                return this._isCustomRelationship;
            }
            set
            {
                this._isCustomRelationship = value;
            }
        }

        /// <summary>Gets or sets whether the entity relationship is customizable.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>Whether the entity relationship is customizable.</returns>
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

        /// <summary>Gets or sets whether the entity relationship should be shown in Advanced Find.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity relationship should be shown in Advanced Find; otherwise, false.</returns>
        [DataMember]
        public bool? IsValidForAdvancedFind
        {
            get
            {
                return this._isValidForAdvancedFind;
            }
            set
            {
                this._isValidForAdvancedFind = value;
            }
        }

        /// <summary>Gets or sets the schema name for the entity relationship.</summary>
        /// <returns>Type: Returns_String
        /// The schema name for the entity relationship.</returns>
        [DataMember]
        public string SchemaName
        {
            get
            {
                return this._schemaName;
            }
            set
            {
                this._schemaName = value;
            }
        }

        /// <summary>Gets or sets the security type for the relationship.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.SecurityTypes"></see>&gt;
        /// The security type for the relationship.</returns>
        [DataMember]
        public Microsoft.Xrm.Sdk.Metadata.SecurityTypes? SecurityTypes
        {
            get
            {
                return this._securityTypes;
            }
            set
            {
                this._securityTypes = value;
            }
        }

        /// <summary>Gets whether the entity relationship is part of a managed solution. </summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity relationships is part of a managed solution; otherwise, false.</returns>
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

        /// <summary>Gets the type of relationship.</summary>
        /// <returns>Type:<see cref="T:Microsoft.Xrm.Sdk.Metadata.RelationshipType"></see>.</returns>
        [DataMember(Order = 60)]
        public RelationshipType RelationshipType
        {
            get
            {
                return this._type;
            }
            internal set
            {
                this._type = value;
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
