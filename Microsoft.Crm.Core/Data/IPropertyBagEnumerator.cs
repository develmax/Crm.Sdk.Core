using System.Collections;

namespace Microsoft.Crm.Data
{
    public interface IPropertyBagEnumerator : IEnumerator
    {
        PropertyEntry Entry { get; }

        string Name { get; }

        IProperty Property { get; }

        object Value { get; }

        PropertyState State { get; }

        PropertyFlags Flags { get; }
    }
}