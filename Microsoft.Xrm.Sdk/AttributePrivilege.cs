using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Specifies the field level security privileges allowed for an attribute.</summary>
    [DataContract(Name = "AttributePrivilege", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [Serializable]
    public sealed class AttributePrivilege : IExtensibleDataObject
    {
        private Guid _attributeId;
        private int _canCreate;
        private int _canRead;
        private int _canUpdate;
        [NonSerialized]
        private ExtensionDataObject _extensionDataObject;

        /// <summary>constructor_initializes<see cref="T:Microsoft.Xrm.Sdk.AttributePrivilege"></see> class.</summary>
        public AttributePrivilege()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.AttributePrivilege"></see> class setting the attribute Id, and whether it is valid to create, read and update the attribute value.</summary>
        /// <param name="canRead">Type: Returns_Int32. Whether the attribute value can be read.</param>
        /// <param name="canCreate">Type: Returns_Int32. Whether the attribute value can be specified on create.</param>
        /// <param name="attributeId">Type: Returns_Guid. The attribute ID.</param>
        /// <param name="canUpdate">Type: Returns_Int32. Whether the attribute value can be updated.</param>
        public AttributePrivilege(Guid attributeId, int canCreate, int canRead, int canUpdate)
        {
            this._attributeId = attributeId;
            this._canCreate = canCreate;
            this._canRead = canRead;
            this._canUpdate = canUpdate;
        }

        /// <summary>Gets the ID of the attribute.</summary>
        /// <returns>Type: Returns_GuidThe ID of the attribute.</returns>
        [DataMember]
        public Guid AttributeId
        {
            get
            {
                return this._attributeId;
            }
            internal set
            {
                this._attributeId = value;
            }
        }

        /// <summary>Gets whether create of the attribute value is allowed.</summary>
        /// <returns>Type: Returns_Int32.</returns>
        [DataMember]
        public int CanCreate
        {
            get
            {
                return this._canCreate;
            }
            internal set
            {
                this._canCreate = value;
            }
        }

        /// <summary>Gets whether read of the attribute value is allowed.</summary>
        /// <returns>Type: Returns_Int32.</returns>
        [DataMember]
        public int CanRead
        {
            get
            {
                return this._canRead;
            }
            internal set
            {
                this._canRead = value;
            }
        }

        /// <summary>Gets whether update of the attribute value is allowed.</summary>
        /// <returns>Type: Returns_Int32.</returns>
        [DataMember]
        public int CanUpdate
        {
            get
            {
                return this._canUpdate;
            }
            internal set
            {
                this._canUpdate = value;
            }
        }

        /// <summary>ExtensionData</summary>
        /// <returns>Type: Returns_ExtensionDataObject
        /// The extension data.</returns>
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