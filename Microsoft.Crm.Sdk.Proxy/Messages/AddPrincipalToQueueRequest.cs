using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data to add the specified principal to the list of queue members. If the principal is a team, add each team member to the queue.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddPrincipalToQueueRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the queue. Required</summary>
    /// <returns>Type: Returns_GuidThe ID of the queue.</returns>
    public Guid QueueId
    {
      get
      {
        return this.Parameters.Contains(nameof (QueueId)) ? (Guid) this.Parameters[nameof (QueueId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (QueueId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the principal to add to the queue. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The principal to add to the queue.</returns>
    public Entity Principal
    {
      get
      {
        return this.Parameters.Contains(nameof (Principal)) ? (Entity) this.Parameters[nameof (Principal)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Principal)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AddPrincipalToQueueRequest"></see> class.</summary>
    public AddPrincipalToQueueRequest()
    {
      this.RequestName = "AddPrincipalToQueue";
      this.QueueId = new Guid();
      this.Principal = (Entity) null;
    }
  }
}
