// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.BusinessNotification
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

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
