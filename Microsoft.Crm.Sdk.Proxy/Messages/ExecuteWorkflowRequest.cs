using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to execute a workflow.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExecuteWorkflowRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the record on which the workflow executes. Required.</summary>
    /// <returns>Type: Returns_Guid. The ID of the record on which the workflow executes.</returns>
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

    /// <summary>Gets or sets the ID of the workflow to execute. Required.</summary>
    /// <returns>Type: Returns_Guid. The ID of the workflow to execute.</returns>
    public Guid WorkflowId
    {
      get
      {
        return this.Parameters.Contains(nameof (WorkflowId)) ? (Guid) this.Parameters[nameof (WorkflowId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (WorkflowId)] = (object) value;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Returns <see cref="T:Microsoft.Crm.Sdk.Messages.InputArgumentCollection"></see>.</returns>
    public InputArgumentCollection InputArguments
    {
      get
      {
        return this.Parameters.Contains(nameof (InputArguments)) ? (InputArgumentCollection) this.Parameters[nameof (InputArguments)] : (InputArgumentCollection) null;
      }
      set
      {
        this.Parameters[nameof (InputArguments)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ExecuteWorkflowRequest"></see> class.</summary>
    public ExecuteWorkflowRequest()
    {
      this.RequestName = "ExecuteWorkflow";
      this.EntityId = new Guid();
      this.WorkflowId = new Guid();
    }
  }
}
