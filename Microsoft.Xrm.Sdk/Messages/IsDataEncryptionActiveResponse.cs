using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.IsDataEncryptionActiveRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class IsDataEncryptionActiveResponse : OrganizationResponse
  {
    /// <summary>Gets whether data encryption is active or not.</summary>
    /// <returns>Type: Returns_Stringtrue if data encryption is active; otherwise, false.</returns>
    public bool IsActive
    {
      get
      {
        return this.Results.Contains(nameof (IsActive)) && (bool) this.Results[nameof (IsActive)];
      }
    }
  }
}
