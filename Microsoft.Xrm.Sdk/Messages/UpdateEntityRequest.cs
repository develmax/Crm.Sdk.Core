using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to update the definition of an entity.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class UpdateEntityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the metadata for the entity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.EntityMetadata"></see>the metadata for the entity. Required.</returns>
    public EntityMetadata Entity
    {
      get
      {
        return this.Parameters.Contains(nameof (Entity)) ? (EntityMetadata) this.Parameters[nameof (Entity)] : (EntityMetadata) null;
      }
      set
      {
        this.Parameters[nameof (Entity)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether to merge the new labels with any existing labels. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the new labels should be merged with any existing labels; otherwise, false.</returns>
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

    /// <summary>Gets or sets whether the entity will have a special relationship to the annotation entity. Optional.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity will have a special relationship to the annotation entity; otherwise, false.</returns>
    public bool? HasNotes
    {
      get
      {
        return this.Parameters.Contains(nameof (HasNotes)) ? (bool?) this.Parameters[nameof (HasNotes)] : new bool?();
      }
      set
      {
        this.Parameters[nameof (HasNotes)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether the entity will have a special relationship to activity entities and is a valid regarding object for the activity. Optional.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the entity will have a special relationship to activity entities and is a valid regarding object for the activity; otherwise, false.</returns>
    public bool? HasActivities
    {
      get
      {
        return this.Parameters.Contains(nameof (HasActivities)) ? (bool?) this.Parameters[nameof (HasActivities)] : new bool?();
      }
      set
      {
        this.Parameters[nameof (HasActivities)] = (object) value;
      }
    }

    /// <summary>Gets or sets the unique name of the unmanaged solution that this entity should be associated with. Optional.</summary>
    /// <returns>Type: Returns_StringThe unique name of the unmanaged solution that this entity should be associated with. Optional.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.UpdateEntityRequest"></see> class</summary>
    public UpdateEntityRequest()
    {
      this.RequestName = "UpdateEntity";
      this.Entity = (EntityMetadata) null;
      this.MergeLabels = false;
    }
  }
}
