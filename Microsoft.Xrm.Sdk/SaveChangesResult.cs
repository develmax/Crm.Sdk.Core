using System;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Contains the result of the save changes operation returned from the organization web service.</summary>
  public sealed class SaveChangesResult
  {
    /// <summary>Gets the message request that was submitted to the organization web service.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationRequest"></see>The request instance that was submitted.</returns>
    public OrganizationRequest Request { get; private set; }

    /// <summary>Gets the result of a successful operation against the organization web server.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationResponse"></see>The response to the request.</returns>
    public OrganizationResponse Response { get; private set; }

    /// <summary>Gets the exception that occurred when a message request was processed by the organization web service.</summary>
    /// <returns>Type: Returns_ExceptionThe exception that occurred.</returns>
    public Exception Error { get; private set; }

    internal SaveChangesResult(OrganizationRequest request, OrganizationResponse response)
    {
      this.Request = request;
      this.Response = response;
    }

    internal SaveChangesResult(OrganizationRequest request, Exception error)
    {
      this.Request = request;
      this.Error = error;
    }
  }
}
