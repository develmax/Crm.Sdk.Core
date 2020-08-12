﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.CompoundCreateResponse
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateRequest"></see> class and its associated response class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CompoundCreateResponse : OrganizationResponse
  {
    /// <summary>deprecated</summary>
    /// <returns>Type: Returns_Guid</returns>
    public Guid Id
    {
      get
      {
        return this.Results.Contains(nameof (Id)) ? (Guid) this.Results[nameof (Id)] : new Guid();
      }
    }
  }
}
