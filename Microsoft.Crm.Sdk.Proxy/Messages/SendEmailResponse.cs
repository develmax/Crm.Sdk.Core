using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.BackgroundSendEmailRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SendEmailResponse : OrganizationResponse
  {
    /// <summary>Gets the subject line for the email message.</summary>
    /// <returns>Type: Returns_StringThe subject line for the email message.</returns>
    public string Subject
    {
      get
      {
        return this.Results.Contains(nameof (Subject)) ? (string) this.Results[nameof (Subject)] : (string) null;
      }
    }
  }
}
