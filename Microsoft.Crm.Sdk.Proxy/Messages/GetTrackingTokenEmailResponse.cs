using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.GetTrackingTokenEmailRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetTrackingTokenEmailResponse : OrganizationResponse
  {
    /// <summary>Gets the requested tracking token.</summary>
    /// <returns>Type: Returns_StringThe requested tracking token. This value can be passed as a property in the <see cref="T:Microsoft.Crm.Sdk.Messages.SendEmailRequest"></see> message.</returns>
    public string TrackingToken
    {
      get
      {
        return this.Results.Contains(nameof (TrackingToken)) ? (string) this.Results[nameof (TrackingToken)] : (string) null;
      }
    }
  }
}
