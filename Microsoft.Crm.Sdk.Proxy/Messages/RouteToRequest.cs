using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to route a queue item to a queue, a user, or a team.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RouteToRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target record to route the queue item to. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target record to route the queue item to.</returns>
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

    /// <summary>Gets or sets the id of the queue item to route. Required</summary>
    /// <returns>Type: Returns_Guid
    /// The QueueItem id. This corresponds to the QueueItem.QueueItemId attribute, which is the primary key for the QueueItem entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RouteToRequest"></see> class.</summary>
    public RouteToRequest()
    {
      this.RequestName = "RouteTo";
      this.Target = (EntityReference) null;
    }
  }
}
