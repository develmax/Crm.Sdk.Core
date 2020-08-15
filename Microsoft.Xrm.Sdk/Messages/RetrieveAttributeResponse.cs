using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveAttributeRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAttributeResponse : OrganizationResponse
  {
    /// <summary>Gets the metadata for the requested attribute.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeMetadata"></see>The metadata for the requested attribute.</returns>
    public AttributeMetadata AttributeMetadata
    {
      get
      {
        return this.Results.Contains(nameof (AttributeMetadata)) ? (AttributeMetadata) this.Results[nameof (AttributeMetadata)] : (AttributeMetadata) null;
      }
    }
  }
}
