using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve a record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target, which is the record to be retrieved. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target, which is the record to be retrieved.</returns>
    public EntityReference Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Gets or sets the collection of attributes for which non-null values are returned from a query. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>The collection of attributes for which non-null values are returned from a query.</returns>
    public ColumnSet ColumnSet
    {
      get
      {
        return this.Parameters.Contains(nameof (ColumnSet)) ? (ColumnSet) this.Parameters[nameof (ColumnSet)] : (ColumnSet) null;
      }
      set
      {
        this.Parameters[nameof (ColumnSet)] = (object) value;
      }
    }

    /// <summary>Gets or sets the query that describes the related records to be retrieved. Optional.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.RelationshipQueryCollection"></see>The query that describes the related records to be retrieved.</returns>
    public RelationshipQueryCollection RelatedEntitiesQuery
    {
      get
      {
        return this.Parameters.Contains(nameof (RelatedEntitiesQuery)) ? (RelationshipQueryCollection) this.Parameters[nameof (RelatedEntitiesQuery)] : (RelationshipQueryCollection) null;
      }
      set
      {
        this.Parameters[nameof (RelatedEntitiesQuery)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveRequest"></see> class.</summary>
    public RetrieveRequest()
    {
      this.RequestName = "Retrieve";
      this.Target = (EntityReference) null;
      this.ColumnSet = (ColumnSet) null;
    }
  }
}
