using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve attribute metadata. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAttributeRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the logical name of the entity that contains the attribute. Optional.</summary>
    /// <returns>Type: Returns_StringThe logical name of the entity that contains the attribute. Optional.</returns>
    public string EntityLogicalName
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityLogicalName)) ? (string) this.Parameters[nameof (EntityLogicalName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (EntityLogicalName)] = (object) value;
      }
    }

    /// <summary>Gets or sets the logical name of the attribute to be retrieved. Optional.</summary>
    /// <returns>Type: Returns_StringThe logical name of the attribute to be retrieved. Optional.</returns>
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

    /// <summary>Gets or sets a column number value to identify an attribute from the Audit.AttributeMask property. Optional.</summary>
    /// <returns>Type: Returns_Int32A column number value to identify an attribute from the Audit.AttributeMask property. Optional.</returns>
    public int ColumnNumber
    {
      get
      {
        return this.Parameters.Contains(nameof (ColumnNumber)) ? (int) this.Parameters[nameof (ColumnNumber)] : 0;
      }
      set
      {
        this.Parameters[nameof (ColumnNumber)] = (object) value;
      }
    }

    /// <summary>The unique identifier for the attribute. Optional.</summary>
    /// <returns>Type: Returns_GuidThe unique identifier for the attribute. This corresponds to the <see cref="T:Microsoft.Xrm.Sdk.Metadata.MetadataBase"></see>.<see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see>.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveAttributeRequest"></see> class</summary>
    public RetrieveAttributeRequest()
    {
      this.RequestName = "RetrieveAttribute";
      this.MetadataId = new Guid();
      this.RetrieveAsIfPublished = false;
    }
  }
}
