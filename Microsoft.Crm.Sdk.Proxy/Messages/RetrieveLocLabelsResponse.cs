﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveLocLabelsResponse
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveLocLabelsRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveLocLabelsResponse : OrganizationResponse
  {
    /// <summary>Gets the label for the requested entity attribute.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The label for the requested entity attribute.</returns>
    public Label Label
    {
      get
      {
        return this.Results.Contains(nameof (Label)) ? (Label) this.Results[nameof (Label)] : (Label) null;
      }
    }
  }
}
