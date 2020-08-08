using System;
using System.ComponentModel;
using System.Globalization;

namespace Microsoft.Crm.Sdk
{
    internal abstract class EnumConverter : TypeConverter
    {
        private Type _enumType;

        protected EnumConverter(Type enumType)
        {
            this._enumType = enumType;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(int) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
        {
            return destinationType == typeof(int) && value is Enum ? (object)(int)value : base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(int) || sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value)
        {
            switch (value)
            {
                case int _:
                case string _:
                    return Enum.Parse(this._enumType, value.ToString());
                default:
                    return base.ConvertFrom(context, culture, value);
            }
        }
    }
}