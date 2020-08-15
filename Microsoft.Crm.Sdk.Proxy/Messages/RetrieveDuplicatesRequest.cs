using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  detect and retrieve duplicates for a specified record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveDuplicatesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets a record for which the duplicates are retrieved. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The record for which the duplicates are retrieved.</returns>
    public Entity BusinessEntity
    {
      get
      {
        return this.Parameters.Contains(nameof (BusinessEntity)) ? (Entity) this.Parameters[nameof (BusinessEntity)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (BusinessEntity)] = (object) value;
      }
    }

    /// <summary>Gets or sets a name of the matching entity type. Required.</summary>
    /// <returns>Type:  Returns_StringThe name of the matching entity type.</returns>
    public string MatchingEntityName
    {
      get
      {
        return this.Parameters.Contains(nameof (MatchingEntityName)) ? (string) this.Parameters[nameof (MatchingEntityName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (MatchingEntityName)] = (object) value;
      }
    }

    /// <summary>Gets or sets a paging information for the retrieved duplicates. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.PagingInfo"></see>The paging information for the retrieved duplicates.</returns>
    public PagingInfo PagingInfo
    {
      get
      {
        return this.Parameters.Contains(nameof (PagingInfo)) ? (PagingInfo) this.Parameters[nameof (PagingInfo)] : (PagingInfo) null;
      }
      set
      {
        this.Parameters[nameof (PagingInfo)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveDuplicatesRequest"></see> class.</summary>
    public RetrieveDuplicatesRequest()
    {
      this.RequestName = "RetrieveDuplicates";
      this.BusinessEntity = (Entity) null;
      this.MatchingEntityName = (string) null;
      this.PagingInfo = (PagingInfo) null;
    }
  }
}
