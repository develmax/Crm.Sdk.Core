using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class BulkOperationStatusCloseRequest : OrganizationRequest
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
    /// <returns>Type: Returns_Int32</returns>
    public int StatusReason
    {
      get
      {
        return this.Parameters.Contains(nameof (StatusReason)) ? (int) this.Parameters[nameof (StatusReason)] : 0;
      }
      set
      {
        this.Parameters[nameof (StatusReason)] = (object) value;
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
    public BulkOperationStatusCloseRequest()
    {
      this.RequestName = "BulkOperationStatusClose";
      this.BulkOperationId = new Guid();
      this.FailureCount = 0;
      this.SuccessCount = 0;
      this.StatusReason = 0;
      this.ErrorCode = 0;
    }
  }
}
