using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.IsComponentCustomizableRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class IsComponentCustomizableResponse : OrganizationResponse
  {
    /// <summary>Gets the value that indicates whether a solution component is customizable.</summary>
    /// <returns>Type: Returns_Booleanthe value that indicates whether a solution component is customizable.</returns>
    public bool IsComponentCustomizable
    {
      get
      {
        return this.Results.Contains(nameof (IsComponentCustomizable)) && (bool) this.Results[nameof (IsComponentCustomizable)];
      }
    }
  }
}
