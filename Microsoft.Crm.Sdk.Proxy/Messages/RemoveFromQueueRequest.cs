using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to remove a queue item from a queue.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RemoveFromQueueRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the queue item to remove from the queue. Required.The QueueItemId property corresponds to the QueueItem.QueueItemId attribute, which is the primary key for the QueueItem entity.</summary>
    /// <returns>Type: Returns_Guid
    /// The QueueItemId. This corresponds to the QueueItem.QueueItemId attribute, which is the primary key for the QueueItem entity.</returns>
    public Guid QueueItemId
    {
      get
      {
        return this.Parameters.Contains(nameof (QueueItemId)) ? (Guid) this.Parameters[nameof (QueueItemId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (QueueItemId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RemoveFromQueueRequest"></see> class.</summary>
    public RemoveFromQueueRequest()
    {
      this.RequestName = "RemoveFromQueue";
      this.QueueItemId = new Guid();
    }
  }
}
