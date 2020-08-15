using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata that describes a security privilege for access to an entity.</summary>
    [DataContract(Name = "SecurityPrivilegeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class SecurityPrivilegeMetadata : IExtensibleDataObject
    {
        private string _name;
        private Guid _privilegeId;
        private PrivilegeType _privilegeType;
        private bool _canBeBasic;
        private bool _canBeLocal;
        private bool _canBeDeep;
        private bool _canBeGlobal;
        private ExtensionDataObject _extensionDataObject;

        internal SecurityPrivilegeMetadata()
        {
        }

        /// <summary>Gets whether the privilege can be basic access level.</summary>
        /// <returns>Type: Returns_Booleantrue if the privilege can be basic access level.; otherwise, false.</returns>
        [DataMember]
        public bool CanBeBasic
        {
            get
            {
                return this._canBeBasic;
            }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set
            {
                this._canBeBasic = value;
            }
        }

        /// <summary>Gets whether the privilege can be deep access level.</summary>
        /// <returns>Type: Returns_Booleantrue if the privilege can be deep access level; otherwise, false.</returns>
        [DataMember]
        public bool CanBeDeep
        {
            get
            {
                return this._canBeDeep;
            }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set
            {
                this._canBeDeep = value;
            }
        }

        /// <summary>Gets whether the privilege can be global access level.</summary>
        /// <returns>Type: Returns_Booleantrue if the privilege can be global access level; otherwise, false.</returns>
        [DataMember]
        public bool CanBeGlobal
        {
            get
            {
                return this._canBeGlobal;
            }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set
            {
                this._canBeGlobal = value;
            }
        }

        /// <summary>Gets whether the privilege can be local access level.</summary>
        /// <returns>Type: Returns_Booleantrue if the privilege can be local access level; otherwise, false.</returns>
        [DataMember]
        public bool CanBeLocal
        {
            get
            {
                return this._canBeLocal;
            }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set
            {
                this._canBeLocal = value;
            }
        }

        /// <summary>Gets the name of the privilege.</summary>
        /// <returns>Type: Returns_String
        /// The name of the privilege.</returns>
        [DataMember]
        public string Name
        {
            get
            {
                return this._name;
            }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set
            {
                this._name = value;
            }
        }

        /// <summary>Gets the ID of the privilege.</summary>
        /// <returns>Type: Returns_Guid The ID of the privilege.</returns>
        [DataMember]
        public Guid PrivilegeId
        {
            get
            {
                return this._privilegeId;
            }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set
            {
                this._privilegeId = value;
            }
        }

        /// <summary>Gets the type of the privilege.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.PrivilegeType"></see>The type of the privilege.</returns>
        [DataMember]
        public PrivilegeType PrivilegeType
        {
            get
            {
                return this._privilegeType;
            }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] internal set
            {
                this._privilegeType = value;
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
