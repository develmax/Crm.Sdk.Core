﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.CopyDynamicListToStaticRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create a static list from the specified dynamic list and add the members that satisfy the dynamic list query criteria to the static list.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CopyDynamicListToStaticRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the dynamic list. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the dynamic list that corresponds to the List.ListId attribute, which is the primary key for the List entity.</returns>
    public Guid ListId
    {
      get
      {
        return this.Parameters.Contains(nameof (ListId)) ? (Guid) this.Parameters[nameof (ListId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ListId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CopyDynamicListToStaticRequest"></see> class.</summary>
    public CopyDynamicListToStaticRequest()
    {
      this.RequestName = "CopyDynamicListToStatic";
      this.ListId = new Guid();
    }
  }
}
