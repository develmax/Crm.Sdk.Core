using System;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Represents a factory for creating <see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see> instances.</summary>
  public interface IOrganizationServiceFactory
  {
    /// <summary>Returns an <see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see> instance for the organization that the specified user is a member of.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>An organization service factory object.</returns>
    /// <param name="userId">Type: Returns_Nullable&lt;Returns_Guid&gt;. Specifies the system user that calls to the service are made for.  A null value indicates the SYSTEM user. When called in a plug-in, a Guid.Empty value indicates the same user as <see cref="T:Microsoft.Xrm.Sdk.IPluginExecutionContext"></see>. <see cref="P:Microsoft.Xrm.Sdk.IExecutionContext.UserId"></see>. When called in a custom workflow activity, a  Guid.Empty value indicates the same user as IWorkflowExecutionContext.<see cref="P:Microsoft.Xrm.Sdk.IExecutionContext.UserId"></see>. Any other value indicates a specific system user. </param>
    IOrganizationService CreateOrganizationService(Guid? userId);
  }
}
