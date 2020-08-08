
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace Microsoft.Crm.Data
{
    public class PropertyBag : IPropertyBag
    {
        private IDictionary _properties;

        public PropertyBag()
          : this(true)
        {
        }

        public PropertyBag(bool caseInsensitive)
        {
            this._properties = (IDictionary)new HybridDictionary(caseInsensitive);
        }

        public PropertyBag(int initialCapacity, bool caseInsensitive)
        {
            this._properties = (IDictionary)new HybridDictionary(initialCapacity, caseInsensitive);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("PropertyBag Contents -> ");
            foreach (PropertyEntry propertyEntry in this.PropertyEntries)
            {
                stringBuilder.Append("  " + propertyEntry.Name + " : ");
                if (propertyEntry.Value != null)
                    stringBuilder.Append(propertyEntry.Value.ToString());
                stringBuilder.Append(Environment.NewLine);
            }
            return stringBuilder.ToString();
        }

        public object this[string propertyName]
        {
            get
            {
                return this.Get(propertyName)?.Value;
            }
            set
            {
                this.SetValue(propertyName, value);
            }
        }

        public virtual void SetValue(string propertyName, object newValue)
        {
            //Exceptions.ThrowIfNull((object)propertyName, nameof(propertyName));
            IProperty property1 = (IProperty)this._properties[(object)propertyName];
            if (property1 == null)
            {
                IProperty property2 = (IProperty)new ObjectProperty(PropertyState.New, PropertyFlags.All, newValue);
                this._properties[(object)propertyName] = (object)property2;
            }
            else
                property1.Value = newValue;
        }

        public void InitializeValueAndState(
          string propertyName,
          object propertyValue,
          PropertyState overrideState)
        {
            //Exceptions.ThrowIfNull((object)propertyName, nameof(propertyName));
            IProperty property1 = (IProperty)this._properties[(object)propertyName];
            if (property1 == null)
            {
                IProperty property2 = (IProperty)new ObjectProperty(overrideState, PropertyFlags.All, propertyValue);
                this._properties[(object)propertyName] = (object)property2;
            }
            else
            {
                if (property1.State != PropertyState.Uninitialized)
                    //throw new CrmArgumentException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "InitializeValueAndState: method can only be applied to Uninitialized properties. PropertyName: {0}, PropertyValue: {1}, OverrideState: {2}", (object)propertyName, (object)propertyValue.ToString(), (object)overrideState.ToString()), nameof(propertyName));
                    throw new ArgumentException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "InitializeValueAndState: method can only be applied to Uninitialized properties. PropertyName: {0}, PropertyValue: {1}, OverrideState: {2}", (object)propertyName, (object)propertyValue.ToString(), (object)overrideState.ToString()), nameof(propertyName));
                property1.Value = propertyValue;
                ((IPropertyManagement)property1).SetState(overrideState);
            }
        }

        public void Add(string propertyName, IProperty newProperty)
        {
            //Exceptions.ThrowIfNull((object)propertyName, nameof(propertyName));
            //Exceptions.ThrowIfNull((object)newProperty, nameof(newProperty));
            if (this._properties.Contains((object)propertyName))
                //throw new CrmArgumentException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Property bag already contains property with a given name. PropertyName: {0}", (object)propertyName), nameof(propertyName));
                throw new ArgumentException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Property bag already contains property with a given name. PropertyName: {0}", (object)propertyName), nameof(propertyName));
            if (!(newProperty is IPropertyManagement))
                //throw new CrmArgumentException("Property must implement IPropertyManagement interface.", nameof(newProperty));
                throw new ArgumentException("Property must implement IPropertyManagement interface.", nameof(newProperty));
            this._properties.Add((object)propertyName, (object)newProperty);
        }

        public virtual bool Contains(string propertyName)
        {
            //Exceptions.ThrowIfNull((object)propertyName, nameof(propertyName));
            IProperty property = (IProperty)this._properties[(object)propertyName];
            return property != null && property.HasValue;
        }

        public virtual IProperty Get(string propertyName)
        {
            //Exceptions.ThrowIfNull((object)propertyName, nameof(propertyName));
            IProperty property = (IProperty)this._properties[(object)propertyName];
            if (property == null)
                return (IProperty)null;
            return !property.HasValue ? (IProperty)null : property;
        }

        public void Remove(string propertyName)
        {
            //Exceptions.ThrowIfNull((object)propertyName, nameof(propertyName));
            IProperty property = (IProperty)this._properties[(object)propertyName];
            if (property == null)
                return;
            if ((property.Flags & PropertyFlags.CanBeRemoved) == PropertyFlags.Ignore)
                //throw new CrmInvalidOperationException("Property flags indicate that property cannot be removed.");
                throw new InvalidOperationException("Property flags indicate that property cannot be removed.");
            switch (property.State)
            {
                case PropertyState.Uninitialized:
                case PropertyState.Unchanged:
                case PropertyState.Modified:
                    ((IPropertyManagement)property).SetState(PropertyState.Deleted);
                    break;
                case PropertyState.New:
                    this._properties.Remove((object)propertyName);
                    break;
                case PropertyState.Deleted:
                    break;
                default:
                    //throw new CrmInvalidOperationException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Unknown property state: {0}", (object)property.State.ToString()));
                    throw new InvalidOperationException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Unknown property state: {0}", (object)property.State.ToString()));
            }
        }

        public bool IsModified
        {
            get
            {
                IEnumerator enumerator = this.SelectPropertyEntries(PropertyState.New | PropertyState.Modified | PropertyState.Deleted, PropertyFlags.Ignore, PropertyFlags.Ignore).GetEnumerator();
                try
                {
                    if (enumerator.MoveNext())
                    {
                        Trace.Assert((((PropertyEntry)enumerator.Current).State & (PropertyState.New | PropertyState.Modified | PropertyState.Deleted)) != (PropertyState)0, "Property state must be one of: New, Modified, Deleted.");
                        return true;
                    }
                }
                finally
                {
                    if (enumerator is IDisposable disposable)
                        disposable.Dispose();
                }
                return false;
            }
        }

        public int Count
        {
            get
            {
                return this._properties.Values.Count;
            }
        }

        [XmlIgnore]
        public IEnumerable PropertyEntries
        {
            get
            {
                return this.SelectPropertyEntries(PropertyState.Unchanged | PropertyState.New | PropertyState.Modified, PropertyFlags.Browsable, PropertyFlags.Ignore);
            }
        }

        [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "False alarm on local$0")]
        public IEnumerable<PropertyEntry> RetrievePropertyEntries()
        {
            foreach (object selectPropertyEntry in this.SelectPropertyEntries(PropertyState.Unchanged | PropertyState.New | PropertyState.Modified, PropertyFlags.Browsable, PropertyFlags.Ignore))
                yield return (PropertyEntry)selectPropertyEntry;
        }

        public IEnumerable SelectPropertyEntries(
          PropertyState stateMask,
          PropertyFlags includeFlags,
          PropertyFlags excludeFlags)
        {
            return (IEnumerable)new PropertyBag.EnumeratorHolder((IPropertyBagEnumerator)new PropertyBag.PropertyBagEnumerator(stateMask, includeFlags, excludeFlags, this._properties.GetEnumerator()));
        }

        public void ResetStates()
        {
            ArrayList arrayList = new ArrayList();
            foreach (PropertyEntry selectPropertyEntry in this.SelectPropertyEntries(PropertyState.New | PropertyState.Modified | PropertyState.Deleted, PropertyFlags.Ignore, PropertyFlags.Ignore))
            {
                switch (selectPropertyEntry.State)
                {
                    case PropertyState.New:
                    case PropertyState.Modified:
                        ((IPropertyManagement)selectPropertyEntry.Property).SetState(PropertyState.Unchanged);
                        continue;
                    case PropertyState.Deleted:
                        arrayList.Add((object)selectPropertyEntry.Name);
                        return;
                    default:
                        //throw new CrmInvalidOperationException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Unknown property state: {0}", (object)selectPropertyEntry.State.ToString()));
                        throw new InvalidOperationException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Unknown property state: {0}", (object)selectPropertyEntry.State.ToString()));
                }
            }
            foreach (string str in arrayList)
                this._properties.Remove((object)str);
        }

        public static PropertyState PrepareForUpdate(
          PropertyState state,
          PropertyFlags flags)
        {
            if ((flags & PropertyFlags.CanBeModified) == PropertyFlags.Ignore && state != PropertyState.Uninitialized)
                //throw new CrmInvalidOperationException("Property flags indicate that property cannot be modified. Property can be modified if CanBeModified flag is set OR state is Uninitialized.");
                throw new InvalidOperationException("Property flags indicate that property cannot be modified. Property can be modified if CanBeModified flag is set OR state is Uninitialized.");
            switch (state)
            {
                case PropertyState.Uninitialized:
                    return PropertyState.New;
                case PropertyState.Unchanged:
                    return PropertyState.Modified;
                case PropertyState.New:
                case PropertyState.Modified:
                    return state;
                case PropertyState.Deleted:
                    return PropertyState.Modified;
                default:
                    //throw new CrmArgumentException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Unknown property state: {0}", (object)state), nameof(state));
                    throw new ArgumentException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Unknown property state: {0}", (object)state), nameof(state));
            }
        }

        [XmlArrayItem("Property")]
        [XmlArray("Properties")]
        public SerializationProperty[] SerializationProperties
        {
            get
            {
                SerializationProperty[] serializationPropertyArray = new SerializationProperty[this._properties.Count];
                int num = 0;
                foreach (PropertyEntry propertyEntry in this.PropertyEntries)
                    serializationPropertyArray[num++] = new SerializationProperty(propertyEntry.Name, propertyEntry.Value);
                return serializationPropertyArray;
            }
            set
            {
                foreach (SerializationProperty serializationProperty in value)
                    this.SetValue(serializationProperty.Name, serializationProperty.Value);
            }
        }

        private class EnumeratorHolder : IEnumerable
        {
            private IPropertyBagEnumerator _enumerator;

            public EnumeratorHolder(IPropertyBagEnumerator enumerator)
            {
                Trace.Assert(enumerator != null);
                this._enumerator = enumerator;
            }

            [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "BASELINE: BackLog", MessageId = "")]
            public IPropertyBagEnumerator GetEnumerator()
            {
                return this._enumerator;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)this._enumerator;
            }
        }

        private class PropertyBagEnumerator : IPropertyBagEnumerator, IEnumerator
        {
            private PropertyState _stateMask;
            private PropertyFlags _includeFlags;
            private PropertyFlags _excludeFlags;
            private IDictionaryEnumerator _baseEnumerator;

            public PropertyBagEnumerator(
              PropertyState stateMask,
              PropertyFlags includeFlags,
              PropertyFlags excludeFlags,
              IDictionaryEnumerator baseEnumerator)
            {
                this._stateMask = stateMask;
                this._includeFlags = includeFlags;
                this._excludeFlags = excludeFlags;
                this._baseEnumerator = baseEnumerator;
            }

            public PropertyEntry Entry
            {
                get
                {
                    return new PropertyEntry((string)this._baseEnumerator.Key, this.CurrentProperty);
                }
            }

            public string Name
            {
                get
                {
                    return (string)this._baseEnumerator.Key;
                }
            }

            public IProperty Property
            {
                get
                {
                    return this.CurrentProperty;
                }
            }

            public object Value
            {
                get
                {
                    return this.CurrentProperty.Value;
                }
            }

            public PropertyState State
            {
                get
                {
                    return this.CurrentProperty.State;
                }
            }

            public PropertyFlags Flags
            {
                get
                {
                    return this.CurrentProperty.Flags;
                }
            }

            public void Reset()
            {
                this._baseEnumerator.Reset();
            }

            public PropertyEntry Current
            {
                get
                {
                    return this.Entry;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return (object)this.Current;
                }
            }

            public bool MoveNext()
            {
                while (this._baseEnumerator.MoveNext())
                {
                    IProperty property = (IProperty)this._baseEnumerator.Value;
                    if ((property.State & this._stateMask) != (PropertyState)0 && (this._includeFlags == PropertyFlags.Ignore || (property.Flags & this._includeFlags) == this._includeFlags) && (this._excludeFlags == PropertyFlags.Ignore || (property.Flags & this._excludeFlags) == PropertyFlags.Ignore))
                        return true;
                }
                return false;
            }

            private IProperty CurrentProperty
            {
                get
                {
                    IProperty property = (IProperty)this._baseEnumerator.Value;
                    Trace.Assert(property != null);
                    Trace.Assert((property.State & this._stateMask) != (PropertyState)0);
                    Trace.Assert(this._includeFlags == PropertyFlags.Ignore || (property.Flags & this._includeFlags) == this._includeFlags);
                    Trace.Assert(this._excludeFlags == PropertyFlags.Ignore || (property.Flags & this._excludeFlags) == PropertyFlags.Ignore);
                    return property;
                }
            }
        }
    }
}
