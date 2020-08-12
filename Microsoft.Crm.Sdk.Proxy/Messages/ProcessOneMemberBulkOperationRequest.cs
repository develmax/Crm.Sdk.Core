// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ProcessOneMemberBulkOperationRequest
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
  public sealed class ProcessOneMemberBulkOperationRequest : OrganizationRequest
  {
    /// <summary>internal</summary>
    /// <returns>Type: Returns_Guid</returns>
    public Guid BulkOperationId
    {
      get
      {
        return this.Parameters.Contains(nameof (BulkOperationId)) ? (Guid) this.Parameters[nameof (BulkOperationId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (BulkOperationId)] = (object) value;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see></returns>
    public Entity Entity
    {
      get
      {
        return this.Parameters.Contains(nameof (Entity)) ? (Entity) this.Parameters[nameof (Entity)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Entity)] = (object) value;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_Int32</returns>
    public int BulkOperationSource
    {
      get
      {
        return this.Parameters.Contains(nameof (BulkOperationSource)) ? (int) this.Parameters[nameof (BulkOperationSource)] : 0;
      }
      set
      {
        this.Parameters[nameof (BulkOperationSource)] = (object) value;
      }
    }

    /// <summary>internal</summary>
    public ProcessOneMemberBulkOperationRequest()
    {
      this.RequestName = "ProcessOneMemberBulkOperation";
      this.BulkOperationId = new Guid();
      this.Entity = (Entity) null;
      this.BulkOperationSource = 0;
    }
  }
}
