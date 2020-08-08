using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Represents a relationship between two entities.</summary>
    [DataContract(Name = "Relationship", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class Relationship : IExtensibleDataObject
    {
        private EntityRole? _primaryEntityRole;
        private string _schemaName;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see> class.</summary>
        public Relationship()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see> class setting the schema name property.</summary>
        /// <param name="schemaName">Type: Returns_String. The name of the relationship.</param>
        public Relationship(string schemaName)
        {
            this._schemaName = schemaName;
        }

        /// <summary>Gets or sets the name of the relationship.</summary>
        /// <returns>Type: Returns_String
        /// The name of the relationship as defined defined in the <see cref="P:Microsoft.Xrm.Sdk.Relationship.SchemaName"></see> property.</returns>
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

        /// <summary>Gets or sets the entity role: referenced or referencing.</summary>
        /// <returns>Type: <see cref="T:System.Nullable`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.EntityRole"></see>&gt;
        /// The entity role.</returns>
        [DataMember]
        public EntityRole? PrimaryEntityRole
        {
            get
            {
                return this._primaryEntityRole;
            }
            set
            {
                this._primaryEntityRole = value;
            }
        }

        /// <summary>Determines whether two instances are equal.</summary>
        /// <returns>Type: Returns_Booleantrue if the specified Relationship is equal to the Relationship Object; otherwise, false.</returns>
        /// <param name="obj">Type: Returns_Object. The Relationship to compare with the current Relationship.</param>
        public override bool Equals(object obj)
        {
            if (!(obj is Relationship relationship) || !(this.SchemaName == relationship.SchemaName))
                return false;
            EntityRole? primaryEntityRole1 = this._primaryEntityRole;
            EntityRole? primaryEntityRole2 = relationship._primaryEntityRole;
            return primaryEntityRole1.GetValueOrDefault() == primaryEntityRole2.GetValueOrDefault() && primaryEntityRole1.HasValue == primaryEntityRole2.HasValue;
        }

        /// <summary>Serves as a hash function for this type.</summary>
        /// <returns>Type: Returns_Int32
        /// The hash code for the current Relationship.</returns>
        public override int GetHashCode()
        {
            int hashCode = (this._schemaName ?? string.Empty).GetHashCode();
            if (this._primaryEntityRole.HasValue)
                hashCode ^= this._primaryEntityRole.Value.GetHashCode();
            return hashCode;
        }

        /// <summary>Returns a String that represents the current Relationship.</summary>
        /// <returns>Type: Returns_String
        /// The name of the current Relationship.</returns>
        public override string ToString()
        {
            return string.Format((IFormatProvider)CultureInfo.InvariantCulture, "{0}.{1}", (object)(this._schemaName ?? string.Empty), this._primaryEntityRole.HasValue ? (object)this._primaryEntityRole.ToString() : (object)string.Empty);
        }

        /// <summary>ExtensionData</summary>
        /// <returns>Type: <see cref="T:System.Runtime.Serialization.ExtensionDataObject"></see>
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