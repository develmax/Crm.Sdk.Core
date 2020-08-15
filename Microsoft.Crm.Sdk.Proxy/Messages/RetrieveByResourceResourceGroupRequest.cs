using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the resource groups (scheduling groups) that contain the specified resource.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveByResourceResourceGroupRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the resource.</summary>
    /// <returns>Type: Returns_GuidThe ID of the resource. This corresponds to the Resource.ResourceId property, which is the primary key for the Resource entity.</returns>
    public Guid ResourceId
    {
      get
      {
        return this.Parameters.Contains(nameof (ResourceId)) ? (Guid) this.Parameters[nameof (ResourceId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ResourceId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the query for the operation.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryBase"></see>The query for the operation.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveByResourceResourceGroupRequest"></see> class.</summary>
    public RetrieveByResourceResourceGroupRequest()
    {
      this.RequestName = "RetrieveByResourceResourceGroup";
      this.ResourceId = new Guid();
      this.Query = (QueryBase) null;
    }
  }
}
