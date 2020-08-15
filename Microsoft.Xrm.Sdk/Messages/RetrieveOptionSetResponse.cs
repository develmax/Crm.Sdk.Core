using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveOptionSetRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveOptionSetResponse : OrganizationResponse
  {
    /// <summary>Gets the metadata for the global option set.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadataBase"></see> The metadata for the global option set.</returns>
    public OptionSetMetadataBase OptionSetMetadata
    {
      get
      {
        return this.Results.Contains(nameof (OptionSetMetadata)) ? (OptionSetMetadataBase) this.Results[nameof (OptionSetMetadata)] : (OptionSetMetadataBase) null;
      }
    }
  }
}
