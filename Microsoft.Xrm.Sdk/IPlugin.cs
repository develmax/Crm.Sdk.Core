using System;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Base interface for a plug-in.</summary>
  public interface IPlugin
  {
    /// <summary>Executes plug-in code in response to an event.</summary>
    /// <param name="serviceProvider">Type: Returns_IServiceProvider. A container for service objects. Contains references to the plug-in execution context (<see cref="T:Microsoft.Xrm.Sdk.IPluginExecutionContext"></see>), tracing service (<see cref="T:Microsoft.Xrm.Sdk.ITracingService"></see>), organization service (<see cref="T:Microsoft.Xrm.Sdk.IOrganizationServiceFactory"></see>), and notification service (<see cref="T:Microsoft.Xrm.Sdk.IServiceEndpointNotificationService"></see>). </param>
    void Execute(IServiceProvider serviceProvider);
  }
}
