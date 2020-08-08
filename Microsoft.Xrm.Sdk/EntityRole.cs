using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains values to indicate the role the entity plays in a relationship.</summary>
    [DataContract(Name = "EntityRole", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public enum EntityRole
    {
        /// <summary>Specifies that the entity is the referencing entity. Value = 0.</summary>
        [EnumMember] Referencing,
        /// <summary>Specifies that the entity is the referenced entity. Value = 1.</summary>
        [EnumMember] Referenced,
    }
}