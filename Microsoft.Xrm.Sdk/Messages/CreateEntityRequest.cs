using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create a custom entity, and optionally, to add it to a specified unmanaged solution.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateEntityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the metadata for the custom entity that you want to create. Required.</summary>
    /// <returns>Type <see cref="T:Microsoft.Xrm.Sdk.Metadata.EntityMetadata"></see>The metadata for the custom entity that you want to create. Required.</returns>
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

    /// <summary>Gets or sets whether a custom entity is created that has a special relationship to activity entities and is a valid regarding object for the activity. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the custom entity that you create has a special relationship to activity entities; otherwise, false. The default is false.</returns>
    public bool HasActivities
    {
      get
      {
        return this.Parameters.Contains(nameof (HasActivities)) && (bool) this.Parameters[nameof (HasActivities)];
      }
      set
      {
        this.Parameters[nameof (HasActivities)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether the custom entity that is created has a special relationship to the annotation entity. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the custom entity that is created has a special relationship to the annotation entity; otherwise, false. The default is false.</returns>
    public bool HasNotes
    {
      get
      {
        return this.Parameters.Contains(nameof (HasNotes)) && (bool) this.Parameters[nameof (HasNotes)];
      }
      set
      {
        this.Parameters[nameof (HasNotes)] = (object) value;
      }
    }

    /// <summary>Gets or sets the metadata for the primary attribute for the new entity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see>The metadata for the primary attribute for the new entity. Required..</returns>
    public StringAttributeMetadata PrimaryAttribute
    {
      get
      {
        return this.Parameters.Contains(nameof (PrimaryAttribute)) ? (StringAttributeMetadata) this.Parameters[nameof (PrimaryAttribute)] : (StringAttributeMetadata) null;
      }
      set
      {
        this.Parameters[nameof (PrimaryAttribute)] = (object) value;
      }
    }

    /// <summary>Gets or sets the name of the unmanaged solution to which you want to add this custom entity. Optional.</summary>
    /// <returns>Type: Returns_String
    /// The name of the unmanaged solution to which you want to add this custom entity. Optional.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateEntityRequest"></see> class.</summary>
    public CreateEntityRequest()
    {
      this.RequestName = "CreateEntity";
      this.Entity = (EntityMetadata) null;
      this.HasActivities = false;
      this.HasNotes = false;
      this.PrimaryAttribute = (StringAttributeMetadata) null;
    }
  }
}
