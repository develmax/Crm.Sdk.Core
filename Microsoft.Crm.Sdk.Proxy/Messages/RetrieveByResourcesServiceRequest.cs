using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the collection of services that are related to the specified set of resources.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveByResourcesServiceRequest : OrganizationRequest
  {
    /// <summary>Gets or sets an array of IDs for the specified set of services.</summary>
    /// <returns>Type:  Returns_Guid[]The array of IDs for the specified set of services. Each element of the ResourceIds array corresponds to the Resource.ResourceId property, which is the primary key for the Resource entity.</returns>
    public Guid[] ResourceIds
    {
      get
      {
        return this.Parameters.Contains(nameof (ResourceIds)) ? (Guid[]) this.Parameters[nameof (ResourceIds)] : (Guid[]) null;
      }
      set
      {
        this.Parameters[nameof (ResourceIds)] = (object) value;
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveByResourcesServiceRequest"></see> class.</summary>
    public RetrieveByResourcesServiceRequest()
    {
      this.RequestName = "RetrieveByResourcesService";
      this.ResourceIds = (Guid[]) null;
      this.Query = (QueryBase) null;
    }
  }
}
