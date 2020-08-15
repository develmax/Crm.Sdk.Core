using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains all the metadata for an entity attribute.</summary>
    [KnownType(typeof(DateTimeAttributeMetadata))]
    [KnownType(typeof(StateAttributeMetadata))]
    [KnownType(typeof(StatusAttributeMetadata))]
    [KnownType(typeof(MemoAttributeMetadata))]
    [KnownType(typeof(BooleanAttributeMetadata))]
    [KnownType(typeof(DecimalAttributeMetadata))]
    [KnownType(typeof(DoubleAttributeMetadata))]
    [KnownType(typeof(EntityNameAttributeMetadata))]
    [KnownType(typeof(ManagedPropertyAttributeMetadata))]
    [KnownType(typeof(IntegerAttributeMetadata))]
    [KnownType(typeof(BigIntAttributeMetadata))]
    [KnownType(typeof(LookupAttributeMetadata))]
    [KnownType(typeof(ImageAttributeMetadata))]
    [KnownType(typeof(MoneyAttributeMetadata))]
    [KnownType(typeof(PicklistAttributeMetadata))]
    [DataContract(Name = "AttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    [KnownType(typeof(StringAttributeMetadata))]
    public class AttributeMetadata : MetadataBase
    {
        private string _attributeOf;
        private AttributeTypeCode? _attributeType;
        private AttributeTypeDisplayName _attributeTypeDisplayName;
        private int? _columnNumber;
        private Label _description;
        private Label _displayName;
        private string _entityLogicalName;
        private BooleanManagedProperty _isAuditEnabled;
        private bool? _isCustomAttribute;
        private bool? _isPrimaryId;
        private bool? _isPrimaryAttribute;
        private Guid? _linkedAttributeId;
        private string _logicalName;
        private string _schemaName;
        private bool? _validForCreate;
        private bool? _validForRead;
        private bool? _validForUpdate;
        private bool? _isSecured;
        private bool? _canBeSecuredForRead;
        private bool? _canBeSecuredForCreate;
        private bool? _canBeSecuredForUpdate;
        private bool? _isManaged;
        private string _deprecatedVersion;
        private string _introducedVersion;
        private BooleanManagedProperty _isCustomizable;
        private BooleanManagedProperty _isRenameable;
        private BooleanManagedProperty _isValidForAdvancedFind;
        private AttributeRequiredLevelManagedProperty _requiredLevel;
        private BooleanManagedProperty _canModifyAdditionalSettings;
        private string _aggregateOf;
        private bool? _isLogical;
        private int _displayMask;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeMetadata"></see> class.</summary>
        public AttributeMetadata()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeMetadata"></see> class.</summary>
        /// <param name="attributeType">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode"></see>. Sets the type for the attribute.</param>
        protected AttributeMetadata(AttributeTypeCode attributeType)
          : this()
        {
            this.AttributeType = new AttributeTypeCode?(attributeType);
            this.AttributeTypeName = this.GetAttributeTypeDisplayName(attributeType);
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeMetadata"></see> class.</summary>
        /// <param name="attributeType">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode"></see>. Sets the type for the attribute.</param>
        /// <param name="schemaName">Type: Returns_String. Sets the schema name of the attribute.</param>
        protected AttributeMetadata(AttributeTypeCode attributeType, string schemaName)
          : this(attributeType)
        {
            this.SchemaName = schemaName;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private AttributeTypeDisplayName GetAttributeTypeDisplayName(
          AttributeTypeCode attributeType)
        {
            switch (attributeType)
            {
                case AttributeTypeCode.Boolean:
                    return AttributeTypeDisplayName.BooleanType;
                case AttributeTypeCode.Customer:
                    return AttributeTypeDisplayName.CustomerType;
                case AttributeTypeCode.DateTime:
                    return AttributeTypeDisplayName.DateTimeType;
                case AttributeTypeCode.Decimal:
                    return AttributeTypeDisplayName.DecimalType;
                case AttributeTypeCode.Double:
                    return AttributeTypeDisplayName.DoubleType;
                case AttributeTypeCode.Integer:
                    return AttributeTypeDisplayName.IntegerType;
                case AttributeTypeCode.Lookup:
                    return AttributeTypeDisplayName.LookupType;
                case AttributeTypeCode.Memo:
                    return AttributeTypeDisplayName.MemoType;
                case AttributeTypeCode.Money:
                    return AttributeTypeDisplayName.MoneyType;
                case AttributeTypeCode.Owner:
                    return AttributeTypeDisplayName.OwnerType;
                case AttributeTypeCode.PartyList:
                    return AttributeTypeDisplayName.PartyListType;
                case AttributeTypeCode.Picklist:
                    return AttributeTypeDisplayName.PicklistType;
                case AttributeTypeCode.State:
                    return AttributeTypeDisplayName.StateType;
                case AttributeTypeCode.Status:
                    return AttributeTypeDisplayName.StatusType;
                case AttributeTypeCode.String:
                    return AttributeTypeDisplayName.StringType;
                case AttributeTypeCode.Uniqueidentifier:
                    return AttributeTypeDisplayName.UniqueidentifierType;
                case AttributeTypeCode.CalendarRules:
                    return AttributeTypeDisplayName.CalendarRulesType;
                case AttributeTypeCode.Virtual:
                    return AttributeTypeDisplayName.VirtualType;
                case AttributeTypeCode.BigInt:
                    return AttributeTypeDisplayName.BigIntType;
                case AttributeTypeCode.ManagedProperty:
                    return AttributeTypeDisplayName.ManagedPropertyType;
                case AttributeTypeCode.EntityName:
                    return AttributeTypeDisplayName.EntityNameType;
                default:
                    return (AttributeTypeDisplayName)null;
            }
        }

        /// <summary>Gets the name of that attribute that this attribute extends.</summary>
        /// <returns>Type: Returns_String
        /// The attribute name.</returns>
        [DataMember]
        public string AttributeOf
        {
            get
            {
                return this._attributeOf;
            }
            internal set
            {
                this._attributeOf = value;
            }
        }

        /// <summary>Gets the type for the attribute.</summary>
        /// <returns>Type:  Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode"></see>&gt;
        /// The attribute type.</returns>
        [DataMember]
        public AttributeTypeCode? AttributeType
        {
            get
            {
                return this._attributeType;
            }
            internal set
            {
                this._attributeType = value;
            }
        }

        /// <summary>Gets the name of the type for the attribute.</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeTypeDisplayName"></see>
        /// The name of the attribute type.</returns>
        [DataMember(Order = 60)]
        public AttributeTypeDisplayName AttributeTypeName
        {
            get
            {
                return this._attributeTypeDisplayName;
            }
            internal set
            {
                this._attributeTypeDisplayName = value;
            }
        }

        /// <summary>Gets an organization specific id for the attribute used for auditing.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The organization specific id for the attribute used for auditing.</returns>
        [DataMember]
        public int? ColumnNumber
        {
            get
            {
                return this._columnNumber;
            }
            internal set
            {
                this._columnNumber = value;
            }
        }

        /// <summary>Gets or sets the description of the attribute.</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The description of the attribute.</returns>
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

        /// <summary>Gets or sets the display name for the attribute.</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The display name of the attribute.</returns>
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

        /// <summary>Gets the pn_microsoftcrm version that the attribute was deprecated in.</summary>
        /// <returns>Type: Returns_String
        /// The pn_microsoftcrm version that the attribute was deprecated in.</returns>
        [DataMember]
        public string DeprecatedVersion
        {
            get
            {
                return this._deprecatedVersion;
            }
            internal set
            {
                this._deprecatedVersion = value;
            }
        }

        /// <summary>introducedversion</summary>
        /// <returns>Type: Returns_String
        /// The solution version number when the attribute was created.</returns>
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

        /// <summary>Gets the logical name of the entity that contains the attribute.</summary>
        /// <returns>Type: Returns_String
        /// The logical name of the entity that contains the attribute.</returns>
        [DataMember]
        public string EntityLogicalName
        {
            get
            {
                return this._entityLogicalName;
            }
            internal set
            {
                this._entityLogicalName = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether the attribute is enabled for auditing.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>
        /// The property that determines whether the attribute is enabled for auditing.</returns>
        [DataMember]
        public BooleanManagedProperty IsAuditEnabled
        {
            get
            {
                return this._isAuditEnabled;
            }
            set
            {
                this._isAuditEnabled = value;
            }
        }

        /// <summary>Gets whether the attribute is a custom attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the attribute is a custom attribute; otherwise, false.</returns>
        [DataMember]
        public bool? IsCustomAttribute
        {
            get
            {
                return this._isCustomAttribute;
            }
            internal set
            {
                this._isCustomAttribute = value;
            }
        }

        /// <summary>Gets whether the attribute represents the unique identifier for the record.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the attribute is the unique identifier for the record; otherwise, false.</returns>
        [DataMember]
        public bool? IsPrimaryId
        {
            get
            {
                return this._isPrimaryId;
            }
            internal set
            {
                this._isPrimaryId = value;
            }
        }

        /// <summary>Gets or sets whether the attribute represents the primary attribute for the entity.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the attribute is primary attribute for the entity; otherwise, false.</returns>
        [DataMember]
        public bool? IsPrimaryName
        {
            get
            {
                return this._isPrimaryAttribute;
            }
            internal set
            {
                this._isPrimaryAttribute = value;
            }
        }

        /// <summary>Gets whether the value can be set when a record is created.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the value can be set when a record is created; otherwise, false.</returns>
        [DataMember]
        public bool? IsValidForCreate
        {
            get
            {
                return this._validForCreate;
            }
            internal set
            {
                this._validForCreate = value;
            }
        }

        /// <summary>Gets whether the value can be retrieved.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the value can be retrieved; otherwise, false.</returns>
        [DataMember]
        public bool? IsValidForRead
        {
            get
            {
                return this._validForRead;
            }
            internal set
            {
                this._validForRead = value;
            }
        }

        /// <summary>Gets whether the value can be updated.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the value can be updated; otherwise, false.</returns>
        [DataMember]
        public bool? IsValidForUpdate
        {
            get
            {
                return this._validForUpdate;
            }
            internal set
            {
                this._validForUpdate = value;
            }
        }

        /// <summary>Gets whether field level security can be applied to prevent a user from viewing data from this attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the field security can be applied; otherwise, false.</returns>
        [DataMember]
        public bool? CanBeSecuredForRead
        {
            get
            {
                return this._canBeSecuredForRead;
            }
            internal set
            {
                this._canBeSecuredForRead = value;
            }
        }

        /// <summary>Gets whether field security can be applied to prevent a user from adding data to this attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the field security can be applied; otherwise, false.</returns>
        [DataMember]
        public bool? CanBeSecuredForCreate
        {
            get
            {
                return this._canBeSecuredForCreate;
            }
            internal set
            {
                this._canBeSecuredForCreate = value;
            }
        }

        /// <summary>Gets whether field level security can be applied to prevent a user from updating data for this attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the field security can be applied; otherwise, false.</returns>
        [DataMember]
        public bool? CanBeSecuredForUpdate
        {
            get
            {
                return this._canBeSecuredForUpdate;
            }
            internal set
            {
                this._canBeSecuredForUpdate = value;
            }
        }

        /// <summary>Gets or sets whether the attribute is secured for field level security.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the attribute is secured for field level security; otherwise, false.</returns>
        [DataMember]
        public bool? IsSecured
        {
            get
            {
                return this._isSecured;
            }
            set
            {
                this._isSecured = value;
            }
        }

        /// <summary>Gets whether the attribute is part of a managed solution.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the attribute is part of a managed solution; otherwise, false.</returns>
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

        /// <summary>Gets or sets an attribute that is linked between Appointments and Recurring appointments.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Guid&gt;
        /// The attribute id that is linked between Appointments and Recurring appointments.</returns>
        [DataMember]
        public Guid? LinkedAttributeId
        {
            get
            {
                return this._linkedAttributeId;
            }
            set
            {
                this._linkedAttributeId = value;
            }
        }

        /// <summary>Gets or sets the logical name for the attribute.</summary>
        /// <returns>Type: Returns_String
        /// The logical name for the attribute.</returns>
        [DataMember]
        public string LogicalName
        {
            get
            {
                return this._logicalName;
            }
            set
            {
                this._logicalName = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether the attribute allows customization.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether the attribute allows customization.</returns>
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

        /// <summary>Gets or sets the property that determines whether the attribute display name can be changed.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether the attribute display name can be changed.</returns>
        [DataMember]
        public BooleanManagedProperty IsRenameable
        {
            get
            {
                return this._isRenameable;
            }
            set
            {
                this._isRenameable = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether the attribute appears in Advanced Find.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether the attribute appears in Advanced Find.</returns>
        [DataMember]
        public BooleanManagedProperty IsValidForAdvancedFind
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

        /// <summary>Gets or sets the property that determines the data entry requirement level enforced for the attribute.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeRequiredLevelManagedProperty"></see>The property that determines the data entry requirement level enforced for the attribute.</returns>
        [DataMember]
        public AttributeRequiredLevelManagedProperty RequiredLevel
        {
            get
            {
                return this._requiredLevel;
            }
            set
            {
                this._requiredLevel = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether any settings not controlled by managed properties can be changed.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether any settings not controlled by managed properties can be changed.</returns>
        [DataMember]
        public BooleanManagedProperty CanModifyAdditionalSettings
        {
            get
            {
                return this._canModifyAdditionalSettings;
            }
            set
            {
                this._canModifyAdditionalSettings = value;
            }
        }

        /// <summary>Gets or sets the schema name for the attribute.</summary>
        /// <returns>Type: Returns_String
        /// The schema name for the attribute.</returns>
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

        internal int DisplayMask
        {
            get
            {
                return this._displayMask;
            }
            set
            {
                this._displayMask = value;
            }
        }

        internal string AggregateOf
        {
            get
            {
                return this._aggregateOf;
            }
            set
            {
                this._aggregateOf = value;
            }
        }

        [DataMember(Order = 70)]
        public bool? IsLogical
        {
            get
            {
                return this._isLogical;
            }
            internal set
            {
                this._isLogical = value;
            }
        }

        /// <summary>Gets or sets the value that indicates the source type for a calculated or rollup attribute.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt; The value that indicates the source type for a calculated or rollup attribute.</returns>
        [DataMember(Order = 70)]
        public int? SourceType { get; set; }
    }
}
