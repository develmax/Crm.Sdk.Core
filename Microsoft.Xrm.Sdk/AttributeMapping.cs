using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    [DataContract(Name = "AttributeMapping", Namespace = "http://schemas.microsoft.com/xrm/2014/Contracts")]
    [Serializable]
    public sealed class AttributeMapping : IExtensibleDataObject
    {
        private Guid _attributeMappingId;
        private string _mappingName;
        private string _attributeCrmName;
        private string _attributeExchangeName;
        private int _entityTypeCode;
        private int _syncDirection;
        private int _defaultSyncDirection;
        private int _allowedSyncDirection;
        private bool _isComputed;
        private Collection<string> _computedProperties;
        private string _attributeCrmDisplayName;
        private string _attributeExchangeDisplayName;
        [NonSerialized]
        private ExtensionDataObject _extensionDataObject;

        public AttributeMapping()
        {
        }

        public AttributeMapping(
          Guid attributeMappingId,
          string mappingName,
          string attributeCrmName,
          string attributeExchangeName,
          int entityTypeCode,
          int syncDirection,
          int defaultSyncDirection,
          int allowedSyncDirection,
          bool isComputed,
          Collection<string> computedProperties,
          string attributeCrmDisplayName,
          string attributeExchangeDisplayName)
        {
            this._attributeMappingId = attributeMappingId;
            this._mappingName = mappingName;
            this._attributeCrmName = attributeCrmName;
            this._attributeExchangeName = attributeExchangeName;
            this._entityTypeCode = entityTypeCode;
            this._syncDirection = syncDirection;
            this._defaultSyncDirection = defaultSyncDirection;
            this._allowedSyncDirection = allowedSyncDirection;
            this._isComputed = isComputed;
            this._computedProperties = computedProperties;
            this._attributeCrmDisplayName = attributeCrmDisplayName;
            this._attributeExchangeDisplayName = attributeExchangeDisplayName;
        }

        [DataMember]
        public Guid AttributeMappingId
        {
            get
            {
                return this._attributeMappingId;
            }
            internal set
            {
                this._attributeMappingId = value;
            }
        }

        [DataMember]
        public string MappingName
        {
            get
            {
                return this._mappingName;
            }
            internal set
            {
                this._mappingName = value;
            }
        }

        [DataMember]
        public string AttributeCrmName
        {
            get
            {
                return this._attributeCrmName;
            }
            internal set
            {
                this._attributeCrmName = value;
            }
        }

        [DataMember]
        public string AttributeExchangeName
        {
            get
            {
                return this._attributeExchangeName;
            }
            internal set
            {
                this._attributeExchangeName = value;
            }
        }

        [DataMember]
        public int SyncDirection
        {
            get
            {
                return this._syncDirection;
            }
            internal set
            {
                this._syncDirection = value;
            }
        }

        [DataMember]
        public int DefaultSyncDirection
        {
            get
            {
                return this._defaultSyncDirection;
            }
            internal set
            {
                this._defaultSyncDirection = value;
            }
        }

        [DataMember]
        public int AllowedSyncDirection
        {
            get
            {
                return this._allowedSyncDirection;
            }
            internal set
            {
                this._allowedSyncDirection = value;
            }
        }

        [DataMember]
        public bool IsComputed
        {
            get
            {
                return this._isComputed;
            }
            internal set
            {
                this._isComputed = value;
            }
        }

        [DataMember]
        public int EntityTypeCode
        {
            get
            {
                return this._entityTypeCode;
            }
            internal set
            {
                this._entityTypeCode = value;
            }
        }

        [DataMember]
        public Collection<string> ComputedProperties
        {
            get
            {
                return this._computedProperties;
            }
            internal set
            {
                this._computedProperties = value;
            }
        }

        [DataMember]
        public string AttributeCrmDisplayName
        {
            get
            {
                return this._attributeCrmDisplayName;
            }
            internal set
            {
                this._attributeCrmDisplayName = value;
            }
        }

        [DataMember]
        public string AttributeExchangeDisplayName
        {
            get
            {
                return this._attributeExchangeDisplayName;
            }
            internal set
            {
                this._attributeExchangeDisplayName = value;
            }
        }

        ExtensionDataObject IExtensibleDataObject.ExtensionData
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
