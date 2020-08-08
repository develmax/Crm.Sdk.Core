using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Indicates the state of an entity as tracked by the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> and indicates to the server the operation that should be performed for a related entity.</summary>
    [DataContract(Name = "EntityState", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public enum EntityState
    {
        /// <summary>The entity is unchanged since the last call to <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see>. Value = 0.</summary>
        [EnumMember] Unchanged,
        /// <summary>The entity was created since the last call to <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see>. Value = 1.</summary>
        [EnumMember] Created,
        /// <summary>The entity was changed since the last call to <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see>. Value = 2.</summary>
        [EnumMember] Changed,
    }
}