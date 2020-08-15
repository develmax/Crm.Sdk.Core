namespace Microsoft.Xrm.Sdk
{
  /// <summary>Posts the plug-in execution context to the windows_azure_service_bus.</summary>
  public interface IServiceEndpointNotificationService
  {
    /// <summary>Posts the execution context to the specified service endpoint in the cloud. </summary>
    /// <returns>Type: Returns_StringThe result. Only a two-way or REST listener will return a string back to the caller.</returns>
    /// <param name="context">Type: <see cref="T:Microsoft.Xrm.Sdk.IExecutionContext"></see>. The event execution context.</param>
    /// <param name="serviceEndpoint">Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>. The service endpoint to post to in the cloud.</param>
    string Execute(EntityReference serviceEndpoint, IExecutionContext context);
  }
}
