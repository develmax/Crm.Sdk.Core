using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to update the definition of an entity relationship. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class UpdateRelationshipRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the relationship metadata to be updated. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase"></see>The relationship metadata to be updated. Required..</returns>
    public RelationshipMetadataBase Relationship
    {
      get
      {
        return this.Parameters.Contains(nameof (Relationship)) ? (RelationshipMetadataBase) this.Parameters[nameof (Relationship)] : (RelationshipMetadataBase) null;
      }
      set
      {
        this.Parameters[nameof (Relationship)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether to merge the new labels with any existing labels. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the new labels will be merged with any existing labels; otherwise, false.</returns>
    public bool MergeLabels
    {
      get
      {
        return this.Parameters.Contains(nameof (MergeLabels)) && (bool) this.Parameters[nameof (MergeLabels)];
      }
      set
      {
        this.Parameters[nameof (MergeLabels)] = (object) value;
      }
    }

    /// <summary>Gets or sets the unique name of the unmanaged solution that this entity relationship should be associated with. Optional.</summary>
    /// <returns>Type: Returns_StringThe unique name of the unmanaged solution that this entity relationship should be associated with. Optional.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.UpdateRelationshipRequest"></see> class</summary>
    public UpdateRelationshipRequest()
    {
      this.RequestName = "UpdateRelationship";
      this.Relationship = (RelationshipMetadataBase) null;
      this.MergeLabels = false;
    }
  }
}
