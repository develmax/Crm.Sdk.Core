using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to assign a queue item back to the queue owner so others can pick it.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ReleaseToQueueRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the id of the queue item. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The queue item. This corresponds to the QueueItem.QueueItemId attribute, which is the primary key for the QueueItem entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ReleaseToQueueRequest"></see> class.</summary>
    public ReleaseToQueueRequest()
    {
      this.RequestName = "ReleaseToQueue";
      this.QueueItemId = new Guid();
    }
  }
}
