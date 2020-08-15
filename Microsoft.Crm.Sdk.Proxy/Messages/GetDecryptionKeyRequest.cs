using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal See <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveDataEncryptionKeyRequest"></see>.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetDecryptionKeyRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.GetDecryptionKeyRequest"></see> class.</summary>
    public GetDecryptionKeyRequest()
    {
      this.RequestName = "GetDecryptionKey";
    }
  }
}
