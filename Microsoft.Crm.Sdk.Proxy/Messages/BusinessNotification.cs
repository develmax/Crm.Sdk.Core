using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class BusinessNotification : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <returns>Returns <see cref="T:Microsoft.Crm.Sdk.Messages.BusinessNotificationSeverity"></see>.</returns>
    [DataMember]
    public BusinessNotificationSeverity Severity { get; set; }

    /// <returns>Returns <see cref="T:System.String"></see>.</returns>
    [DataMember]
    public string Message { get; set; }

    /// <returns>Returns <see cref="T:Microsoft.Crm.Sdk.Messages.BusinessNotificationParameter"></see>.</returns>
    [DataMember]
    public BusinessNotificationParameter[] Parameters { get; set; }

    public BusinessNotification(BusinessNotificationSeverity severity, string message)
    {
      this.Severity = severity;
      this.Message = message;
    }

    /// <returns>Returns <see cref="T:System.Runtime.Serialization.ExtensionDataObject"></see>.</returns>
    public ExtensionDataObject ExtensionData
    {
      get
      {
        return this._extensionDataObject;
      }
      set
      {
        this._extensionDataObject = value;
      }
    }
  }
}
