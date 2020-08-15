using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CleanUpBulkOperationRequest : OrganizationRequest
  {
    /// <summary>internal</summary>
    /// <returns>Type: Returns_Guid.</returns>
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
    /// <returns>Type: Returns_Int32.</returns>
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
    public CleanUpBulkOperationRequest()
    {
      this.RequestName = "CleanUpBulkOperation";
      this.BulkOperationId = new Guid();
      this.BulkOperationSource = 0;
    }
  }
}
