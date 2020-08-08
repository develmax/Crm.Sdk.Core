using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Specifies the type of entity relationship.</summary>
    [DataContract(Name = "RelationshipType", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum RelationshipType
    {
        /// <summary>The default value. Equivalent to OneToManyRelationship. Value = 0.</summary>
        Default = 0,
        /// <summary>The entity relationship is a One-to-Many relationship. Value = 0.</summary>
        [EnumMember(Value = "OneToManyRelationship")] OneToManyRelationship = 0,
        /// <summary>The entity relationship is a Many-to-Many relationship. Value = 1.</summary>
        [EnumMember(Value = "ManyToManyRelationship")] ManyToManyRelationship = 1,
    }
}