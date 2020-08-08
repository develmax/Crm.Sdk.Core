using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the metadata for an attribute that references an entity.</summary>
    [DataContract(Name = "EntityNameAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class EntityNameAttributeMetadata : EnumAttributeMetadata
    {
        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.EntityNameAttributeMetadata"></see> class</summary>
        public EntityNameAttributeMetadata()
            : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.EntityNameAttributeMetadata"></see> class</summary>
        /// <param name="schemaName">Type: Returns_String
        /// The schema name of the attribute.</param>
        public EntityNameAttributeMetadata(string schemaName)
            : base(AttributeTypeCode.EntityName, schemaName)
        {
        }
    }
}