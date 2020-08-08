using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Describes the type of entity metadata to retrieve.</summary>
    [Flags]
    [DataContract(Name = "EntityFilters", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum EntityFilters
    {
        /// <summary>Use this to retrieve only entity information. Equivalent to EntityFilters.Default. Value = 1.</summary>
        [EnumMember(Value = "Entity")] Entity = 1,
        /// <summary>Use this to retrieve entity information plus attributes for the entity. Value = 2.</summary>
        [EnumMember(Value = "Attributes")] Attributes = 2,
        /// <summary>Use this to retrieve entity information plus privileges for the entity. Value = 4.</summary>
        [EnumMember(Value = "Privileges")] Privileges = 4,
        /// <summary>Use this to retrieve entity information plus entity relationships for the entity. Value = 8.</summary>
        [EnumMember(Value = "Relationships")] Relationships = 8,
        /// <summary>Use this to retrieve only entity information. Equivalent to EntityFilters.Entity. Value = 1.</summary>
        Default = Entity, // 0x00000001
        /// <summary>Use this to retrieve all data for an entity. Value = 15.</summary>
        All = Default | Relationships | Privileges | Attributes, // 0x0000000F
    }
}