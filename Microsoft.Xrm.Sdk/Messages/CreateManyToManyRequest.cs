using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create a new Many-to-Many (N:N) entity relationship.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateManyToManyRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the intersect entity to be created for this entity relationship. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the intersect entity to be created for this entity relationship. Required.</returns>
    public string IntersectEntitySchemaName
    {
      get
      {
        return this.Parameters.Contains(nameof (IntersectEntitySchemaName)) ? (string) this.Parameters[nameof (IntersectEntitySchemaName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (IntersectEntitySchemaName)] = (object) value;
      }
    }

    /// <summary>Gets or sets the definition of the Many-to-Many entity relationship to be created. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.ManyToManyRelationshipMetadata"></see>The definition of the Many-to-Many entity relationship to be created. Required.</returns>
    public ManyToManyRelationshipMetadata ManyToManyRelationship
    {
      get
      {
        return this.Parameters.Contains(nameof (ManyToManyRelationship)) ? (ManyToManyRelationshipMetadata) this.Parameters[nameof (ManyToManyRelationship)] : (ManyToManyRelationshipMetadata) null;
      }
      set
      {
        this.Parameters[nameof (ManyToManyRelationship)] = (object) value;
      }
    }

    /// <summary>Gets or sets the name of the unmanaged solution you want to add this many-to-many entity relationship to. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of the unmanaged solution you want to add this many-to-many entity relationship to. Optional.</returns>
    public string SolutionUniqueName
    {
      get
      {
        return this.Parameters.Contains(nameof (SolutionUniqueName)) ? (string) this.Parameters[nameof (SolutionUniqueName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (SolutionUniqueName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateManyToManyRequest"></see> class.</summary>
    public CreateManyToManyRequest()
    {
      this.RequestName = "CreateManyToMany";
      this.IntersectEntitySchemaName = (string) null;
      this.ManyToManyRelationship = (ManyToManyRelationshipMetadata) null;
    }
  }
}
