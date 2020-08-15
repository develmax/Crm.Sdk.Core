using System.ServiceModel;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Defines a plug-in that implements the service behavior of a windows_azure_service_bus listener.</summary>
  [ServiceContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public interface IServiceEndpointPlugin
  {
    /// <summary>Executes plug-in code in response to an event.</summary>
    /// <param name="executionContext">Type: <see cref="T:Microsoft.Xrm.Sdk.RemoteExecutionContext"></see>. Defines the contextual information passed to a plug-in at run-time.</param>
    [OperationContract(IsOneWay = true)]
    void Execute(RemoteExecutionContext executionContext);
  }
}
