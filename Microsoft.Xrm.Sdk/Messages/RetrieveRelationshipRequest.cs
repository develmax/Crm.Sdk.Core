using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve entity relationship metadata. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveRelationshipRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase"></see> to be retrieved. Optional.</summary>
    /// <returns>Type: Returns_Guid The <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase"></see> to be retrieved. Optional.</returns>
    public Guid MetadataId
    {
      get
      {
        return this.Parameters.Contains(nameof (MetadataId)) ? (Guid) this.Parameters[nameof (MetadataId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (MetadataId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the unique name for the entity relationship to be retrieved. Optional.</summary>
    /// <returns>Type: Returns_StringThe unique name for the entity relationship to be retrieved. Optional..</returns>
    public string Name
    {
      get
      {
        return this.Parameters.Contains(nameof (Name)) ? (string) this.Parameters[nameof (Name)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (Name)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether to retrieve the metadata that has not been published. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the unpublished metadata should be retrieved; otherwise, false.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveRelationshipRequest"></see> class</summary>
    public RetrieveRelationshipRequest()
    {
      this.RequestName = "RetrieveRelationship";
      this.MetadataId = new Guid();
      this.RetrieveAsIfPublished = false;
    }
  }
}
