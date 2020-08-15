using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve a collection of unpublished organization-owned records that satisfy the specified query criteria.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveUnpublishedMultipleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the query criteria defining the records to retrieve.Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryBase"></see>The query criteria defining the records to retrieve.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveUnpublishedMultipleRequest"></see> class.</summary>
    public RetrieveUnpublishedMultipleRequest()
    {
      this.RequestName = "RetrieveUnpublishedMultiple";
      this.Query = (QueryBase) null;
    }
  }
}
