using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.IsValidStateTransitionRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class IsValidStateTransitionResponse : OrganizationResponse
  {
    /// <summary>Gets the value that indicates whether the state transition is valid.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether the state transition is valid.true if the state transition is valid; otherwise, false. </returns>
    public bool IsValid
    {
      get
      {
        return this.Results.Contains(nameof (IsValid)) && (bool) this.Results[nameof (IsValid)];
      }
    }
  }
}
