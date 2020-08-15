using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create a new One-to-Many (1:N) entity relationship.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateOneToManyRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the metadata for the lookup field used to store the ID of the related record. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.LookupAttributeMetadata"></see>The metadata for the lookup field used to store the ID of the related record. Required.</returns>
    public LookupAttributeMetadata Lookup
    {
      get
      {
        return this.Parameters.Contains(nameof (Lookup)) ? (LookupAttributeMetadata) this.Parameters[nameof (Lookup)] : (LookupAttributeMetadata) null;
      }
      set
      {
        this.Parameters[nameof (Lookup)] = (object) value;
      }
    }

    /// <summary>Gets or sets the metadata for the relationship. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.OneToManyRelationshipMetadata"></see>The metadata for the relationship. Required.</returns>
    public OneToManyRelationshipMetadata OneToManyRelationship
    {
      get
      {
        return this.Parameters.Contains(nameof (OneToManyRelationship)) ? (OneToManyRelationshipMetadata) this.Parameters[nameof (OneToManyRelationship)] : (OneToManyRelationshipMetadata) null;
      }
      set
      {
        this.Parameters[nameof (OneToManyRelationship)] = (object) value;
      }
    }

    /// <summary>Gets or sets the name of the unmanaged solution you want to add this one-to-Many entity relationship to. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of the unmanaged solution you want to add this one-to-Many entity relationship to. Optional..</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateOneToManyRequest"></see> class.</summary>
    public CreateOneToManyRequest()
    {
      this.RequestName = "CreateOneToMany";
      this.Lookup = (LookupAttributeMetadata) null;
      this.OneToManyRelationship = (OneToManyRelationshipMetadata) null;
    }
  }
}
