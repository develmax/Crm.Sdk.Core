using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data needed to retrieve all private queues of a specified user and optionally all public queues.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveUserQueuesRequest : OrganizationRequest
  {
    /// <returns>Type: Returns_Guid
    /// The id of the user. This corresponds to the SystemUser.SystemUserId attribute, which is the primary key for the SystemUser entity.</returns>
    public Guid UserId
    {
      get
      {
        return this.Parameters.Contains(nameof (UserId)) ? (Guid) this.Parameters[nameof (UserId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (UserId)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether the response should include public queues.</summary>
    /// <returns>Type: Returns_Booleantrue if the response should include public queues; otherwise, false.</returns>
    public bool IncludePublic
    {
      get
      {
        return this.Parameters.Contains(nameof (IncludePublic)) && (bool) this.Parameters[nameof (IncludePublic)];
      }
      set
      {
        this.Parameters[nameof (IncludePublic)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveUserQueuesRequest"></see> class.</summary>
    public RetrieveUserQueuesRequest()
    {
      this.RequestName = "RetrieveUserQueues";
      this.UserId = new Guid();
      this.IncludePublic = false;
    }
  }
}
