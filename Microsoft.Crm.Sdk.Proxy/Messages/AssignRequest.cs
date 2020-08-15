using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to assign the specified record to a new owner (user or team) by changing the OwnerId attribute of the record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AssignRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target record to assign to another user or team. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target record to assign. The value must be an entity reference for an entity that supports this message. For a list of supported entity types, see the <see cref="T:Microsoft.Crm.Sdk.Messages.AssignRequest"></see> class.</returns>
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

    /// <summary>Gets or sets the user or team for which you want to assign a record. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The reference to a user or team record.</returns>
    public EntityReference Assignee
    {
      get
      {
        return this.Parameters.Contains(nameof (Assignee)) ? (EntityReference) this.Parameters[nameof (Assignee)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Assignee)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AssignRequest"></see> class.</summary>
    public AssignRequest()
    {
      this.RequestName = "Assign";
      this.Target = (EntityReference) null;
      this.Assignee = (EntityReference) null;
    }
  }
}
