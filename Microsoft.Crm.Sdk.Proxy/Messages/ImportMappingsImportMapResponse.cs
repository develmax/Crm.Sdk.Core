using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.ImportMappingsImportMapRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ImportMappingsImportMapResponse : OrganizationResponse
  {
    /// <summary> Gets the ID of the newly created import map (data map).</summary>
    /// <returns>Type: Returns_GuidThe ID of the newly created import map (data map). This corresponds to the ImportMap.ImportMapId attribute, which is the primary key for the ImportMap entity.</returns>
    public Guid ImportMapId
    {
      get
      {
        return this.Results.Contains(nameof (ImportMapId)) ? (Guid) this.Results[nameof (ImportMapId)] : new Guid();
      }
    }
  }
}
