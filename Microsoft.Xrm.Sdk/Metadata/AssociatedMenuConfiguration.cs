using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Defines how the associated records are displayed for an entity relationship.</summary>
    [DataContract(Name = "AssociatedMenuConfiguration", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class AssociatedMenuConfiguration : IExtensibleDataObject
    {
        private AssociatedMenuBehavior? _associatedMenuBehavior;
        private AssociatedMenuGroup? _associatedMenuGroup;
        private Label _associatedMenuLabel;
        private int? _associatedMenuOrder;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Gets or sets the behavior of the associated menu for an entity relationship.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.AssociatedMenuBehavior"></see>&gt;
        /// One of the enumeration values that specify the behavior of the associated menu for a one-to-many relationship.</returns>
        [DataMember]
        public AssociatedMenuBehavior? Behavior
        {
            get
            {
                return this._associatedMenuBehavior;
            }
            set
            {
                this._associatedMenuBehavior = value;
            }
        }

        /// <summary>Gets or sets the group for the associated menu for an entity relationship.</summary>
        /// <returns>Type: Returns_Nullable&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.AssociatedMenuGroup"></see>&gt;
        /// One of the enumeration values that specify the group in which to display the associated menu for an entity relationship.</returns>
        [DataMember]
        public AssociatedMenuGroup? Group
        {
            get
            {
                return this._associatedMenuGroup;
            }
            set
            {
                this._associatedMenuGroup = value;
            }
        }

        /// <summary>Gets or sets the label for the associated menu.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>
        /// A string that contains the menu label.</returns>
        [DataMember]
        public Label Label
        {
            get
            {
                return this._associatedMenuLabel;
            }
            set
            {
                this._associatedMenuLabel = value;
            }
        }

        /// <summary>Gets or sets the order for the associated menu.</summary>
        /// <returns>Type: Returns_Nullable&lt;int&gt;
        /// An integer that controls the relative position of navigation items in the group.</returns>
        [DataMember]
        public int? Order
        {
            get
            {
                return this._associatedMenuOrder;
            }
            set
            {
                this._associatedMenuOrder = value;
            }
        }

        /// <summary>ExtensionData</summary>
        /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return this._extensionDataObject;
            }
            set
            {
                this._extensionDataObject = value;
            }
        }
    }
}
