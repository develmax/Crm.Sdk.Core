using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.ExportMappingsImportMapRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExportMappingsImportMapResponse : OrganizationResponse
  {
    /// <summary>Gets the XML representation of the exported data map.</summary>
    /// <returns>Type: Returns_StringThe XML representation of the exported data map.</returns>
    public string MappingsXml
    {
      get
      {
        return this.Results.Contains(nameof (MappingsXml)) ? (string) this.Results[nameof (MappingsXml)] : (string) null;
      }
    }
  }
}
