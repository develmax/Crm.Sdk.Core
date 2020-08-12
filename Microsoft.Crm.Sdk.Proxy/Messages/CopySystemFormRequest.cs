﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.CopySystemFormRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to create a new entity form that is based on an existing entity form.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CopySystemFormRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the SystemForm that the original system form should be copied to. Optional.</summary>
    /// <returns>Returns <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>.</returns>
    public Entity Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (Entity) this.Parameters[nameof (Target)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID value of the form to copy. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID value of the form to copy. Required. This corresponds to the SystemForm. FormId attribute, which is the primary key for the SystemForm entity.</returns>
    public Guid SourceId
    {
      get
      {
        return this.Parameters.Contains(nameof (SourceId)) ? (Guid) this.Parameters[nameof (SourceId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (SourceId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the CopySystemFormRequest class</summary>
    public CopySystemFormRequest()
    {
      this.RequestName = "CopySystemForm";
      this.SourceId = new Guid();
    }
  }
}
