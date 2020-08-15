using Microsoft.Xrm.Sdk.Metadata.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  to retrieve a collection of metadata records that satisfy the specified criteria. The <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveMetadataChangesResponse"></see> returns a timestamp value that can be used with this request at a later time to return information about how metadata has changed since the last request.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveMetadataChangesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the query representing the metadata to return.</summary>
    /// <returns>Type:<see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.EntityQueryExpression"></see>The query representing the metadata to return.</returns>
    public EntityQueryExpression Query
    {
      get
      {
        return this.Parameters.Contains(nameof (Query)) ? (EntityQueryExpression) this.Parameters[nameof (Query)] : (EntityQueryExpression) null;
      }
      set
      {
        this.Parameters[nameof (Query)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value to filter what deleted metadata items will be returned.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.DeletedMetadataFilters"></see>A value to filter what deleted metadata items will be returned.</returns>
    public DeletedMetadataFilters DeletedMetadataFilters
    {
      get
      {
        return this.Parameters.Contains(nameof (DeletedMetadataFilters)) ? (DeletedMetadataFilters) this.Parameters[nameof (DeletedMetadataFilters)] : (DeletedMetadataFilters) 0;
      }
      set
      {
        this.Parameters[nameof (DeletedMetadataFilters)] = (object) value;
      }
    }

    /// <summary>Gets or sets a timestamp value representing when the last request was made.</summary>
    /// <returns>Type: Returns_String
    /// A timestamp value representing when the last request was made.</returns>
    public string ClientVersionStamp
    {
      get
      {
        return this.Parameters.Contains(nameof (ClientVersionStamp)) ? (string) this.Parameters[nameof (ClientVersionStamp)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (ClientVersionStamp)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveMetadataChangesRequest"></see> class.</summary>
    public RetrieveMetadataChangesRequest()
    {
      this.RequestName = "RetrieveMetadataChanges";
    }
  }
}
