using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieves a time stamp for the metadata.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveTimestampRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the  RetrieveTimestampRequest class</summary>
    public RetrieveTimestampRequest()
    {
      this.RequestName = "RetrieveTimestamp";
    }
  }
}
