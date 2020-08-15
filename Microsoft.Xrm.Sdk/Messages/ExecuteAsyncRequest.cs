using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to execute a message asynchronously.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ExecuteAsyncRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the request to execute asynchronously.</summary>
    /// <returns>Returns <see cref="T:Microsoft.Xrm.Sdk.OrganizationRequest"></see>The request to execute asynchronously.</returns>
    public OrganizationRequest Request
    {
      get
      {
        return this.Parameters.Contains(nameof (Request)) ? (OrganizationRequest) this.Parameters[nameof (Request)] : (OrganizationRequest) null;
      }
      set
      {
        this.Parameters[nameof (Request)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Messages.ExecuteAsyncRequest"></see> class.</summary>
    public ExecuteAsyncRequest()
    {
      this.RequestName = "ExecuteAsync";
      this.Request = (OrganizationRequest) null;
    }
  }
}
