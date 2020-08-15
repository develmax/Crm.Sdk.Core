using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve metadata information about all the entities.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAllEntitiesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets a filter to control how much data for each entity is retrieved. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.EntityFilters"></see>A filter to control how much data for each entity is retrieved. Required.</returns>
    public EntityFilters EntityFilters
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityFilters)) ? (EntityFilters) this.Parameters[nameof (EntityFilters)] : (EntityFilters) 0;
      }
      set
      {
        this.Parameters[nameof (EntityFilters)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether to retrieve the metadata that has not been published. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the metadata that has not been published should be retrieved; otherwise, false.</returns>
    public bool RetrieveAsIfPublished
    {
      get
      {
        return this.Parameters.Contains(nameof (RetrieveAsIfPublished)) && (bool) this.Parameters[nameof (RetrieveAsIfPublished)];
      }
      set
      {
        this.Parameters[nameof (RetrieveAsIfPublished)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveAllEntitiesRequest"></see> class</summary>
    public RetrieveAllEntitiesRequest()
    {
      this.RequestName = "RetrieveAllEntities";
      this.EntityFilters = (EntityFilters) 0;
      this.RetrieveAsIfPublished = false;
    }
  }
}
