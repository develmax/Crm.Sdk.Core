using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveMetadataChangesRequest"></see> message.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveMetadataChangesResponse : OrganizationResponse
  {
    /// <summary>Gets the metadata defined by the request.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.EntityMetadataCollection"></see>The metadata defined by the request.</returns>
    public EntityMetadataCollection EntityMetadata
    {
      get
      {
        return this.Results.Contains(nameof (EntityMetadata)) ? (EntityMetadataCollection) this.Results[nameof (EntityMetadata)] : (EntityMetadataCollection) null;
      }
    }

    /// <summary>Gets the deleted metadata since the last request.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.DeletedMetadataCollection"></see>The deleted metadata since the last request.</returns>
    public DeletedMetadataCollection DeletedMetadata
    {
      get
      {
        return this.Results.Contains(nameof (DeletedMetadata)) ? (DeletedMetadataCollection) this.Results[nameof (DeletedMetadata)] : (DeletedMetadataCollection) null;
      }
    }

    /// <summary>Gets a timestamp identifier for the metadata retrieved.</summary>
    /// <returns>Type: Returns_String
    /// A timestamp identifier for the metadata retrieved..</returns>
    public string ServerVersionStamp
    {
      get
      {
        return this.Results.Contains(nameof (ServerVersionStamp)) ? (string) this.Results[nameof (ServerVersionStamp)] : (string) null;
      }
    }
  }
}
