using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  reset the offline data filters for the calling user to the default filters for the organization.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ResetUserFiltersRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the type of filters to set. Required.</summary>
    /// <returns>Type: Returns_Int32The type of filters to set. Use, <see cref="F:Microsoft.Crm.Sdk.UserQueryQueryType.OfflineFilters"></see> or <see cref="F:Microsoft.Crm.Sdk.UserQueryQueryType.OutlookFilters"></see>.</returns>
    public int QueryType
    {
      get
      {
        return this.Parameters.Contains(nameof (QueryType)) ? (int) this.Parameters[nameof (QueryType)] : 0;
      }
      set
      {
        this.Parameters[nameof (QueryType)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ResetUserFiltersRequest"></see> class.</summary>
    public ResetUserFiltersRequest()
    {
      this.RequestName = "ResetUserFilters";
      this.QueryType = 0;
    }
  }
}
