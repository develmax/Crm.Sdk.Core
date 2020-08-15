using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.DeliverIncomingEmailRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class DeliverIncomingEmailResponse : OrganizationResponse
  {
    /// <summary>Gets or sets the ID of the email.</summary>
    /// <returns>Type: Returns_GuidThe ID of the email. This corresponds to the Email.EmailId attribute, which is the primary key for the Email entity.</returns>
    public Guid EmailId
    {
      get
      {
        return this.Results.Contains(nameof (EmailId)) ? (Guid) this.Results[nameof (EmailId)] : new Guid();
      }
    }
  }
}
