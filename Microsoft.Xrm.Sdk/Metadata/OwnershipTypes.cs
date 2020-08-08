using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Specifies the type of ownership for an entity.</summary>
    [Flags]
    [DataContract(Name = "OwnershipTypes", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum OwnershipTypes
    {
        /// <summary>The entity does not have an owner. internal Value = 0.</summary>
        [EnumMember(Value = "None")] None = 0,
        /// <summary>The entity is owned by a system user. Value = 1.</summary>
        [EnumMember(Value = "UserOwned")] UserOwned = 1,
        /// <summary>The entity is owned by a team. internalValue = 2.</summary>
        [EnumMember(Value = "TeamOwned")] TeamOwned = 2,
        /// <summary>The entity is owned by a business unit. internal Value = 4. </summary>
        [EnumMember(Value = "BusinessOwned")] BusinessOwned = 4,
        /// <summary>The entity is owned by an organization. Value = 8.</summary>
        [EnumMember(Value = "OrganizationOwned")] OrganizationOwned = 8,
        /// <summary>The entity is parented by a business unit. internal Value = 16.  </summary>
        [EnumMember(Value = "BusinessParented")] BusinessParented = 16, // 0x00000010
    }
}