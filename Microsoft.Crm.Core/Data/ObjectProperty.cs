
using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Crm.Data
{
    public class ObjectProperty : PropertyBase, IProperty
    {
        private object _value;

        public static ObjectProperty RegisterUninitialized(
          PropertyBag bag,
          string propertyName)
        {
            return ObjectProperty.Register(bag, propertyName, (object)null, PropertyState.Uninitialized);
        }

        public static ObjectProperty RegisterUnchanged(
          PropertyBag bag,
          string propertyName,
          object initialValue)
        {
            return ObjectProperty.Register(bag, propertyName, initialValue, PropertyState.Unchanged);
        }

        public static ObjectProperty Register(
          PropertyBag bag,
          string propertyName,
          object initialValue,
          PropertyState state)
        {
            return ObjectProperty.Register(bag, propertyName, initialValue, state, PropertyFlags.Static);
        }

        public static ObjectProperty Register(
          PropertyBag bag,
          string propertyName,
          object initialValue,
          PropertyState state,
          PropertyFlags flags)
        {
            ObjectProperty objectProperty = new ObjectProperty(state, flags, initialValue);
            bag.Add(propertyName, (IProperty)objectProperty);
            return objectProperty;
        }

        public ObjectProperty(PropertyState state, PropertyFlags flags, object initialValue)
          : base(state, flags)
        {
            this._value = initialValue;
        }

        public object Value
        {
            get
            {
                if (!this.HasValue)
                    //throw new CrmInvalidOperationException("Cannot retrieve value of " + this.State.ToString() + " property.");
                    throw new InvalidOperationException("Cannot retrieve value of " + this.State.ToString() + " property.");
                return this._value;
            }
            set
            {
                this.SetState(PropertyBag.PrepareForUpdate(this.State, this.Flags));
                this._value = value;
            }
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "BASELINE: BackLog", MessageId = "System.String.Format(System.String,System.Object,System.Object,System.Object)")]
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "BASELINE: BackLog", MessageId = "System.String.Format(System.String,System.Object,System.Object)")]
        public override string ToString()
        {
            return this.HasValue ? string.Format("ObjectProperty(value={0}, state={1}, flags={2})", this.Value, (object)this.State, (object)this.Flags) : string.Format("ObjectProperty(state={0}, flags={1})", (object)this.State, (object)this.Flags);
        }
    }
}
