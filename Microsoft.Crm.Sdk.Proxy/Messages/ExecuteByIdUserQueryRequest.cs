using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  execute the user query (saved view) that has the specified ID.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExecuteByIdUserQueryRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the user query (saved view) record to be executed.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The ID of the user query (saved view) record to be executed. The ID corresponds to the UserQuery.UserQueryId property, which is the primary key for the UserQuery entity.</returns>
    public EntityReference EntityId
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityId)) ? (EntityReference) this.Parameters[nameof (EntityId)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (EntityId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ExecuteByIdUserQueryRequest"></see> class.</summary>
    public ExecuteByIdUserQueryRequest()
    {
      this.RequestName = "ExecuteByIdUserQuery";
      this.EntityId = (EntityReference) null;
    }
  }
}
