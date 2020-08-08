using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Describes the group in which to display the associated menu for an entity relationship</summary>
    [DataContract(Name = "AssociatedMenuGroup", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum AssociatedMenuGroup
    {
        /// <summary>Show the associated menu in the details group. Value = 0.</summary>
        [EnumMember(Value = "Details")] Details,
        /// <summary>Show the associated menu in the sales group. Value = 1.</summary>
        [EnumMember(Value = "Sales")] Sales,
        /// <summary>Show the associated menu in the service group. Value = 2.</summary>
        [EnumMember(Value = "Service")] Service,
        /// <summary>Show the associated menu in the marketing group. Value = 3.</summary>
        [EnumMember(Value = "Marketing")] Marketing,
    }
}