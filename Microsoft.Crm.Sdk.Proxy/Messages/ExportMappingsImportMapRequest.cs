// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ExportMappingsImportMapRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

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
