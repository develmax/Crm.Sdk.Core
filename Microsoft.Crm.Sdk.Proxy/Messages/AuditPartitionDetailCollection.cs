// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.AuditPartitionDetailCollection
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains a data collection of <see cref="T:Microsoft.Crm.Sdk.Messages.AuditDetail"></see> objects. </summary>
  [CollectionDataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AuditPartitionDetailCollection : DataCollection<AuditPartitionDetail>, IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Gets or sets whether the partition change list is a logical collection.</summary>
    /// <returns>Type: Returns_Booleantrue if the audit partition list is a logical collection; otherwise, false.</returns>
    [DataMember]
    public bool IsLogicalCollection { get; set; }

    /// <summary>ExtensionData</summary>
    /// <returns>Returns_String</returns>
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
