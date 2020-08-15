using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve a global option set. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveOptionSetRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name for the global option set to be retrieved. Optional.</summary>
    /// <returns>Type: Returns_String The name for the global option set to be retrieved.. Optional..</returns>
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

    /// <summary>Gets or sets the <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata"></see> to be retrieved. Optional.</summary>
    /// <returns>Type: Returns_GuidThe <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata"></see> to be retrieved. Optional.</returns>
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

    /// <summary>Gets or sets whether to retrieve the metadata that has not been published. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the the unpublished metadata should be retrieved; otherwise, false..</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveOptionSetRequest"></see> class</summary>
    public RetrieveOptionSetRequest()
    {
      this.RequestName = "RetrieveOptionSet";
      this.MetadataId = new Guid();
      this.RetrieveAsIfPublished = false;
    }
  }
}
