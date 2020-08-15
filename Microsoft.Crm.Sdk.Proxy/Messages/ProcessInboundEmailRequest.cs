using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to process the email responses from a marketing campaign.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ProcessInboundEmailRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the inbound email activity.</summary>
    /// <returns>Type: Returns_GuidThe ID of the inbound email activity. This corresponds to the ActivityPointer.ActivityId attribute, which is the primary key for the ActivityPointer entity. Alternatively, it can be the ActivityID for any activity entity type, including custom activity entities.</returns>
    public Guid InboundEmailActivity
    {
      get
      {
        return this.Parameters.Contains(nameof (InboundEmailActivity)) ? (Guid) this.Parameters[nameof (InboundEmailActivity)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (InboundEmailActivity)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ProcessInboundEmailRequest"></see> class.</summary>
    public ProcessInboundEmailRequest()
    {
      this.RequestName = "ProcessInboundEmail";
      this.InboundEmailActivity = new Guid();
    }
  }
}
