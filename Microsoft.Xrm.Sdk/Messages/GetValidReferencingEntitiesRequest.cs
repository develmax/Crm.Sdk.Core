using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the set of entities that are valid as the related entity (many) to the specified entity in a one-to-many relationship.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class GetValidReferencingEntitiesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the entity that would be the primary entity in the relationship. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of the entity that would be the primary entity in the relationship. Optional.</returns>
    public string ReferencedEntityName
    {
      get
      {
        return this.Parameters.Contains(nameof (ReferencedEntityName)) ? (string) this.Parameters[nameof (ReferencedEntityName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (ReferencedEntityName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.GetValidReferencingEntitiesRequest"></see> class</summary>
    public GetValidReferencingEntitiesRequest()
    {
      this.RequestName = "GetValidReferencingEntities";
    }
  }
}
