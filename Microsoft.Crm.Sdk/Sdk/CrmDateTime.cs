using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class CrmDateTime
    {
        private static readonly DateTime _minDateTime = new DateTime(1900, 1, 1);
        private static readonly DateTime _maxDateTime = new DateTime(9999, 12, 30, 23, 59, 59);
        private DateTime? universalTime = new DateTime?();
        private DateTime? userTime = new DateTime?();
        private string parsedValue;
        private bool isNullField;
        private bool isNullFieldSpecified;
        private string dateField;
        private string timeField;
        private string valueField;

        public CrmDateTime()
        {
        }

        public CrmDateTime(string value)
        {
            this.Value = value;
        }

        public CrmDateTime(string value, string date, string time)
        {
            this.Value = value;
            this.date = date;
            this.time = time;
        }

        public DateTime UserTime
        {
            get
            {
                this.SetUserAndUniversalValues(this.Value);
                if (!this.userTime.HasValue)
                    throw new InvalidOperationException("CrmDateTime must be initialized in one of the following formats: yyyy/MM/ddTHH:mm:ss[+-]aa:bb or yyyy/MM/ddTHH:mm:ss");
                return this.userTime.Value;
            }
        }

        public DateTime UniversalTime
        {
            get
            {
                this.SetUserAndUniversalValues(this.Value);
                if (!this.universalTime.HasValue)
                    throw new InvalidOperationException("CrmDateTime must be initialized in one of the following formats: yyyy/MM/ddTHH:mm:ss[+-]aa:bb or yyyy/MM/ddTHH:mm:ssZ");
                return this.universalTime.Value;
            }
        }

        public static DateTime MinValue
        {
            get
            {
                return CrmDateTime._minDateTime;
            }
        }

        public static DateTime MaxValue
        {
            get
            {
                return CrmDateTime._maxDateTime;
            }
        }

        public static CrmDateTime FromUser(DateTime userTime)
        {
            return new CrmDateTime(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "{0:s}", (object)userTime));
        }

        public static CrmDateTime FromUniversal(DateTime universalTime)
        {
            return new CrmDateTime(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "{0:s}Z", (object)universalTime));
        }

        public static CrmDateTime Now
        {
            get
            {
                return CrmDateTime.FromUniversal(DateTime.UtcNow);
            }
        }

        public static CrmDateTime Null
        {
            get
            {
                return new CrmDateTime()
                {
                    IsNull = true,
                    IsNullSpecified = true
                };
            }
        }

        private void SetUserAndUniversalValues(string value)
        {
            if (!(this.parsedValue != value))
                return;
            this.universalTime = new DateTime?();
            this.userTime = new DateTime?();
            this.InitializeUserAndUniversalValues(value);
            this.parsedValue = value;
        }

        private void InitializeUserAndUniversalValues(string value)
        {
            string s = value.Trim();
            int length = s.Length;
            if (length == 0)
                throw new ArgumentException("Empty string is not a valid representation of CrmDateTime.");
            DateTime dateTime = DateTime.Parse(s, (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            if (s[length - 1] == 'Z' || s[length - 1] == 'z')
                this.universalTime = new DateTime?(dateTime);
            else if (length > 6 && (s[length - 6] == '+' || s[length - 6] == '-') && (s[length - 3] == ':' && s.IndexOf(':', 0, length - 6) >= 0))
            {
                this.userTime = new DateTime?(DateTime.Parse(s.Substring(0, length - 6), (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal));
                this.universalTime = new DateTime?(dateTime);
            }
            else
                this.userTime = new DateTime?(dateTime);
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
        public string date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        [XmlAttribute]
        public string time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        [XmlText]
        public string Value
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
