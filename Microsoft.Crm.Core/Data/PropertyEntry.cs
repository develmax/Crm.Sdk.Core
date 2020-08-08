using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Crm.Data
{
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = "BASELINE: BackLog", MessageId = "")]
    public struct PropertyEntry
    {
        private string _name;
        private IProperty _property;

        public PropertyEntry(string name, IProperty propertyImplementation)
        {
            this._name = name;
            this._property = propertyImplementation;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public IProperty Property
        {
            get
            {
                return this._property;
            }
        }

        public object Value
        {
            get
            {
                return this._property.Value;
            }
        }

        public PropertyState State
        {
            get
            {
                return this._property.State;
            }
        }

        public PropertyFlags Flags
        {
            get
            {
                return this._property.Flags;
            }
        }
    }
}