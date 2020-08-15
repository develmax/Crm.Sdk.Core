using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateOptionSetRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateOptionSetResponse : OrganizationResponse
  {
    /// <summary>Gets the <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> of the newly created <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata"></see>.</summary>
    /// <returns>Type: Returns_GuidThe <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> of the newly created <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata"></see>.</returns>
    public Guid OptionSetId
    {
      get
      {
        return this.Results.Contains(nameof (OptionSetId)) ? (Guid) this.Results[nameof (OptionSetId)] : new Guid();
      }
    }
  }
}
