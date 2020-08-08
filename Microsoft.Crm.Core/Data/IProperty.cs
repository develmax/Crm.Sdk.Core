namespace Microsoft.Crm.Data
{
    public interface IProperty
    {
        bool HasValue { get; }

        object Value { get; set; }

        PropertyState State { get; }

        PropertyFlags Flags { get; }
    }
}