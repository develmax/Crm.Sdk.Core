using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.DeliverPromoteEmailRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class DeliverPromoteEmailResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the newly created email activity.</summary>
    /// <returns>Type: Returns_GuidThe ID of the newly created email activity. This corresponds to the Email.EmailId attribute, which is the primary key for the Email entity.</returns>
    public Guid EmailId
    {
      get
      {
        return this.Results.Contains(nameof (EmailId)) ? (Guid) this.Results[nameof (EmailId)] : new Guid();
      }
    }
  }
}
