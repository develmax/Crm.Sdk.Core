using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.VerifyProcessStateDataRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class VerifyProcessStateDataResponse : OrganizationResponse
  {
    /// <returns>Type: Returns_Boolean</returns>
    public bool IsValid
    {
      get
      {
        return this.Results.Contains(nameof (IsValid)) && (bool) this.Results[nameof (IsValid)];
      }
    }
  }
}
