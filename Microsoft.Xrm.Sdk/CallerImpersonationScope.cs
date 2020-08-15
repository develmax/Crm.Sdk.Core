using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Identifies a user as the owner of all data changes made by calls to a Web service.</summary>
  public sealed class CallerImpersonationScope : IDisposable
  {
    private bool _disposed;
    private OperationContextScope scope;

    /// <summary>constructor_initializesCallerImpersonationScope class.</summary>
    /// <param name="service">Type: <see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>. Specifies an organization service object.</param>
    /// <param name="callerId">Type: Returns_Guid. Specifies the ID of the user that owns any data changes made by a call to the service.</param>
    public CallerImpersonationScope(IOrganizationService service, Guid callerId)
    {
      MessageHeader header = MessageHeader.CreateHeader("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) callerId);
      this.scope = new OperationContextScope((IContextChannel) service);
      OperationContext.Current.OutgoingMessageHeaders.Add(header);
    }

    /// <summary>Disposes the CallerImpersonationScope object.</summary>
    public void Dispose()
    {
      if (this._disposed)
        return;
      if (OperationContext.Current != null)
      {
        OperationContext.Current.OutgoingMessageHeaders.RemoveAll("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts");
        if (this.scope != null)
          this.scope.Dispose();
      }
      this._disposed = true;
    }
  }
}
