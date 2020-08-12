// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RequiredResource
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Specifies a resource that is required for a scheduling operation.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RequiredResource : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RequiredResource"></see> class.</summary>
    public RequiredResource()
    {
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RequiredResource"></see> class setting the resource and resource specification IDs.</summary>
    /// <param name="resourceSpecId">Type: Returns_Guid. The ID of the required resource specification.</param>
    /// <param name="resourceId">Type: Returns_Guid. The ID of the required resource.</param>
    public RequiredResource(Guid resourceId, Guid resourceSpecId)
    {
      this.ResourceId = resourceId;
      this.ResourceSpecId = resourceSpecId;
    }

    /// <summary>Gets or sets the ID of the required resource.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the required resource. This corresponds to the Resource.ResourceId attribute, which is the primary key for the Resource entity.</returns>
    [DataMember]
    public Guid ResourceId { get; set; }

    /// <summary>Gets or sets the ID of the required resource specification.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the required resource specification. This corresponds to the ResourceSpec.ResourceSpecId attribute, which is the primary key for the ResourceSpec entity.</returns>
    [DataMember]
    public Guid ResourceSpecId { get; set; }

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
