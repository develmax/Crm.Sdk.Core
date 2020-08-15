using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for a many-to-many entity relationship.</summary>
    [DataContract(Name = "ManyToManyRelationshipMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class ManyToManyRelationshipMetadata : RelationshipMetadataBase
    {
        private AssociatedMenuConfiguration _entity1AssociatedMenuConfiguration;
        private AssociatedMenuConfiguration _entity2AssociatedMenuConfiguration;
        private string _entity1LogicalName;
        private string _entity2LogicalName;
        private string _intersectEntityName;
        private string _entity1IntersectAttribute;
        private string _entity2IntersectAttribute;

        /// <summary>constructor_initializes<see cref="T:Microsoft.Xrm.Sdk.Metadata.ManyToManyRelationshipMetadata"></see> class</summary>
        public ManyToManyRelationshipMetadata()
          : base(RelationshipType.ManyToManyRelationship)
        {
        }

        /// <summary>Gets or sets the associated menu configuration for the first entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.AssociatedMenuConfiguration"></see>The associated menu configuration for the first entity.</returns>
        [DataMember]
        public AssociatedMenuConfiguration Entity1AssociatedMenuConfiguration
        {
            get
            {
                return this._entity1AssociatedMenuConfiguration;
            }
            set
            {
                this._entity1AssociatedMenuConfiguration = value;
            }
        }

        /// <summary>Gets or sets the associated menu configuration for the second entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.AssociatedMenuConfiguration"></see>The associated menu configuration for the second entity.</returns>
        [DataMember]
        public AssociatedMenuConfiguration Entity2AssociatedMenuConfiguration
        {
            get
            {
                return this._entity2AssociatedMenuConfiguration;
            }
            set
            {
                this._entity2AssociatedMenuConfiguration = value;
            }
        }

        /// <summary>Gets or sets the logical name of the first entity in the relationship.</summary>
        /// <returns>Type: Returns_String
        /// The logical name of the first entity in the relationship.</returns>
        [DataMember]
        public string Entity1LogicalName
        {
            get
            {
                return this._entity1LogicalName;
            }
            set
            {
                this._entity1LogicalName = value;
            }
        }

        /// <summary>Gets or sets the logical name of the second entity in the relationship.</summary>
        /// <returns>Type: Returns_String
        /// The logical name of the second entity in the relationship..</returns>
        [DataMember]
        public string Entity2LogicalName
        {
            get
            {
                return this._entity2LogicalName;
            }
            set
            {
                this._entity2LogicalName = value;
            }
        }

        /// <summary>Gets or sets the name of the intersect entity for the relationship.</summary>
        /// <returns>Type: Returns_String
        /// The name of the intersect entity for the relationship..</returns>
        [DataMember]
        public string IntersectEntityName
        {
            get
            {
                return this._intersectEntityName;
            }
            set
            {
                this._intersectEntityName = value;
            }
        }

        /// <summary>Gets or sets the attribute that defines the relationship in the first entity.</summary>
        /// <returns>Type: Returns_String
        /// The attribute that defines the relationship in the first entity.</returns>
        [DataMember]
        public string Entity1IntersectAttribute
        {
            get
            {
                return this._entity1IntersectAttribute;
            }
            set
            {
                this._entity1IntersectAttribute = value;
            }
        }

        /// <summary>Gets or sets the attribute that defines the relationship in the second entity.</summary>
        /// <returns>Type: Returns_String
        /// The attribute that defines the relationship in the second entity..</returns>
        [DataMember]
        public string Entity2IntersectAttribute
        {
            get
            {
                return this._entity2IntersectAttribute;
            }
            set
            {
                this._entity2IntersectAttribute = value;
            }
        }
    }
}