using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateOneToManyRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateOneToManyResponse : OrganizationResponse
  {
    /// <summary>Gets the <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.LookupAttributeMetadata"></see> that is created.</summary>
    /// <returns>Type: Returns_GuidThe <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.LookupAttributeMetadata"></see> that is created..</returns>
    public Guid AttributeId
    {
      get
      {
        return this.Results.Contains(nameof (AttributeId)) ? (Guid) this.Results[nameof (AttributeId)] : new Guid();
      }
    }

    /// <summary>Gets the <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.OneToManyRelationshipMetadata"></see>that is created.</summary>
    /// <returns>Type: Returns_GuidThe <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.OneToManyRelationshipMetadata"></see> that is created..</returns>
    public Guid RelationshipId
    {
      get
      {
        return this.Results.Contains(nameof (RelationshipId)) ? (Guid) this.Results[nameof (RelationshipId)] : new Guid();
      }
    }
  }
}
