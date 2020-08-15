using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the data encryption key value.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveDataEncryptionKeyRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveDataEncryptionKeyRequest"></see> class.</summary>
    public RetrieveDataEncryptionKeyRequest()
    {
      this.RequestName = "RetrieveDataEncryptionKey";
    }
  }
}
