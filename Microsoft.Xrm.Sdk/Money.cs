using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains the value for a money attribute.</summary>
    [DataContract(Name = "Money", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class Money : IExtensibleDataObject
    {
        private Decimal _value;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Money"></see> class.</summary>
        public Money()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Money"></see> class setting the value.</summary>
        /// <param name="value">Type: Returns_Decimal. The value of the attribute.</param>
        public Money(Decimal value)
        {
            this._value = value;
        }

        /// <summary>Gets or sets the value of the attribute.</summary>
        /// <returns>Type: Returns_DecimalThe value of the attribute.</returns>
        [DataMember]
        public Decimal Value
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

        /// <summary>Determines whether two instances are equal.</summary>
        /// <returns>Type: Returns_Booleantrue if the specified <see cref="T:Microsoft.Xrm.Sdk.Money"></see> is equal to the <see cref="T:Microsoft.Xrm.Sdk.Money"></see> object; otherwise, false.</returns>
        /// <param name="obj">Type: Returns_Object. The <see cref="T:Microsoft.Xrm.Sdk.Money"></see> to compare with the current <see cref="T:Microsoft.Xrm.Sdk.Money"></see>.</param>
        public override bool Equals(object obj)
        {
            if (!(obj is Money money))
                return false;
            return this == money || this._value.Equals(money._value);
        }

        /// <summary>Returns a hash code value for this type.</summary>
        /// <returns>Type: Returns_Int32
        /// The hash code for the current Money.</returns>
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
