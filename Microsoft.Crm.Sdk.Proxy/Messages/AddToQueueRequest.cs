using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  move an entity record from a source queue to a destination queue.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddToQueueRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target record to add to the destination queue. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>
    /// The target record to add to the destination queue, which must be an entity reference for an entity that is enabled for queues. For more information, see Enabling Entities for Queues/html/a60160f0-6de8-4aed-af92-cb180e883c82.htm#BKMK_Enabling.</returns>
    public EntityReference Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the source queue. Optional.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the source queue that corresponds to the Queue.QueueId attribute, which is the primary key for the Queue entity.</returns>
    public Guid SourceQueueId
    {
      get
      {
        return this.Parameters.Contains(nameof (SourceQueueId)) ? (Guid) this.Parameters[nameof (SourceQueueId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (SourceQueueId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the destination queue. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the destination queue that corresponds to the Queue.QueueId attribute, which is the primary key for the Queue entity.</returns>
    public Guid DestinationQueueId
    {
      get
      {
        return this.Parameters.Contains(nameof (DestinationQueueId)) ? (Guid) this.Parameters[nameof (DestinationQueueId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (DestinationQueueId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the properties that are needed to create a queue item in the destination queue. Optional.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>
    /// The properties that are needed to create a queue item in the destination queue. The destination queue must be an instance of the QueueItem class, which is a subclass of the Entity class.</returns>
    public Entity QueueItemProperties
    {
      get
      {
        return this.Parameters.Contains(nameof (QueueItemProperties)) ? (Entity) this.Parameters[nameof (QueueItemProperties)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (QueueItemProperties)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the   <see cref="T:Microsoft.Crm.Sdk.Messages.AddToQueueRequest"></see> class.</summary>
    public AddToQueueRequest()
    {
      this.RequestName = "AddToQueue";
      this.Target = (EntityReference) null;
      this.DestinationQueueId = new Guid();
    }
  }
}
