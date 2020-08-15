using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveEntityRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveEntityResponse : OrganizationResponse
  {
    /// <summary>Gets the metadata for the requested entity.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.EntityMetadata"></see>The metadata for the requested entity.</returns>
    public EntityMetadata EntityMetadata
    {
      get
      {
        return this.Results.Contains(nameof (EntityMetadata)) ? (EntityMetadata) this.Results[nameof (EntityMetadata)] : (EntityMetadata) null;
      }
    }
  }
}
