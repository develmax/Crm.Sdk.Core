using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  delete a link between records.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class DisassociateRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target, which is the record from which the related records will be disassociated. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>
    /// The target, which is the record from which the related records will be disassociated.</returns>
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

    /// <summary>Get or sets the name of the relationship to be used for the disassociation. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>
    /// The name of the relationship to be used for the disassociation.</returns>
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

    /// <summary>Gets or sets the collection of entity references (references to records) to be disassociated. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see>
    /// The collection of entity references (references to records) to be disassociated.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.DisassociateRequest"></see> class.</summary>
    public DisassociateRequest()
    {
      this.RequestName = "Disassociate";
      this.Target = (EntityReference) null;
      this.Relationship = (Relationship) null;
      this.RelatedEntities = (EntityReferenceCollection) null;
    }
  }
}
