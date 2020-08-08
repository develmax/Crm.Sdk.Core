using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class CrmMoney
    {
        private bool isNullField;
        private bool isNullFieldSpecified;
        private string formattedvalueField;
        private Decimal valueField;

        public CrmMoney()
        {
        }

        public CrmMoney(Decimal value)
        {
            this.Value = value;
        }

        public static CrmMoney Null
        {
            get
            {
                return new CrmMoney()
                       {
                           IsNull = true,
                           IsNullSpecified = true
                       };
            }
        }

        public override bool Equals(object obj)
        {
            return obj is CrmMoney crmMoney && this.IsNull == crmMoney.IsNull && this.IsNullSpecified == crmMoney.IsNullSpecified && this.Value.Equals(crmMoney.Value);
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