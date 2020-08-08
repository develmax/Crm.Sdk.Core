using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Represents the data to define a <see cref="P:Microsoft.Xrm.Sdk.Metadata.AttributeMetadata.RequiredLevel"></see> property for an attribute.</summary>
    [DataContract(Name = "AttributeRequiredLevelManagedProperty", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class AttributeRequiredLevelManagedProperty : ManagedProperty<AttributeRequiredLevel>
    {
        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeRequiredLevelManagedProperty"></see> class.</summary>
        /// <param name="value">Type:  <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeRequiredLevel"></see>.</param>
        public AttributeRequiredLevelManagedProperty(AttributeRequiredLevel value)
            : this(value, (string)null)
        {
        }

        internal AttributeRequiredLevelManagedProperty(AttributeRequiredLevel value, string logicalName)
            : base(logicalName)
        {
            this.Value = value;
        }
    }
}