using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Defines a managed property that stores a Boolean value.</summary>
    [DataContract(Name = "BooleanManagedProperty", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class BooleanManagedProperty : ManagedProperty<bool>
    {
        /// <summary>constructor_initializes<see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see> class</summary>
        public BooleanManagedProperty()
            : this(false)
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see> class</summary>
        /// <param name="value">Type: Returns_Boolean.
        /// true if the value is true; otherwise, false.</param>
        public BooleanManagedProperty(bool value)
            : this(value, (string)null)
        {
        }

        internal BooleanManagedProperty(bool value, string logicalName)
            : base(logicalName)
        {
            this.Value = value;
        }
    }
}