using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists. Extends Returns_Collection.</summary>
    [Serializable]
    public class DataCollection<T> : Collection<T>
    {
        internal DataCollection()
        {
        }

        internal DataCollection(IList<T> list)
        {
            this.AddRange((IEnumerable<T>)list);
        }

        /// <summary>Adds the elements of the specified collection to the end of the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>.</summary>
        /// <param name="items">Type: Returns_Type[].
        /// The array whose elements should be added to the end of the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>. The array itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public void AddRange(params T[] items)
        {
            if (items == null)
                return;
            this.AddRange((IEnumerable<T>)items);
        }

        /// <summary>Adds the elements of the specified collection to the end of the DataCollection.</summary>
        /// <param name="items">Type: Returns_IEnumerable_Generic.
        /// The collection whose elements should be added to the end of the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public void AddRange(IEnumerable<T> items)
        {
            if (items == null)
                return;
            foreach (T obj in items)
                this.Add(obj);
        }

        /// <summary>Copies the elements of the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see> to a new array.</summary>
        /// <returns>Type: Returns_Type[]
        /// An array containing copies of the elements of the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>.</returns>
        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            this.CopyTo(array, 0);
            return array;
        }
    }

    /// <summary>Represents a collection of keys and values.</summary>
    [Serializable]
    public abstract class DataCollection<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
    {
        private IDictionary<TKey, TValue> _innerDictionary = (IDictionary<TKey, TValue>)new Dictionary<TKey, TValue>();
        private bool _isReadOnly;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see> class.</summary>
        protected internal DataCollection()
        {
        }

        /// <summary>Adds the specified key and value to the dictionary.</summary>
        /// <param name="item">Type: Returns_KeyValuePair&lt;TKey, TValue&gt;. The key and value to add.</param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this.CheckIsReadOnly();
            this._innerDictionary.Add(item);
        }

        /// <summary>Adds the elements of the specified collection to the end of the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>.</summary>
        /// <param name="items">Type: Returns_KeyValuePair&lt;TKey, TValue&gt;[].
        /// The array whose elements should be added to the end of the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>. The array itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public void AddRange(params KeyValuePair<TKey, TValue>[] items)
        {
            this.CheckIsReadOnly();
            this.AddRange((IEnumerable<KeyValuePair<TKey, TValue>>)items);
        }

        /// <summary>Adds the elements of the specified collection to the end of the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>.</summary>
        /// <param name="items">Type: Returns_IEnumerable&lt;Returns_KeyValuePair&lt;TKey, TValue&gt;&gt;.
        /// The collection whose elements should be added to the end of the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Allows AddRange to be used for multiple types of enumerable items")]
        public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            if (items == null)
                return;
            this.CheckIsReadOnly();
            ICollection<KeyValuePair<TKey, TValue>> innerDictionary = (ICollection<KeyValuePair<TKey, TValue>>)this._innerDictionary;
            foreach (KeyValuePair<TKey, TValue> keyValuePair in items)
                innerDictionary.Add(keyValuePair);
        }

        /// <summary>Adds the specified key and value to the dictionary.</summary>
        /// <param name="value">Type: TValue. The value of the element to add.</param>
        /// <param name="key">Type: TKey. The key of the element to add.</param>
        public void Add(TKey key, TValue value)
        {
            this.CheckIsReadOnly();
            this._innerDictionary.Add(key, value);
        }

        /// <summary>Gets or sets the value associated with the specified key.</summary>
        /// <returns>Type: TValue
        /// The value associated with the specified key.</returns>
        /// <param name="key">Type: TKey. The key of the value to get or set.</param>
        public virtual TValue this[TKey key]
        {
            get
            {
                return this._innerDictionary[key];
            }
            set
            {
                this.CheckIsReadOnly();
                this._innerDictionary[key] = value;
            }
        }

        /// <summary>Removes all items from the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>. </summary>
        public void Clear()
        {
            this.CheckIsReadOnly();
            this._innerDictionary.Clear();
        }

        /// <summary>Determines whether the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see> contains a specific value.</summary>
        /// <returns>Type: Returns_Booleantrue if item is found in the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>; otherwise, false.</returns>
        /// <param name="key">Type: TKey. The key to locate in the collection.</param>
        public bool Contains(TKey key)
        {
            return this._innerDictionary.ContainsKey(key);
        }

        /// <summary>Determines whether the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see> contains a specific value.</summary>
        /// <returns>Type: Returns_Booleantrue if item is found in the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>; otherwise, false.</returns>
        /// <param name="key">Type: Returns_KeyValuePair&lt;TKey, TValue&gt;. The key value pair to locate in the collection.</param>
        public bool Contains(KeyValuePair<TKey, TValue> key)
        {
            return this._innerDictionary.Contains(key);
        }

        /// <summary>Gets the value associated with the specified key.</summary>
        /// <returns>Type: Returns_Booleantrue if the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see> contains an element with the specified key; otherwise, false.</returns>
        /// <param name="value">Type: TValue%. When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
        /// <param name="key">Type: TKey. The key of the value to get.</param>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return this._innerDictionary.TryGetValue(key, out value);
        }

        /// <param name="arrayIndex">Type: Returns_Int32. Copies the entire <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see> to a compatible one-dimensional array, starting at the specified index of the target array.</param>
        /// <param name="array">Type: Returns_KeyValuePair&lt;TKey, TValue&gt;[]. The </param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            this._innerDictionary.CopyTo(array, arrayIndex);
        }

        /// <summary>Determines whether the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see> contains a specific key value.</summary>
        /// <returns>Type: Returns_Booleantrue if item is found in the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>; otherwise, false.</returns>
        /// <param name="key">Type: TKey. The key to locate in the collection.</param>
        public bool ContainsKey(TKey key)
        {
            return this._innerDictionary.ContainsKey(key);
        }

        /// <summary>Removes the first occurrence of a specific object from the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>.</summary>
        /// <returns>Type: Returns_Booleantrue if the object was found and removed; otherwise, false.</returns>
        /// <param name="key">Type: TKey. The object to remove from the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>.</param>
        public bool Remove(TKey key)
        {
            this.CheckIsReadOnly();
            return this._innerDictionary.Remove(key);
        }

        /// <summary>Removes the first occurrence of a specific object from the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>.</summary>
        /// <returns>Type: Returns_Booleantrue if the object was found and removed; otherwise, false.</returns>
        /// <param name="item">Type: Returns_KeyValuePair&lt;TKey, TValue&gt;.
        /// The object to remove from the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>.</param>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            this.CheckIsReadOnly();
            return ((ICollection<KeyValuePair<TKey, TValue>>)this._innerDictionary).Remove(item);
        }

        /// <summary>Gets the number of elements in the collection.</summary>
        /// <returns>Type: Returns_Int32
        /// The number of elements in the collection.</returns>
        public int Count
        {
            get
            {
                return this._innerDictionary.Count;
            }
        }

        /// <summary>Gets a collection containing the keys in the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>.</summary>
        /// <returns>Type: Returns_ICollection_Generic&lt;TKey&gt;
        /// A collection containing the keys in the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>.</returns>
        public ICollection<TKey> Keys
        {
            get
            {
                return this._innerDictionary.Keys;
            }
        }

        /// <summary>Gets a collection containing the values in the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>.</summary>
        /// <returns>Type: Returns_ICollection_Generic&lt;TValue&gt;
        /// A collection containing the values in the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see>.</returns>
        public ICollection<TValue> Values
        {
            get
            {
                return this._innerDictionary.Values;
            }
        }

        /// <summary>Gets a value indicating whether the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see> is read-only.</summary>
        /// <returns>Type: Returns_Booleantrue if the <see cref="T:Microsoft.Xrm.Sdk.DataCollection`2"></see> is read-only; otherwise, false.</returns>
        public virtual bool IsReadOnly
        {
            get
            {
                return this._isReadOnly;
            }
            internal set
            {
                this._isReadOnly = value;
            }
        }

        internal void SetItemInternal(TKey key, TValue value)
        {
            this._innerDictionary[key] = value;
        }

        internal void ClearInternal()
        {
            this._innerDictionary.Clear();
        }

        internal bool RemoveInternal(TKey key)
        {
            return this._innerDictionary.Remove(key);
        }

        private void CheckIsReadOnly()
        {
            if (this.IsReadOnly)
                throw new InvalidOperationException("The collection is read-only.");
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>Type: Returns_IEnumerator_Generic&lt;Returns_KeyValuePair&lt;TKey, TValue&gt;&gt;
        /// An Returns_IEnumerator_Generic object that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this._innerDictionary.GetEnumerator();
        }

        [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Returning the enumerator.")]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this._innerDictionary.GetEnumerator();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
        private static IEnumerable<Type> GetKnownParameterTypes()
        {
            return KnownTypesProvider.RetrieveKnownValueTypes();
        }
    }
}