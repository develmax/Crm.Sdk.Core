using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  export a data map as an XML formatted data.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExportMappingsImportMapRequest : OrganizationRequest
  {
    /// <summary> Gets or sets the ID of the import map (data map) to export. Required. </summary>
    /// <returns>Type: Returns_GuidThe ID of the import map (data map) to export. This corresponds to the ImportMap.ImportMapId attribute, which is the primary key for the ImportMap entity.</returns>
    public Guid ImportMapId
    {
      get
      {
        return this.Parameters.Contains(nameof (ImportMapId)) ? (Guid) this.Parameters[nameof (ImportMapId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ImportMapId)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether to export the entity record IDs contained in the data map. Required.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether to export the entity record IDs contained in the data map. true to export the record IDs, otherwise, false.</returns>
    public bool ExportIds
    {
      get
      {
        return this.Parameters.Contains(nameof (ExportIds)) && (bool) this.Parameters[nameof (ExportIds)];
      }
      set
      {
        this.Parameters[nameof (ExportIds)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ExportMappingsImportMapRequest"></see> class.</summary>
    public ExportMappingsImportMapRequest()
    {
      this.RequestName = "ExportMappingsImportMap";
      this.ImportMapId = new Guid();
    }
  }
}
