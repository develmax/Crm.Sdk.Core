using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class CrmNumber
    {
        private bool isNullField;
        private bool isNullFieldSpecified;
        private string formattedvalueField;
        private int valueField;

        public CrmNumber()
        {
        }

        public CrmNumber(int value)
        {
            this.Value = value;
        }

        public static CrmNumber Null
        {
            get
            {
                return new CrmNumber()
                       {
                           IsNull = true,
                           IsNullSpecified = true
                       };
            }
        }

        public override bool Equals(object obj)
        {
            return obj is CrmNumber crmNumber && this.IsNull == crmNumber.IsNull && this.IsNullSpecified == crmNumber.IsNullSpecified && this.Value.Equals(crmNumber.Value);
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
        public string formattedvalue
        {
            get
            {
                return this.formattedvalueField;
            }
            set
            {
                this.formattedvalueField = value;
            }
        }

        [XmlText]
        public int Value
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