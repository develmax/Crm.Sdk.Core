namespace Microsoft.Crm.Sdk
{
    public class UnknownProperty : Property
    {
        private UnknownValue _value = new UnknownValue();

        public UnknownValue Value
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

        internal override object GetValue()
        {
            return (object)this.Value;
        }

        internal override void SetValue(object value)
        {
            this.Value = (UnknownValue)value;
        }
    }
}