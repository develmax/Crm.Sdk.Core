// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.PrincipalAccess
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains access rights information for the security principal (user or team).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class PrincipalAccess : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Gets or sets the security principal (user or team).</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The security principal (user or team).</returns>
    [DataMember]
    public EntityReference Principal { get; set; }

    /// <summary>Gets or sets the access rights of the security principal (user or team).</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.AccessRights"></see>The access rights of the security principal (user or team).</returns>
    [DataMember]
    public AccessRights AccessMask { get; set; }

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
