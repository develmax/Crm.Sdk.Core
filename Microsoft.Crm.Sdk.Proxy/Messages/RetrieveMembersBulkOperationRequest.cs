using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the members of a bulk operation.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveMembersBulkOperationRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the bulk operation. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the bulk operation. This corresponds to the BulkOperation.BulkOperationId attribute, which is the primary key for the BulkOperation entity.</returns>
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

    /// <summary>Gets or sets the source for a bulk operation. Required.</summary>
    /// <returns>Type:Returns_Int32The source for a bulk operation.  The return value for this property is a <see cref="T:Microsoft.Crm.Sdk.Messages.BulkOperationSource"></see> enumeration type.</returns>
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

    /// <summary>Gets or sets which  members of a bulk operation to retrieve. Required.</summary>
    /// <returns>Type: Returns_Int32Describes which members of a bulk operation to retrieve. The return value for this property is an <see cref="T:Microsoft.Crm.Sdk.Messages.EntitySource"></see> type.</returns>
    public int EntitySource
    {
      get
      {
        return this.Parameters.Contains(nameof (EntitySource)) ? (int) this.Parameters[nameof (EntitySource)] : 0;
      }
      set
      {
        this.Parameters[nameof (EntitySource)] = (object) value;
      }
    }

    /// <summary>Gets or sets the query for the retrieve operation that can be used to break up large data sets into pages. Optional.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryBase"></see>The query for the retrieve operation that can be used to break up large data sets into pages.</returns>
    public QueryBase Query
    {
      get
      {
        return this.Parameters.Contains(nameof (Query)) ? (QueryBase) this.Parameters[nameof (Query)] : (QueryBase) null;
      }
      set
      {
        this.Parameters[nameof (Query)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveMembersBulkOperationRequest"></see> class.</summary>
    public RetrieveMembersBulkOperationRequest()
    {
      this.RequestName = "RetrieveMembersBulkOperation";
      this.BulkOperationId = new Guid();
      this.BulkOperationSource = 0;
      this.EntitySource = 0;
      this.Query = (QueryBase) null;
    }
  }
}
