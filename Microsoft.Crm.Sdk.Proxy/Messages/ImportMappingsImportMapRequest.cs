// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ImportMappingsImportMapRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  import the XML representation of a data map and create an import map (data map) based on this data.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ImportMappingsImportMapRequest : OrganizationRequest
  {
    /// <summary>Gets or sets an XML representation of the data map. Required.</summary>
    /// <returns>Type: Returns_StringThe XML representation of the data map.</returns>
    public string MappingsXml
    {
      get
      {
        return this.Parameters.Contains(nameof (MappingsXml)) ? (string) this.Parameters[nameof (MappingsXml)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (MappingsXml)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether to import the entity record IDs contained in the XML representation of the data map. Required. </summary>
    /// <returns>Type: Returns_BooleanIndicates whether to import the entity record IDs contained in the XML representation of the data map. false to import the entity record IDs, otherwise, true. The imported record IDs are used as primary keys for the entity records created in pn_microsoftcrm.</returns>
    public bool ReplaceIds
    {
      get
      {
        return this.Parameters.Contains(nameof (ReplaceIds)) && (bool) this.Parameters[nameof (ReplaceIds)];
      }
      set
      {
        this.Parameters[nameof (ReplaceIds)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ImportMappingsImportMapRequest"></see> class.</summary>
    public ImportMappingsImportMapRequest()
    {
      this.RequestName = "ImportMappingsImportMap";
      this.MappingsXml = (string) null;
      this.ReplaceIds = false;
    }
  }
}
