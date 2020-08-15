using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.AddToQueueRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddToQueueResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the queue item that is created in the destination queue.</summary>
    /// <returns>Type:  Returns_Guid
    /// The ID of the queue item that is created in the destination queue,  which corresponds to the QueueItem.QueueItemId attribute, which is the primary key for the QueueItem entity</returns>
    public Guid QueueItemId
    {
      get
      {
        return this.Results.Contains(nameof (QueueItemId)) ? (Guid) this.Results[nameof (QueueItemId)] : new Guid();
      }
    }
  }
}
