using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveTimestampRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveTimestampResponse : OrganizationResponse
  {
    /// <summary>Gets the time stamp of the metadata.</summary>
    /// <returns>Type: Returns_StringThe time stamp of the metadata.</returns>
    public string Timestamp
    {
      get
      {
        return this.Results.Contains(nameof (Timestamp)) ? (string) this.Results[nameof (Timestamp)] : (string) null;
      }
    }
  }
}
