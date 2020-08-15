using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.ExecuteAsyncRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ExecuteAsyncResponse : OrganizationResponse
  {
    /// <summary>Gets or sets the ID of the asynchronous job that was started from processing the <see cref="T:Microsoft.Xrm.Sdk.Messages.ExecuteAsyncRequest"></see>.</summary>
    /// <returns>Type: Returns_GuidThe ID of the asynchronous job.</returns>
    public Guid AsyncJobId
    {
      get
      {
        return this.Results.Contains(nameof (AsyncJobId)) ? (Guid) this.Results[nameof (AsyncJobId)] : new Guid();
      }
    }
  }
}
