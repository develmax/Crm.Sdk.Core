// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.SetParentBusinessUnitRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  set the parent business unit for a business unit. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SetParentBusinessUnitRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the business unit.</summary>
    /// <returns>Returns <see cref="T:System.Guid"></see>.</returns>
    public Guid BusinessUnitId
    {
      get
      {
        return this.Parameters.Contains(nameof (BusinessUnitId)) ? (Guid) this.Parameters[nameof (BusinessUnitId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (BusinessUnitId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the new parent business unit.</summary>
    /// <returns>Returns <see cref="T:System.Guid"></see>.</returns>
    public Guid ParentId
    {
      get
      {
        return this.Parameters.Contains(nameof (ParentId)) ? (Guid) this.Parameters[nameof (ParentId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ParentId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  SetParentBusinessUnitRequest class.</summary>
    public SetParentBusinessUnitRequest()
    {
      this.RequestName = "SetParentBusinessUnit";
      this.BusinessUnitId = new Guid();
      this.ParentId = new Guid();
    }
  }
}
