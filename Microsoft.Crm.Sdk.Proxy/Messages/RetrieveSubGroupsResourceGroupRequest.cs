using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the collection of child resource groups from the specified resource group (scheduling group).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveSubGroupsResourceGroupRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the resource group.</summary>
    /// <returns>Type: Returns_GuidThe ID of the resource group. This corresponds to the ResourceGroup.ResourceGroupId property, which is the primary key for the ResourceGroup entity.</returns>
    public Guid ResourceGroupId
    {
      get
      {
        return this.Parameters.Contains(nameof (ResourceGroupId)) ? (Guid) this.Parameters[nameof (ResourceGroupId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ResourceGroupId)] = (object) value;
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveSubGroupsResourceGroupRequest"></see> class.</summary>
    public RetrieveSubGroupsResourceGroupRequest()
    {
      this.RequestName = "RetrieveSubGroupsResourceGroup";
      this.ResourceGroupId = new Guid();
      this.Query = (QueryBase) null;
    }
  }
}
