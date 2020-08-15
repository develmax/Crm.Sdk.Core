using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>internal</summary>
    [DataContract(Name = "ManagedPropertyMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class ManagedPropertyMetadata : MetadataBase
    {
        private string _logicalName;
        private Label _displayName;
        private Label _description;
        private Microsoft.Xrm.Sdk.Metadata.ManagedPropertyType? _managedPropertyType;
        private ManagedPropertyOperation? _operation;
        private ManagedPropertyEvaluationPriority? _evaluationPriority;
        private string _enablesAttributeName;
        private string _enablesEntityName;
        private int? _errorCode;
        private bool? _isPrivate;
        private bool? _isGlobalForOperation;
        private string _introducedVersion;

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Stringinternal</returns>
        [DataMember]
        public string LogicalName
        {
            get
            {
                return this._logicalName;
            }
            internal set
            {
                this._logicalName = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>internal</returns>
        [DataMember]
        public Label DisplayName
        {
            get
            {
                return this._displayName;
            }
            internal set
            {
                this._displayName = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.ManagedPropertyType"></see>&gt;internal</returns>
        [DataMember]
        public Microsoft.Xrm.Sdk.Metadata.ManagedPropertyType? ManagedPropertyType
        {
            get
            {
                return this._managedPropertyType;
            }
            internal set
            {
                this._managedPropertyType = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.ManagedPropertyOperation"></see>&gt;internal</returns>
        [DataMember]
        public ManagedPropertyOperation? Operation
        {
            get
            {
                return this._operation;
            }
            internal set
            {
                this._operation = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;internal</returns>
        [DataMember]
        public bool? IsGlobalForOperation
        {
            get
            {
                return this._isGlobalForOperation;
            }
            internal set
            {
                this._isGlobalForOperation = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.ManagedPropertyEvaluationPriority"></see>&gt;internal</returns>
        [DataMember]
        public ManagedPropertyEvaluationPriority? EvaluationPriority
        {
            get
            {
                return this._evaluationPriority;
            }
            internal set
            {
                this._evaluationPriority = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;internal</returns>
        [DataMember]
        public bool? IsPrivate
        {
            get
            {
                return this._isPrivate;
            }
            internal set
            {
                this._isPrivate = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;internal</returns>
        [DataMember]
        public int? ErrorCode
        {
            get
            {
                return this._errorCode;
            }
            internal set
            {
                this._errorCode = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Stringinternal</returns>
        [DataMember]
        public string EnablesEntityName
        {
            get
            {
                return this._enablesEntityName;
            }
            internal set
            {
                this._enablesEntityName = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_Stringinternal</returns>
        [DataMember]
        public string EnablesAttributeName
        {
            get
            {
                return this._enablesAttributeName;
            }
            internal set
            {
                this._enablesAttributeName = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>internal</returns>
        [DataMember]
        public Label Description
        {
            get
            {
                return this._description;
            }
            internal set
            {
                this._description = value;
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
