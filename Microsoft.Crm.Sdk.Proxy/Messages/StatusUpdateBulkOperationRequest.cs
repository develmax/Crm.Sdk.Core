// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.StatusUpdateBulkOperationRequest
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
  public sealed class StatusUpdateBulkOperationRequest : OrganizationRequest
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
    /// <returns>Type: Returns_Int32</returns>
    public int FailureCount
    {
      get
      {
        return this.Parameters.Contains(nameof (FailureCount)) ? (int) this.Parameters[nameof (FailureCount)] : 0;
      }
      set
      {
        this.Parameters[nameof (FailureCount)] = (object) value;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_Int32</returns>
    public int SuccessCount
    {
      get
      {
        return this.Parameters.Contains(nameof (SuccessCount)) ? (int) this.Parameters[nameof (SuccessCount)] : 0;
      }
      set
      {
        this.Parameters[nameof (SuccessCount)] = (object) value;
      }
    }

    /// <summary>internal</summary>
    public StatusUpdateBulkOperationRequest()
    {
      this.RequestName = "StatusUpdateBulkOperation";
      this.BulkOperationId = new Guid();
      this.FailureCount = 0;
      this.SuccessCount = 0;
    }
  }
}
