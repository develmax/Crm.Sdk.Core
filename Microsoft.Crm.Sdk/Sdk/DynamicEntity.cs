using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class DynamicEntity : BusinessEntity
    {
        [NonSerialized]
        private PropertyCollection _unknownProperties = new PropertyCollection();
        private PropertyCollection _properties = new PropertyCollection();
        private string _name;

        public DynamicEntity()
        {
            this._properties = new PropertyCollection();
        }

        public DynamicEntity(string name)
            : this()
        {
            this._name = name;
        }

        [XmlArrayItem(Type = typeof(Property))]
        public PropertyCollection Properties
        {
            get
            {
                return this._properties;
            }
            set
            {
                this._properties = value;
            }
        }

        public object this[string propertyName]
        {
            get
            {
                return this._properties[propertyName];
            }
            set
            {
                this._properties[propertyName] = value;
            }
        }

        [XmlAttribute]
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

        [XmlIgnore]
        public PropertyCollection UnknownProperties
        {
            get
            {
                if (this._unknownProperties == null)
                    this._unknownProperties = new PropertyCollection();
                return this._unknownProperties;
            }
        }
    }
}