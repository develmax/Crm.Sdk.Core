using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetDecryptionKeyResponse : OrganizationResponse
  {
    /// <summary>Gets the decryption key.</summary>
    /// <returns>Type: Returns_StringThe decryption key.</returns>
    public string Key
    {
      get
      {
        return this.Results.Contains(nameof (Key)) ? (string) this.Results[nameof (Key)] : (string) null;
      }
    }
  }
}
