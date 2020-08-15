using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class IsBackOfficeInstalledResponse : OrganizationResponse
  {
    /// <summary>deprecated</summary>
    /// <returns>Type: Returns_Boolean</returns>
    public bool IsInstalled
    {
      get
      {
        return this.Results.Contains(nameof (IsInstalled)) && (bool) this.Results[nameof (IsInstalled)];
      }
    }
  }
}
