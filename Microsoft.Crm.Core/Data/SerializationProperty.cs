using System.Xml.Serialization;

namespace Microsoft.Crm.Data
{
    public class SerializationProperty
    {
        private string _name;
        private object _value;

        public SerializationProperty()
            : this(string.Empty, (object)null)
        {
        }

        public SerializationProperty(string name, object value)
        {
            this._name = name;
            this._value = value;
        }

        [XmlAttribute("name")]
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

        public object Value
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
    }
}