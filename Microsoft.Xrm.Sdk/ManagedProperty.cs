
using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Represents a strongly typed managed property.</summary>
    [DataContract(Name = "ManagedProperty{0}", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [KnownType(typeof(BooleanManagedProperty))]
    [KnownType(typeof(AttributeRequiredLevel))]
    public abstract class ManagedProperty<T> : IExtensibleDataObject
    {
        private T _value;
        private bool _canBeChanged;
        private string _logicalName;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.ManagedProperty`1"></see> class</summary>
        protected ManagedProperty()
          : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.ManagedProperty`1"></see> class</summary>
        /// <param name="managedPropertyLogicalName">Type: Returns_String. The logical name for the managed property.</param>
        protected ManagedProperty(string managedPropertyLogicalName)
        {
            this._logicalName = managedPropertyLogicalName;
            this._canBeChanged = true;
        }

        /// <summary>Gets or sets the value of the managed property.</summary>
        /// <returns>Type: Returns_String
        /// The value of the managed property.</returns>
        [DataMember]
        public T Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        /// <summary>Gets or sets whether the managed property value can be changed.</summary>
        /// <returns>Type: Returns_Booleantrue if the managed property value can be changed; otherwise, false.</returns>
        [DataMember]
        public bool CanBeChanged
        {
            get
            {
                return this._canBeChanged;
            }
            set
            {
                this._canBeChanged = value;
            }
        }

        /// <summary>Gets the logical name for the managed property.</summary>
        /// <returns>Type: Returns_String
        /// The logical name for the managed property.</returns>
        [DataMember]
        public string ManagedPropertyLogicalName
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
