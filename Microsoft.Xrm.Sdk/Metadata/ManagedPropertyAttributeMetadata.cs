using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>internal</summary>
    [DataContract(Name = "ManagedPropertyAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class ManagedPropertyAttributeMetadata : AttributeMetadata
    {
        /// <summary>internal</summary>
        public const int EmptyParentComponentType = 0;
        private string _managedPropertyLogicalName;
        private int? _parentComponentType;
        private string _parentAttributeName;
        private AttributeTypeCode _typeCode;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.ManagedPropertyAttributeMetadata"></see> class</summary>
        public ManagedPropertyAttributeMetadata()
          : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.ManagedPropertyAttributeMetadata"></see> class</summary>
        /// <param name="schemaName">internal</param>
        public ManagedPropertyAttributeMetadata(string schemaName)
          : base(AttributeTypeCode.ManagedProperty, schemaName)
        {
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Stringinternal</returns>
        [DataMember]
        public string ManagedPropertyLogicalName
        {
            get
            {
                return this._managedPropertyLogicalName;
            }
            internal set
            {
                this._managedPropertyLogicalName = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;internal</returns>
        [DataMember]
        public int? ParentComponentType
        {
            get
            {
                return this._parentComponentType;
            }
            internal set
            {
                this._parentComponentType = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Stringinternal</returns>
        [DataMember]
        public string ParentAttributeName
        {
            get
            {
                return this._parentAttributeName;
            }
            internal set
            {
                this._parentAttributeName = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode"></see>internal</returns>
        [DataMember]
        public AttributeTypeCode ValueAttributeTypeCode
        {
            get
            {
                return this._typeCode;
            }
            internal set
            {
                this._typeCode = value;
            }
        }
    }
}
