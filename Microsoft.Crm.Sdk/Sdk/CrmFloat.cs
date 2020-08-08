using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class CrmFloat
    {
        private bool isNullField;
        private bool isNullFieldSpecified;
        private string formattedvalueField;
        private double valueField;

        public CrmFloat()
        {
        }

        public CrmFloat(double value)
        {
            this.Value = value;
        }

        public static CrmFloat Null
        {
            get
            {
                return new CrmFloat()
                       {
                           IsNull = true,
                           IsNullSpecified = true
                       };
            }
        }

        public override bool Equals(object obj)
        {
            return obj is CrmFloat crmFloat && this.IsNull == crmFloat.IsNull && this.IsNullSpecified == crmFloat.IsNullSpecified && this.Value.Equals(crmFloat.Value);
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
        public double Value
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