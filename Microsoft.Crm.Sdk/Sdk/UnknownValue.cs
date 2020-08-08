namespace Microsoft.Crm.Sdk
{
    public sealed class UnknownValue
    {
        public UnknownValue()
        {
            this.Value = (object)null;
        }

        public UnknownValue(object value)
        {
            this.Value = value;
        }

        public object Value { get; set; }
    }
}