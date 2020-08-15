using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveApplicationRibbonRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveApplicationRibbonResponse : OrganizationResponse
  {
    /// <summary>Gets a compressed file that defines the ribbon.</summary>
    /// <returns>Type: Returns_Byte[]a compressed file that defines the ribbon.</returns>
    public byte[] CompressedApplicationRibbonXml
    {
      get
      {
        return this.Results.Contains(nameof (CompressedApplicationRibbonXml)) ? (byte[]) this.Results[nameof (CompressedApplicationRibbonXml)] : (byte[]) null;
      }
    }
  }
}
