
using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Crm.Data
{
    public abstract class PropertyBase : IPropertyManagement
    {
        private PropertyState _state;
        private PropertyFlags _flags;

        protected PropertyBase(PropertyState state, PropertyFlags flags)
        {
            this._state = state;
            this._flags = flags;
        }

        public PropertyState State
        {
            get
            {
                return this._state;
            }
        }

        public bool HasValue
        {
            get
            {
                return this._state != PropertyState.Uninitialized && this._state != PropertyState.Deleted;
            }
        }

        public PropertyFlags Flags
        {
            get
            {
                return this._flags;
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "BASELINE: BackLog", MessageId = "")]
        protected void SetState(PropertyState newState)
        {
            switch (newState)
            {
                case PropertyState.Uninitialized:
                case PropertyState.Unchanged:
                case PropertyState.New:
                case PropertyState.Modified:
                case PropertyState.Deleted:
                    this._state = newState;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), (object)newState, "New state must be a valid PropertyState.");
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "BASELINE: BackLog", MessageId = "")]
        protected void SetFlags(PropertyFlags flags)
        {
            if ((~PropertyFlags.All & flags) != PropertyFlags.Ignore)
                throw new ArgumentOutOfRangeException(nameof(flags), (object)flags, "New flags combination must be a valid PropertyFlags.");
            this._flags = flags;
        }

        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "BASELINE: BackLog", MessageId = "")]
        void IPropertyManagement.SetState(PropertyState newState)
        {
            this.SetState(newState);
        }
    }
}