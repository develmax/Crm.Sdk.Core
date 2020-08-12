// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.TraceInfo
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Specifies the results of a scheduling operation using the <see cref="T:Microsoft.Crm.Sdk.Messages.ValidateRequest"></see>, <see cref="T:Microsoft.Crm.Sdk.Messages.BookRequest"></see>, <see cref="T:Microsoft.Crm.Sdk.Messages.RescheduleRequest"></see>, or <see cref="T:Microsoft.Crm.Sdk.Messages.SearchRequest"></see> messages.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class TraceInfo : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.TraceInfo"></see> class.</summary>
    public TraceInfo()
    {
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.TraceInfo"></see> class.</summary>
    /// <param name="errorInfo">Type: <see cref="T:Microsoft.Crm.Sdk.Messages.ErrorInfo"></see>[]. The list of error information for the scheduling operation.</param>
    public TraceInfo(ErrorInfo[] errorInfo)
    {
      this.ErrorInfoList = errorInfo;
    }

    /// <summary>Gets or sets the list of error information for the scheduling operation.</summary>
    /// <returns>Returns <see cref="T:Microsoft.Crm.Sdk.Messages.ErrorInfo"></see>[]The the list of error information for the scheduling operation.</returns>
    [DataMember]
    public ErrorInfo[] ErrorInfoList { get; set; }

    /// <summary>ExtensionData</summary>
    /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
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
