using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Describes the behavior of the associated menu for a one-to-many relationship.</summary>
    [DataContract(Name = "AssociatedMenuBehavior", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum AssociatedMenuBehavior
    {
        /// <summary>Use the collection name for the associated menu. Value = 0.</summary>
        [EnumMember(Value = "UseCollectionName")] UseCollectionName,
        /// <summary>Use the label for the associated menu. Value = 1.</summary>
        [EnumMember(Value = "UseLabel")] UseLabel,
        /// <summary>Do not show the associated menu. Value = 2.</summary>
        [EnumMember(Value = "DoNotDisplay")] DoNotDisplay,
    }
}