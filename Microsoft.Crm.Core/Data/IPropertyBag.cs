using System.Collections;

namespace Microsoft.Crm.Data
{
    [SizeHttpCacheKnownType]
    public interface IPropertyBag
    {
        object this[string propertyName] { get; set; }

        void SetValue(string propertyName, object newValue);

        void InitializeValueAndState(
            string propertyName,
            object propertyValue,
            PropertyState overrideState);

        void Add(string propertyName, IProperty newProperty);

        bool Contains(string propertyName);

        IProperty Get(string propertyName);

        void Remove(string propertyName);

        bool IsModified { get; }

        IEnumerable PropertyEntries { get; }

        IEnumerable SelectPropertyEntries(
            PropertyState stateMask,
            PropertyFlags includeFlags,
            PropertyFlags excludeFlags);

        void ResetStates();
    }
}