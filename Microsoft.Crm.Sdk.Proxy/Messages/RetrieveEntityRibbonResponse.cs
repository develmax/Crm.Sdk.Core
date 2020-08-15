using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveEntityRibbonRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveEntityRibbonResponse : OrganizationResponse
  {
    /// <summary>Gets a compressed file that contains the ribbon definitions.</summary>
    /// <returns>Type: Returns_Byte[]A compressed file that contains the ribbon definitions..</returns>
    public byte[] CompressedEntityXml
    {
      get
      {
        return this.Results.Contains(nameof (CompressedEntityXml)) ? (byte[]) this.Results[nameof (CompressedEntityXml)] : (byte[]) null;
      }
    }
  }
}
