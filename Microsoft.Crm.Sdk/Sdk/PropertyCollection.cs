using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public sealed class PropertyCollection : IEnumerable<Property>, IEnumerable
    {
        private Dictionary<string, object> _nameToPropertyValue = new Dictionary<string, object>();

        public object this[string propertyName]
        {
            get
            {
                return this._nameToPropertyValue[propertyName];
            }
            set
            {
                this._nameToPropertyValue[propertyName] = value;
            }
        }

        public int Count
        {
            get
            {
                return this._nameToPropertyValue.Count;
            }
        }

        public bool Contains(string propertyName)
        {
            return this._nameToPropertyValue.ContainsKey(propertyName);
        }

        public void Add(Property property)
        {
            this._nameToPropertyValue[property.Name] = property.GetValue();
        }

        public void AddRange(Property[] properties)
        {
            foreach (Property property in properties)
                this.Add(property);
        }

        public bool Remove(string propertyName)
        {
            return this._nameToPropertyValue.Remove(propertyName);
        }

        IEnumerator<Property> IEnumerable<Property>.GetEnumerator()
        {
            return this.InternalGetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.InternalGetEnumerator();
        }

        private IEnumerator<Property> InternalGetEnumerator()
        {
            List<Property> propertyList = new List<Property>();
            foreach (KeyValuePair<string, object> keyValuePair in this._nameToPropertyValue)
                propertyList.Add(PropertyFactory.Instance.CreateInstance(keyValuePair.Key, keyValuePair.Value));
            return (IEnumerator<Property>)propertyList.GetEnumerator();
        }
    }
}