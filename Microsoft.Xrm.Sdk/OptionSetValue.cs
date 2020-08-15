using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Represents a value for an attribute that has an option set.</summary>
    [DataContract(Name = "OptionSetValue", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class OptionSetValue : IExtensibleDataObject
    {
        private int _value;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see> class</summary>
        public OptionSetValue()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see> class</summary>
        /// <param name="value">Type: Returns_Int32. The option set value. </param>
        public OptionSetValue(int value)
        {
            this._value = value;
        }

        /// <summary>Gets or sets the current value.</summary>
        /// <returns>Type: Returns_Int32
        /// The current value.</returns>
        [DataMember]
        public int Value
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

        /// <summary>Returns true if the specified OptionSetValue is equal to this OptionSetValue value, otherwise returns false.</summary>
        /// <returns>Type: Returns_Booleantrue if the specified <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see> is equal to this <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see> value; otherwise, false.</returns>
        /// <param name="obj">Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>, The <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see> to compare.</param>
        public override bool Equals(object obj)
        {
            if (!(obj is OptionSetValue optionSetValue))
                return false;
            return this == optionSetValue || this._value.Equals(optionSetValue._value);
        }

        /// <summary>Gets a hash code for the value.</summary>
        /// <returns>Type: Returns_Int32
        /// The hash code for the value.</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
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
