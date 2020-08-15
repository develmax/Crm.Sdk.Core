using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.CheckPromoteEmailRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CheckPromoteEmailResponse : OrganizationResponse
  {
    /// <summary>Gets a value that indicates whether the message should be promoted to pn_microsoftcrm.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether the message should be promoted to pn_microsoftcrm. true, to promote, otherwise, false.</returns>
    public bool ShouldPromote
    {
      get
      {
        return this.Results.Contains(nameof (ShouldPromote)) && (bool) this.Results[nameof (ShouldPromote)];
      }
    }

    /// <summary>Gets the reason for the result in the <see cref="P:Microsoft.Crm.Sdk.Messages.CheckIncomingEmailResponse.ShouldDeliver"></see> property.</summary>
    /// <returns>Type: Returns_Int32The reason for the result in the <see cref="P:Microsoft.Crm.Sdk.Messages.CheckIncomingEmailResponse.ShouldDeliver"></see> property.</returns>
    public int ReasonCode
    {
      get
      {
        return this.Results.Contains(nameof (ReasonCode)) ? (int) this.Results[nameof (ReasonCode)] : 0;
      }
    }
  }
}
