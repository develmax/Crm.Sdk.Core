// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.LogFailureBulkOperationRequest
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
  public sealed class LogFailureBulkOperationRequest : OrganizationRequest
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
    /// <returns>Type: Returns_Guid</returns>
    public Guid RegardingObjectId
    {
      get
      {
        return this.Parameters.Contains(nameof (RegardingObjectId)) ? (Guid) this.Parameters[nameof (RegardingObjectId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (RegardingObjectId)] = (object) value;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_Int32</returns>
    public int RegardingObjectTypeCode
    {
      get
      {
        return this.Parameters.Contains(nameof (RegardingObjectTypeCode)) ? (int) this.Parameters[nameof (RegardingObjectTypeCode)] : 0;
      }
      set
      {
        this.Parameters[nameof (RegardingObjectTypeCode)] = (object) value;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_Int32</returns>
    public int ErrorCode
    {
      get
      {
        return this.Parameters.Contains(nameof (ErrorCode)) ? (int) this.Parameters[nameof (ErrorCode)] : 0;
      }
      set
      {
        this.Parameters[nameof (ErrorCode)] = (object) value;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_String</returns>
    public string Message
    {
      get
      {
        return this.Parameters.Contains(nameof (Message)) ? (string) this.Parameters[nameof (Message)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (Message)] = (object) value;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_String</returns>
    public string AdditionalInfo
    {
      get
      {
        return this.Parameters.Contains(nameof (AdditionalInfo)) ? (string) this.Parameters[nameof (AdditionalInfo)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (AdditionalInfo)] = (object) value;
      }
    }

    /// <summary>internal</summary>
    public LogFailureBulkOperationRequest()
    {
      this.RequestName = "LogFailureBulkOperation";
      this.BulkOperationId = new Guid();
      this.RegardingObjectId = new Guid();
      this.RegardingObjectTypeCode = 0;
      this.ErrorCode = 0;
      this.Message = (string) null;
      this.AdditionalInfo = (string) null;
    }
  }
}
