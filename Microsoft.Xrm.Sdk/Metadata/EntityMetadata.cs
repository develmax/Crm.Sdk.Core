using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an entity. </summary>
    [DataContract(Name = "EntityMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class EntityMetadata : MetadataBase
    {
        private int? _activityTypeMask;
        private AttributeMetadata[] _attributes;
        private bool? _canTriggerWorkflow;
        private Label _description;
        private Label _displayCollectionName;
        private Label _displayName;
        private bool? _isDocumentMangementEnabled;
        private bool? _isActivity;
        private bool? _isActivityParty;
        private BooleanManagedProperty _isAuditEnabled;
        private bool? _isAvailableOffline;
        private bool? _isChildEntity;
        private bool? _isAIRUpdated;
        private bool? _autoCreateAccessTeams;
        private BooleanManagedProperty _isValidForQueue;
        private BooleanManagedProperty _isConnectionsEnabled;
        private string _iconLargeName;
        private string _iconMediumName;
        private string _iconSmallName;
        private bool? _isCustomEntity;
        private bool? _isBusinessProcessEnabled;
        private BooleanManagedProperty _isCustomizable;
        private BooleanManagedProperty _isRenameable;
        private BooleanManagedProperty _isMappable;
        private BooleanManagedProperty _isDuplicateDetectionEnabled;
        private bool? _isImportable;
        private bool? _isIntersect;
        private BooleanManagedProperty _isMailMergeEnabled;
        private bool? autoRouteToOwnerQueue;
        private bool? _isEnabledForCharts;
        private bool? _isEnabledForTrace;
        private bool? _isValidForAdvancedFind;
        private string _entityHelpUrl;
        private bool? _entityHelpUrlEnabled;
        private BooleanManagedProperty _isVisibleInMobile;
        private BooleanManagedProperty _isVisibleInMobileClient;
        private BooleanManagedProperty _isReadOnlyInMobileClient;
        private string _logicalName;
        private ManyToManyRelationshipMetadata[] _manyToManyRelationships;
        private OneToManyRelationshipMetadata[] _manyToOneRelationships;
        private int? _objectTypeCode;
        private OneToManyRelationshipMetadata[] _oneToManyRelationships;
        private OwnershipTypes? _ownershipType;
        private string _primaryNameAttribute;
        private string _primaryImageAttribute;
        private string _primaryIdAttribute;
        private SecurityPrivilegeMetadata[] _privileges;
        private string _recurrenceBaseEntityLogicalName;
        private string _reportViewName;
        private string _schemaName;
        private string _physicalName;
        private int? _workflowSupport;
        private bool? _isManaged;
        private bool? _isReadingPaneEnabled;
        private bool? _isQuickCreateEnabled;
        private string _introducedVersion;
        private bool? _isStateModelAware;
        private bool? _enforceStateTransitions;
        private BooleanManagedProperty _canCreateAttributes;
        private BooleanManagedProperty _canCreateForms;
        private BooleanManagedProperty _canCreateCharts;
        private BooleanManagedProperty _canCreateViews;
        private BooleanManagedProperty _canBeRelatedEntityInRelationship;
        private BooleanManagedProperty _canBePrimaryEntityInRelationship;
        private BooleanManagedProperty _canBeInManyToMany;
        private BooleanManagedProperty _canModifyAdditionalSettings;
        private BooleanManagedProperty _canChangeHierarchicalRelationship;

        /// <summary>Gets or sets whether a custom activity should appear in the activity menus in the Web application.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The value indicates whether a custom activity should appear in the activity menus in the Web application.</returns>
        [DataMember]
        public int? ActivityTypeMask
        {
            get
            {
                return this._activityTypeMask;
            }
            set
            {
                this._activityTypeMask = value;
            }
        }

        /// <summary>Gets the array of attribute metadata for the entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeMetadata"></see>[]The array of attribute metadata for the entity.</returns>
        [DataMember]
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        public AttributeMetadata[] Attributes
        {
            get
            {
                return this._attributes;
            }
            internal set
            {
                this._attributes = value;
            }
        }

        /// <summary>Gets or sets whether to automatically move records to the owner’s default queue when a record of this type is created or assigned.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the record will automatically move to the owner’s default queue when a record of this type is created or assigned; otherwise, false.</returns>
        [DataMember]
        public bool? AutoRouteToOwnerQueue
        {
            get
            {
                return this.autoRouteToOwnerQueue;
            }
            set
            {
                this.autoRouteToOwnerQueue = value;
            }
        }

        /// <summary>Gets whether the entity can trigger a workflow process.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity can trigger a workflow process; otherwise, false.</returns>
        [DataMember]
        public bool? CanTriggerWorkflow
        {
            get
            {
                return this._canTriggerWorkflow;
            }
            internal set
            {
                this._canTriggerWorkflow = value;
            }
        }

        /// <summary>Gets or sets the label containing the description for the entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The label containing the description for the entity.</returns>
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

        /// <summary>Gets or sets the label containing the plural display name for the entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The label containing the plural display name for the entity.</returns>
        [DataMember]
        public Label DisplayCollectionName
        {
            get
            {
                return this._displayCollectionName;
            }
            set
            {
                this._displayCollectionName = value;
            }
        }

        /// <summary>Gets or sets the label containing the display name for the entity.</summary>
        /// <returns>Type <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The label containing the display name for the entity.</returns>
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

        /// <summary>Gets or sets whether the entity supports custom help content.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity supports custom help content.; otherwise, false.</returns>
        [DataMember(Order = 70)]
        public bool? EntityHelpUrlEnabled
        {
            get
            {
                return this._entityHelpUrlEnabled;
            }
            set
            {
                this._entityHelpUrlEnabled = value;
            }
        }

        /// <summary>Gets or sets the URL of the resource to display help content for this entity</summary>
        /// <returns>Type: Returns_String
        /// The URL of the resource to display help content for this entity</returns>
        [DataMember(Order = 70)]
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "This url string will be saved in database")]
        public string EntityHelpUrl
        {
            get
            {
                return this._entityHelpUrl;
            }
            set
            {
                this._entityHelpUrl = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether document management is enabled.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>&gt;The property that determines whether document management is enabled..</returns>
        [DataMember]
        public bool? IsDocumentManagementEnabled
        {
            get
            {
                return this._isDocumentMangementEnabled;
            }
            set
            {
                this._isDocumentMangementEnabled = value;
            }
        }

        /// <summary>Gets or sets whether the entity is enabled for auto created access teams.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity will be enabled for auto created access teams; otherwise, false.</returns>
        [DataMember]
        public bool? AutoCreateAccessTeams
        {
            get
            {
                return this._autoCreateAccessTeams;
            }
            set
            {
                this._autoCreateAccessTeams = value;
            }
        }

        /// <summary>Gets or sets whether the entity is an activity.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity is an activity; otherwise, false.</returns>
        [DataMember]
        public bool? IsActivity
        {
            get
            {
                return this._isActivity;
            }
            set
            {
                this._isActivity = value;
            }
        }

        /// <summary>Gets or sets whether the email messages can be sent to an email address stored in a record of this type.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if emails can be sent to an email address stored in a record of this type; otherwise, false.</returns>
        [DataMember]
        public bool? IsActivityParty
        {
            get
            {
                return this._isActivityParty;
            }
            set
            {
                this._isActivityParty = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether auditing has been enabled for the entity.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>&gt;The property that determines whether auditing has been enabled for the entity.</returns>
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

        /// <summary>Gets or sets whether the entity is available offline.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity is available offline; otherwise, false.</returns>
        [DataMember]
        public bool? IsAvailableOffline
        {
            get
            {
                return this._isAvailableOffline;
            }
            set
            {
                this._isAvailableOffline = value;
            }
        }

        /// <summary>Gets whether the entity is a child entity.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity is a child entity; otherwise, false.</returns>
        [DataMember]
        public bool? IsChildEntity
        {
            get
            {
                return this._isChildEntity;
            }
            internal set
            {
                this._isChildEntity = value;
            }
        }

        /// <summary>Gets whether the entity uses the updated user interface.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity uses the updated user interface; otherwise, false.</returns>
        [DataMember]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "AIR is abbrevation so should be upper cased", MessageId = "")]
        public bool? IsAIRUpdated
        {
            get
            {
                return this._isAIRUpdated;
            }
            internal set
            {
                this._isAIRUpdated = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether the entity is enabled for queues.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether the entity is enabled for queues.</returns>
        [DataMember]
        public BooleanManagedProperty IsValidForQueue
        {
            get
            {
                return this._isValidForQueue;
            }
            set
            {
                this._isValidForQueue = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether connections are enabled for this entity.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>&gt;The property that determines whether connections are enabled for this entity.</returns>
        [DataMember]
        public BooleanManagedProperty IsConnectionsEnabled
        {
            get
            {
                return this._isConnectionsEnabled;
            }
            set
            {
                this._isConnectionsEnabled = value;
            }
        }

        /// <summary>Gets or sets the name of the image web resource for the large icon for the entity.</summary>
        /// <returns>Type: Returns_String
        /// The name of the image web resource for the large icon for the entity..</returns>
        [DataMember]
        public string IconLargeName
        {
            get
            {
                return this._iconLargeName;
            }
            set
            {
                this._iconLargeName = value;
            }
        }

        /// <summary>Gets or sets the name of the image web resource for the medium icon for the entity.</summary>
        /// <returns>Type: Returns_String
        /// The name of the image web resource for the medium icon for the entity..</returns>
        [DataMember]
        public string IconMediumName
        {
            get
            {
                return this._iconMediumName;
            }
            set
            {
                this._iconMediumName = value;
            }
        }

        /// <summary>Gets or sets the name of the image web resource for the small icon for the entity.</summary>
        /// <returns>Type: Returns_String
        /// The name of the image web resource for the small icon for the entity.</returns>
        [DataMember]
        public string IconSmallName
        {
            get
            {
                return this._iconSmallName;
            }
            set
            {
                this._iconSmallName = value;
            }
        }

        /// <summary>Gets whether the entity is a custom entity.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity is a custom entity; otherwise, false.</returns>
        [DataMember]
        public bool? IsCustomEntity
        {
            get
            {
                return this._isCustomEntity;
            }
            internal set
            {
                this._isCustomEntity = value;
            }
        }

        /// <summary>Gets whether the entity is enabled for business process flows.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if; the entity is enabled for business process flows otherwise, false.</returns>
        [DataMember]
        public bool? IsBusinessProcessEnabled
        {
            get
            {
                return this._isBusinessProcessEnabled;
            }
            set
            {
                this._isBusinessProcessEnabled = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether the entity is customizable.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether the entity is customizable.</returns>
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

        /// <summary>Gets or sets the property that determines whether the entity <see cref="P:Microsoft.Xrm.Sdk.Metadata.EntityMetadata.DisplayName"></see> and <see cref="P:Microsoft.Xrm.Sdk.Metadata.EntityMetadata.DisplayCollectionName"></see> can be changed by editing the entity in the application.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether the entity <see cref="P:Microsoft.Xrm.Sdk.Metadata.EntityMetadata.DisplayName"></see> and <see cref="P:Microsoft.Xrm.Sdk.Metadata.EntityMetadata.DisplayCollectionName"></see> can be changed by editing the entity in the application.</returns>
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

        /// <summary>Gets or sets the property that determines whether entity mapping is available for the entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether entity mapping is available for the entity..</returns>
        [DataMember]
        public BooleanManagedProperty IsMappable
        {
            get
            {
                return this._isMappable;
            }
            set
            {
                this._isMappable = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether duplicate detection is enabled.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether duplicate detection is enabled..</returns>
        [DataMember]
        public BooleanManagedProperty IsDuplicateDetectionEnabled
        {
            get
            {
                return this._isDuplicateDetectionEnabled;
            }
            set
            {
                this._isDuplicateDetectionEnabled = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether additional attributes can be added to the entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether additional attributes can be added to the entity.</returns>
        [DataMember]
        public BooleanManagedProperty CanCreateAttributes
        {
            get
            {
                return this._canCreateAttributes;
            }
            set
            {
                this._canCreateAttributes = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether new forms can be created for the entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether new forms can be created for the entity.</returns>
        [DataMember]
        public BooleanManagedProperty CanCreateForms
        {
            get
            {
                return this._canCreateForms;
            }
            set
            {
                this._canCreateForms = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether new views can be created for the entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether new views can be created for the entity.</returns>
        [DataMember]
        public BooleanManagedProperty CanCreateViews
        {
            get
            {
                return this._canCreateViews;
            }
            set
            {
                this._canCreateViews = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether new charts can be created for the entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether new charts can be created for the entity.</returns>
        [DataMember]
        public BooleanManagedProperty CanCreateCharts
        {
            get
            {
                return this._canCreateCharts;
            }
            set
            {
                this._canCreateCharts = value;
            }
        }

        /// <summary>Gets the property that determines whether the entity can be the referencing entity in a One-to-Many entity relationship.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether the entity can be the referencing entity in a One-to-Many entity relationship.</returns>
        [DataMember]
        public BooleanManagedProperty CanBeRelatedEntityInRelationship
        {
            get
            {
                return this._canBeRelatedEntityInRelationship;
            }
            internal set
            {
                this._canBeRelatedEntityInRelationship = value;
            }
        }

        /// <summary>Gets the property that determines whether the entity can be the referenced entity in a One-to-Many entity relationship.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether the entity can be the referenced entity in a One-to-Many entity relationship.</returns>
        [DataMember]
        public BooleanManagedProperty CanBePrimaryEntityInRelationship
        {
            get
            {
                return this._canBePrimaryEntityInRelationship;
            }
            internal set
            {
                this._canBePrimaryEntityInRelationship = value;
            }
        }

        /// <summary>Gets the property that determines whether the entity can be in a Many-to-Many entity relationship.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether the entity can be in a Many-to-Many entity relationship.</returns>
        [DataMember]
        public BooleanManagedProperty CanBeInManyToMany
        {
            get
            {
                return this._canBeInManyToMany;
            }
            internal set
            {
                this._canBeInManyToMany = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether any other entity properties not represented by a managed property can be changed.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether any other entity properties not represented by a managed property can be changed.</returns>
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

        /// <summary>Gets or sets whether the hierarchical state of entity relationships included in your managed solutions can be changed.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether the hierarchical state of entity relationships included in your managed solutions can be changed.</returns>
        [DataMember(Order = 70)]
        public BooleanManagedProperty CanChangeHierarchicalRelationship
        {
            get
            {
                return this._canChangeHierarchicalRelationship;
            }
            set
            {
                this._canChangeHierarchicalRelationship = value;
            }
        }

        /// <summary>Gets whether the entity can be imported using the Import Wizard.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity can be imported using the Import Wizard; otherwise, false.</returns>
        [DataMember]
        public bool? IsImportable
        {
            get
            {
                return this._isImportable;
            }
            internal set
            {
                this._isImportable = value;
            }
        }

        /// <summary>Gets whether the entity is an intersection table for two other entities.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity is an intersection table for two other entities.; otherwise, false</returns>
        [DataMember]
        public bool? IsIntersect
        {
            get
            {
                return this._isIntersect;
            }
            internal set
            {
                this._isIntersect = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether mail merge is enabled for this entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether mail merge is enabled for this entity..</returns>
        [DataMember]
        public BooleanManagedProperty IsMailMergeEnabled
        {
            get
            {
                return this._isMailMergeEnabled;
            }
            set
            {
                this._isMailMergeEnabled = value;
            }
        }

        /// <summary>Gets whether the entity is part of a managed solution.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity is part of a managed solution; otherwise, false.</returns>
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

        /// <summary>Gets whether charts are enabled.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if charts are enabled; otherwise, false.</returns>
        [DataMember]
        public bool? IsEnabledForCharts
        {
            get
            {
                return this._isEnabledForCharts;
            }
            internal set
            {
                this._isEnabledForCharts = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;internal</returns>
        [DataMember]
        public bool? IsEnabledForTrace
        {
            get
            {
                return this._isEnabledForTrace;
            }
            internal set
            {
                this._isEnabledForTrace = value;
            }
        }

        /// <summary>Gets or sets whether the entity is will be shown in Advanced Find.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity is will be shown in Advanced Find.; otherwise, false.</returns>
        [DataMember]
        public bool? IsValidForAdvancedFind
        {
            get
            {
                return this._isValidForAdvancedFind;
            }
            internal set
            {
                this._isValidForAdvancedFind = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether pn_Mobile_Express_long users can see data for this entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether pn_Mobile_Express_long users can see data for this entity.</returns>
        [DataMember]
        public BooleanManagedProperty IsVisibleInMobile
        {
            get
            {
                return this._isVisibleInMobile;
            }
            set
            {
                this._isVisibleInMobile = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether pn_moca_full users can see data for this entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether pn_moca_full users can see data for this entity.</returns>
        [DataMember]
        public BooleanManagedProperty IsVisibleInMobileClient
        {
            get
            {
                return this._isVisibleInMobileClient;
            }
            set
            {
                this._isVisibleInMobileClient = value;
            }
        }

        /// <summary>Gets or sets the property that determines whether pn_moca_full users can update data for this entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see>The property that determines whether pn_moca_full users can update data for this entity.</returns>
        [DataMember]
        public BooleanManagedProperty IsReadOnlyInMobileClient
        {
            get
            {
                return this._isReadOnlyInMobileClient;
            }
            set
            {
                this._isReadOnlyInMobileClient = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;internal</returns>
        [DataMember]
        public bool? IsReadingPaneEnabled
        {
            get
            {
                return this._isReadingPaneEnabled;
            }
            set
            {
                this._isReadingPaneEnabled = value;
            }
        }

        /// <summary>Gets or sets the value indicating if the entity is enabled for quick create forms.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity is enabled for quick create forms ; otherwise, false.</returns>
        [DataMember]
        public bool? IsQuickCreateEnabled
        {
            get
            {
                return this._isQuickCreateEnabled;
            }
            set
            {
                this._isQuickCreateEnabled = value;
            }
        }

        /// <summary>Gets or sets the logical name for the entity.</summary>
        /// <returns>Type: Returns_String
        /// The logical name for the entity.</returns>
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

        /// <summary>Gets the array of many-to-many relationships for the entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.ManyToManyRelationshipMetadata"></see>[]the array of many-to-many relationships for the entity.</returns>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        [DataMember]
        public ManyToManyRelationshipMetadata[] ManyToManyRelationships
        {
            get
            {
                return this._manyToManyRelationships;
            }
            internal set
            {
                this._manyToManyRelationships = value;
            }
        }

        /// <summary>Gets the array of many-to-one relationships for the entity.</summary>
        /// <returns>Returns <see cref="T:Microsoft.Xrm.Sdk.Metadata.OneToManyRelationshipMetadata"></see>[].</returns>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        [DataMember]
        public OneToManyRelationshipMetadata[] ManyToOneRelationships
        {
            get
            {
                return this._manyToOneRelationships;
            }
            internal set
            {
                this._manyToOneRelationships = value;
            }
        }

        /// <summary>Gets the array of one-to-many relationships for the entity.</summary>
        /// <returns>Type :<see cref="T:Microsoft.Xrm.Sdk.Metadata.OneToManyRelationshipMetadata"></see>[]The array of one-to-many relationships for the entity.</returns>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        [DataMember]
        public OneToManyRelationshipMetadata[] OneToManyRelationships
        {
            get
            {
                return this._oneToManyRelationships;
            }
            internal set
            {
                this._oneToManyRelationships = value;
            }
        }

        /// <summary>Gets the entity type code.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The entity type code.</returns>
        [DataMember]
        public int? ObjectTypeCode
        {
            get
            {
                return this._objectTypeCode;
            }
            internal set
            {
                this._objectTypeCode = value;
            }
        }

        /// <summary>Gets or sets the ownership type for the entity.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.OwnershipTypes"></see>&gt;
        /// The ownership type for the entity..</returns>
        [DataMember]
        public OwnershipTypes? OwnershipType
        {
            get
            {
                return this._ownershipType;
            }
            set
            {
                this._ownershipType = value;
            }
        }

        /// <summary>Gets the name of the primary attribute for an entity.</summary>
        /// <returns>Type: Returns_String
        /// The name of the primary attribute for an entity..</returns>
        [DataMember]
        public string PrimaryNameAttribute
        {
            get
            {
                return this._primaryNameAttribute;
            }
            internal set
            {
                this._primaryNameAttribute = value;
            }
        }

        /// <summary>Gets the name of the primary image attribute for an entity.</summary>
        /// <returns>Type: Returns_String
        /// The name of the primary image attribute for an entity.</returns>
        [DataMember(Order = 60)]
        public string PrimaryImageAttribute
        {
            get
            {
                return this._primaryImageAttribute;
            }
            internal set
            {
                this._primaryImageAttribute = value;
            }
        }

        /// <summary>Gets the name of the attribute that is the primary id for the entity.</summary>
        /// <returns>Type: Returns_String
        /// The name of the attribute that is the primary id for the entity.</returns>
        [DataMember]
        public string PrimaryIdAttribute
        {
            get
            {
                return this._primaryIdAttribute;
            }
            internal set
            {
                this._primaryIdAttribute = value;
            }
        }

        /// <summary>Gets the privilege metadata for the entity.</summary>
        /// <returns>Returns <see cref="T:Microsoft.Xrm.Sdk.Metadata.SecurityPrivilegeMetadata"></see>[]The privilege metadata for the entity..</returns>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        [DataMember]
        public SecurityPrivilegeMetadata[] Privileges
        {
            get
            {
                return this._privileges;
            }
            internal set
            {
                this._privileges = value;
            }
        }

        /// <summary>Gets the name of the entity that is recurring.</summary>
        /// <returns>Type: Returns_String
        /// The name of the entity that is recurring.</returns>
        [DataMember]
        public string RecurrenceBaseEntityLogicalName
        {
            get
            {
                return this._recurrenceBaseEntityLogicalName;
            }
            internal set
            {
                this._recurrenceBaseEntityLogicalName = value;
            }
        }

        /// <summary>Gets the name of the report view for the entity.</summary>
        /// <returns>Type: Returns_String
        /// The name of the report view for the entity..</returns>
        [DataMember]
        public string ReportViewName
        {
            get
            {
                return this._reportViewName;
            }
            internal set
            {
                this._reportViewName = value;
            }
        }

        /// <summary>Gets or sets the schema name for the entity.</summary>
        /// <returns>Type: Returns_String
        /// The schema name for the entity.</returns>
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

        /// <summary>Gets whether the entity supports setting custom state transitions.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity supports custom status transitions.; otherwise, false.</returns>
        [DataMember]
        public bool? IsStateModelAware
        {
            get
            {
                return this._isStateModelAware;
            }
            internal set
            {
                this._isStateModelAware = value;
            }
        }

        /// <summary>Gets whether the entity will enforce custom state transitions.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity supports custom status transitions.; otherwise, false.</returns>
        [DataMember]
        public bool? EnforceStateTransitions
        {
            get
            {
                return this._enforceStateTransitions;
            }
            internal set
            {
                this._enforceStateTransitions = value;
            }
        }

        internal int? WorkflowSupport
        {
            get
            {
                return this._workflowSupport;
            }
            set
            {
                this._workflowSupport = value;
            }
        }

        internal string PhysicalName
        {
            get
            {
                return this._physicalName;
            }
            set
            {
                this._physicalName = value;
            }
        }
    }
}
