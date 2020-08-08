using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Identifies a record.</summary>
    [DataContract(Name = "EntityReference", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [Serializable]
    public sealed class EntityReference : IExtensibleDataObject
    {
        private string _logicalName;
        private string _name;
        private Guid _id;
        [NonSerialized]
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see> class.</summary>
        public EntityReference()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see> class setting the logical name and entity ID.</summary>
        /// <param name="logicalName">Type: Returns_String. The logical name of the entity.</param>
        /// <param name="id">Type: Returns_Guid. The ID of the record.</param>
        public EntityReference(string logicalName, Guid id)
        {
            this._logicalName = logicalName;
            this._id = id;
        }

        /// <summary>Gets or sets the ID of the record.</summary>
        /// <returns>Type: Returns_Guid
        /// The ID of the record. </returns>
        [DataMember]
        public Guid Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        /// <summary>Gets or sets the logical name of the entity.</summary>
        /// <returns>Type: Returns_StringThe logical name of the entity.</returns>
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

        /// <summary>Gets or sets the value of the primary attribute of the entity.</summary>
        /// <returns>Type: Returns_StringThe value of the primary attribute of the entity.</returns>
        [DataMember]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        /// <summary>Determines whether two instances are equal.</summary>
        /// <returns>Type: Returns_Booleantrue if the specified <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see> is equal to the <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see> object; otherwise, false.</returns>
        /// <param name="obj">Type: Returns_Object. The <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see> to compare with the current <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>.</param>
        public override bool Equals(object obj)
        {
            if (!(obj is EntityReference entityReference))
                return false;
            if (this == entityReference)
                return true;
            return this._id.Equals(entityReference._id) && string.Compare(this._logicalName, entityReference._logicalName, StringComparison.Ordinal) == 0;
        }

        /// <summary>Serves as a hash function for this type.</summary>
        /// <returns>Type: Returns_Int32
        /// The hash code for the current <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>.</returns>
        public override int GetHashCode()
        {
            return !string.IsNullOrEmpty(this._logicalName) ? this._logicalName.GetHashCode() ^ this._id.GetHashCode() : 0;
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