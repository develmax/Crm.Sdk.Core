using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveRelationshipRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveRelationshipResponse : OrganizationResponse
  {
    /// <summary>Gets the metadata for the entity relationship.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase"></see>The metadata for the entity relationship.</returns>
    public RelationshipMetadataBase RelationshipMetadata
    {
      get
      {
        return this.Results.Contains(nameof (RelationshipMetadata)) ? (RelationshipMetadataBase) this.Results[nameof (RelationshipMetadata)] : (RelationshipMetadataBase) null;
      }
    }
  }
}
