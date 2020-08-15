using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to validate the state transition.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class IsValidStateTransitionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the entity reference for the record whose transition state is validated.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The entity reference for the record whose transition state is validated.</returns>
    public EntityReference Entity
    {
      get
      {
        return this.Parameters.Contains(nameof (Entity)) ? (EntityReference) this.Parameters[nameof (Entity)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Entity)] = (object) value;
      }
    }

    /// <summary>Gets or sets the proposed new state for the record.</summary>
    /// <returns>Type: Returns_StringThe proposed new state for the record.</returns>
    public string NewState
    {
      get
      {
        return this.Parameters.Contains(nameof (NewState)) ? (string) this.Parameters[nameof (NewState)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (NewState)] = (object) value;
      }
    }

    /// <summary>Gets or sets the proposed new status for the record.</summary>
    /// <returns>Type:  Returns_Int32The proposed new status for the record.</returns>
    public int NewStatus
    {
      get
      {
        return this.Parameters.Contains(nameof (NewStatus)) ? (int) this.Parameters[nameof (NewStatus)] : 0;
      }
      set
      {
        this.Parameters[nameof (NewStatus)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.IsValidStateTransitionRequest"></see> class.</summary>
    public IsValidStateTransitionRequest()
    {
      this.RequestName = "IsValidStateTransition";
      this.Entity = (EntityReference) null;
      this.NewState = (string) null;
      this.NewStatus = 0;
    }
  }
}
