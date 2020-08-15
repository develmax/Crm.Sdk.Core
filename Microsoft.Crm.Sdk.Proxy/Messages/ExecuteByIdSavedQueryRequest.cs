using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to execute a saved query (view) that has the specified ID.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExecuteByIdSavedQueryRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the saved query (view) to execute.</summary>
    /// <returns>Type: Returns_GuidThe ID of the saved query (view) to execute. This corresponds to the SavedQuery.SavedQueryId property, which is the primary key for the SavedQuery entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ExecuteByIdSavedQueryRequest"></see> class.</summary>
    public ExecuteByIdSavedQueryRequest()
    {
      this.RequestName = "ExecuteByIdSavedQuery";
      this.EntityId = new Guid();
    }
  }
}
