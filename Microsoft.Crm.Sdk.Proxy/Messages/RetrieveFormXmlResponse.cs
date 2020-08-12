// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveFormXmlResponse
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveFormXmlResponse : OrganizationResponse
  {
    /// <summary>internal</summary>
    /// <returns>Type: Returns_Stringinternal</returns>
    public string FormXml
    {
      get
      {
        return this.Results.Contains(nameof (FormXml)) ? (string) this.Results[nameof (FormXml)] : (string) null;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_Int32internal</returns>
    public int CustomizationLevel
    {
      get
      {
        return this.Results.Contains(nameof (CustomizationLevel)) ? (int) this.Results[nameof (CustomizationLevel)] : 0;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_Int32internal</returns>
    public int ComponentState
    {
      get
      {
        return this.Results.Contains(nameof (ComponentState)) ? (int) this.Results[nameof (ComponentState)] : 0;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_Guidinternal</returns>
    public Guid SolutionId
    {
      get
      {
        return this.Results.Contains(nameof (SolutionId)) ? (Guid) this.Results[nameof (SolutionId)] : new Guid();
      }
    }
  }
}
