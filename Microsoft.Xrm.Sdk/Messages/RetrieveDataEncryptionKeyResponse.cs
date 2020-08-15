using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveDataEncryptionKeyResponse"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveDataEncryptionKeyResponse : OrganizationResponse
  {
    /// <summary>Gets or sets the encryption key.</summary>
    /// <returns>Type: Returns_String. The value returned is the decrypted data encryption key.</returns>
    public string EncryptionKey
    {
      get
      {
        return this.Results.Contains(nameof (EncryptionKey)) ? (string) this.Results[nameof (EncryptionKey)] : (string) null;
      }
    }
  }
}
