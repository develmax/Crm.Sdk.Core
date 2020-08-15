using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the collection of users that report to the specified system user (user).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAllChildUsersSystemUserRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the system user (user).</summary>
    /// <returns>Type: Returns_GuidThe ID of the system user (user). This corresponds to the SystemUser.SystemUserId property, which is the primary key for the SystemUser entity.</returns>
    public Guid EntityId
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityId)) ? (Guid) this.Parameters[nameof (EntityId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (EntityId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the set of attributes to retrieve. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>The set of attributes to retrieve.</returns>
    public ColumnSet ColumnSet
    {
      get
      {
        return this.Parameters.Contains(nameof (ColumnSet)) ? (ColumnSet) this.Parameters[nameof (ColumnSet)] : (ColumnSet) null;
      }
      set
      {
        this.Parameters[nameof (ColumnSet)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveAllChildUsersSystemUserRequest"></see> class.</summary>
    public RetrieveAllChildUsersSystemUserRequest()
    {
      this.RequestName = "RetrieveAllChildUsersSystemUser";
      this.EntityId = new Guid();
      this.ColumnSet = (ColumnSet) null;
    }
  }
}
