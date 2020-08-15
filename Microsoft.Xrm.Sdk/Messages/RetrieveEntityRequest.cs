using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve entity metadata. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveEntityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets a filter to control how much data for the entity is retrieved. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.EntityFilters"></see>a filter to control how much data for the entity is retrieved. Required.</returns>
    public EntityFilters EntityFilters
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityFilters)) ? (EntityFilters) this.Parameters[nameof (EntityFilters)] : (EntityFilters) 0;
      }
      set
      {
        this.Parameters[nameof (EntityFilters)] = (object) value;
      }
    }

    /// <summary>Gets or sets the logical name of the entity to be retrieved. Optional.</summary>
    /// <returns>Type: Returns_StringThe logical name of the entity to be retrieved. Optional.</returns>
    public string LogicalName
    {
      get
      {
        return this.Parameters.Contains(nameof (LogicalName)) ? (string) this.Parameters[nameof (LogicalName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (LogicalName)] = (object) value;
      }
    }

    /// <summary>A unique identifier for the entity. Optional.</summary>
    /// <returns>Type: Returns_GuidThe A unique identifier for the entity. This corresponds to the <see cref="T:Microsoft.Xrm.Sdk.Metadata.MetadataBase"></see>. <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> for the entity.</returns>
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
    /// <returns>Type: Returns_Booleantrue if the metadata that has not been published should be retrieved; otherwise, false.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveEntityRequest"></see> class.</summary>
    public RetrieveEntityRequest()
    {
      this.RequestName = "RetrieveEntity";
      this.EntityFilters = (EntityFilters) 0;
      this.MetadataId = new Guid();
      this.RetrieveAsIfPublished = false;
    }
  }
}
