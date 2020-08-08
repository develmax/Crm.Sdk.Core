using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Describes the type of behavior for a specific action applied to the referenced entity in a one-to-many entity relationship.</summary>
    [DataContract(Name = "CascadeType", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum CascadeType
    {
        /// <summary>Do nothing. Value = 0.</summary>
        [EnumMember(Value = "NoCascade")] NoCascade,
        /// <summary>Perform the action on all referencing entity records associated with the referenced entity record. Value = 1.</summary>
        [EnumMember(Value = "Cascade")] Cascade,
        /// <summary>Perform the action on all active referencing entity records associated with the referenced entity record. Value = 2.</summary>
        [EnumMember(Value = "Active")] Active,
        /// <summary>Perform the action on all referencing entity records owned by the same user as the referenced entity record. Value = 3.</summary>
        [EnumMember(Value = "UserOwned")] UserOwned,
        /// <summary>Remove the value of the referencing attribute for all referencing entity records associated with the referenced entity record. Value = 4.</summary>
        [EnumMember(Value = "RemoveLink")] RemoveLink,
        /// <summary>Prevent the Referenced entity record from being deleted when referencing entities exist. Value = 5.</summary>
        [EnumMember(Value = "Restrict")] Restrict,
    }
}