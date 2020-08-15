using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to check if data encryption is currently running (active or inactive).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class IsDataEncryptionActiveRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveTimestampResponse"></see> class.</summary>
    public IsDataEncryptionActiveRequest()
    {
      this.RequestName = "IsDataEncryptionActive";
    }
  }
}
