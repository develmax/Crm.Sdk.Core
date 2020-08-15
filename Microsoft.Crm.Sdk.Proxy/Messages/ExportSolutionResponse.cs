using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.ExportSolutionRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExportSolutionResponse : OrganizationResponse
  {
    /// <summary>Gets the compressed file that represents the exported solution.</summary>
    /// <returns>Type: Returns_Byte[] The compressed file that represents the exported solution.</returns>
    public byte[] ExportSolutionFile
    {
      get
      {
        return this.Results.Contains(nameof (ExportSolutionFile)) ? (byte[]) this.Results[nameof (ExportSolutionFile)] : (byte[]) null;
      }
    }
  }
}
