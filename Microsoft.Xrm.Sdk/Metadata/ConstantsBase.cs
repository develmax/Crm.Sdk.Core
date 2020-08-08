
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    [KnownType(typeof(StringFormatName))]
    [KnownType(typeof(AttributeTypeDisplayName))]
    [DataContract(Name = "ConstantsBase", Namespace = "http://schemas.microsoft.com/xrm/2013/Metadata")]
    public abstract class ConstantsBase<T> : IExtensibleDataObject
    {
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "The underlying value of the reference type is string which is immutable")]
        protected static readonly IList<T> ValidValues = (IList<T>)new List<T>();
        private T _value;
        private ExtensionDataObject _extensionDataObject;

        /// <returns>Returns <see cref="T:System.Runtime.Serialization.ExtensionDataObject"></see>.</returns>
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

        /// <returns>Returns <see cref="T:System.Boolean"></see>.</returns>
        protected abstract bool ValueExistsInList(T value);

        /// <returns>Returns <see cref="T:System.Collections.Generic.IList`1"></see>.</returns>
        protected static T2 Create<T2>(T value) where T2 : ConstantsBase<T>, new()
        {
            T2 obj = new T2();
            obj._value = value;
            return obj;
        }

        /// <returns>Returns <see cref="T:System.Collections.Generic.IList`1"></see>.</returns>
        protected static T2 Add<T2>(T value) where T2 : ConstantsBase<T>, new()
        {
            ConstantsBase<T>.ValidValues.Add(value);
            return ConstantsBase<T>.Create<T2>(value);
        }

        /// <returns>Returns <see cref="T:System.Runtime.Serialization.ExtensionDataObject"></see>.</returns>
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