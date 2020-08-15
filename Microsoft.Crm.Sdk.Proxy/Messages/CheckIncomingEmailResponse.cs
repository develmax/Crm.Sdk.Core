using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.CheckIncomingEmailRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CheckIncomingEmailResponse : OrganizationResponse
  {
    /// <summary>Gets a value that indicates whether the message should be delivered to pn_microsoftcrm.</summary>
    /// <returns>Type: Returns_Booleantrue if the message should be delivered to pn_microsoftcrm; otherwise, false.</returns>
    public bool ShouldDeliver
    {
      get
      {
        return this.Results.Contains(nameof (ShouldDeliver)) && (bool) this.Results[nameof (ShouldDeliver)];
      }
    }

    /// <summary>Gets the reason for the result in the <see cref="P:Microsoft.Crm.Sdk.Messages.CheckIncomingEmailResponse.ShouldDeliver"></see> property.</summary>
    /// <returns>Type: Returns_Int32
    /// The reason for the failure.</returns>
    public int ReasonCode
    {
      get
      {
        return this.Results.Contains(nameof (ReasonCode)) ? (int) this.Results[nameof (ReasonCode)] : 0;
      }
    }
  }
}
