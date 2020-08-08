using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class CrmDecimal
    {
        private bool isNullField;
        private bool isNullFieldSpecified;
        private string formattedvalueField;
        private Decimal valueField;

        public CrmDecimal()
        {
        }

        public CrmDecimal(Decimal value)
        {
            this.Value = value;
        }

        public static CrmDecimal Null
        {
            get
            {
                return new CrmDecimal()
                       {
                           IsNull = true,
                           IsNullSpecified = true
                       };
            }
        }

        public override bool Equals(object obj)
        {
            return obj is CrmDecimal crmDecimal && this.IsNull == crmDecimal.IsNull && this.IsNullSpecified == crmDecimal.IsNullSpecified && this.Value.Equals(crmDecimal.Value);
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
        public Decimal Value
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