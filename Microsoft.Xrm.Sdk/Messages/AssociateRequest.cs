using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create a link between records.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class AssociateRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target that is the record to which the related records are associated. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>
    /// The target that is the record to which the related records are associated.</returns>
    public EntityReference Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Get or sets the relationship name to be used for an association. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>The relationship name to be used for an association.</returns>
    public Relationship Relationship
    {
      get
      {
        return this.Parameters.Contains(nameof (Relationship)) ? (Relationship) this.Parameters[nameof (Relationship)] : (Relationship) null;
      }
      set
      {
        this.Parameters[nameof (Relationship)] = (object) value;
      }
    }

    /// <summary>Gets or sets the collection of entity references (references to records) to be associated. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see>
    /// The collection of entity references (references to records) to be associated.</returns>
    public EntityReferenceCollection RelatedEntities
    {
      get
      {
        return this.Parameters.Contains(nameof (RelatedEntities)) ? (EntityReferenceCollection) this.Parameters[nameof (RelatedEntities)] : (EntityReferenceCollection) null;
      }
      set
      {
        this.Parameters[nameof (RelatedEntities)] = (object) value;
      }
    }

    /// <summary> Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.AssociateRequest"></see> class.</summary>
    public AssociateRequest()
    {
      this.RequestName = "Associate";
      this.Target = (EntityReference) null;
      this.Relationship = (Relationship) null;
      this.RelatedEntities = (EntityReferenceCollection) null;
    }
  }
}
