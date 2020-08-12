﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.AutoMapEntityRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to generate a new set of attribute mappings based on the metadata.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AutoMapEntityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the entity map to overwrite when the automated mapping is performed. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the entity map.</returns>
    public Guid EntityMapId
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityMapId)) ? (Guid) this.Parameters[nameof (EntityMapId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (EntityMapId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AutoMapEntityRequest"></see> class.</summary>
    public AutoMapEntityRequest()
    {
      this.RequestName = "AutoMapEntity";
      this.EntityMapId = new Guid();
    }
  }
}
