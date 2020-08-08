using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class CrmBoolean
    {
        private bool isNullField;
        private bool isNullFieldSpecified;
        private string nameField;
        private bool valueField;

        public CrmBoolean()
        {
        }

        public CrmBoolean(bool value)
        {
            this.Value = value;
        }

        public static CrmBoolean Null
        {
            get
            {
                return new CrmBoolean()
                       {
                           IsNull = true,
                           IsNullSpecified = true
                       };
            }
        }

        public override bool Equals(object obj)
        {
            return obj is CrmBoolean crmBoolean && this.IsNull == crmBoolean.IsNull && this.IsNullSpecified == crmBoolean.IsNullSpecified && this.Value.Equals(crmBoolean.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        [XmlAttribute]
        public bool IsNull
        {
            get
            {
                return this.isNullField;
            }
            set
            {
                this.isNullField = value;
            }
        }

        [XmlIgnore]
        public bool IsNullSpecified
        {
            get
            {
                return this.isNullFieldSpecified;
            }
            set
            {
                this.isNullFieldSpecified = value;
            }
        }

        [XmlAttribute]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [XmlText]
        public bool Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}