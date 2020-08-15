using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve all the entity records that are related to the specified record. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RollupRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target record for the rollup operation. Required.</summary>
    /// <returns>Type <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target record for the rollup operation, which must be an entity reference for an account, contact, or opportunity entity.</returns>
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

    /// <summary>Gets or sets the query criteria for the rollup operation. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryBase"></see>The query criteria for the rollup operation.</returns>
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

    /// <summary>Gets or sets the rollup type. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.RollupType"></see>The the rollup type. Use the <see cref="T:Microsoft.Crm.Sdk.Messages.RollupType"></see> enumeration for this property.</returns>
    public RollupType RollupType
    {
      get
      {
        return this.Parameters.Contains(nameof (RollupType)) ? (RollupType) this.Parameters[nameof (RollupType)] : RollupType.None;
      }
      set
      {
        this.Parameters[nameof (RollupType)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RollupRequest"></see> class.</summary>
    public RollupRequest()
    {
      this.RequestName = "Rollup";
      this.Target = (EntityReference) null;
      this.Query = (QueryBase) null;
      this.RollupType = RollupType.None;
    }
  }
}
