using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create a quick campaign to distribute an activity to accounts, contacts, or leads that are selected by a query.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class PropagateByExpressionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the query criteria to select accounts, contacts, or leads for which activities are created. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryBase"></see>The query criteria to select accounts, contacts, or leads for which activities are created.</returns>
    public QueryBase QueryExpression
    {
      get
      {
        return this.Parameters.Contains(nameof (QueryExpression)) ? (QueryBase) this.Parameters[nameof (QueryExpression)] : (QueryBase) null;
      }
      set
      {
        this.Parameters[nameof (QueryExpression)] = (object) value;
      }
    }

    /// <summary>Gets or sets the user-identifiable name for the campaign. Required.</summary>
    /// <returns>Type: Returns_StringThe user-identifiable name for the campaign.</returns>
    public string FriendlyName
    {
      get
      {
        return this.Parameters.Contains(nameof (FriendlyName)) ? (string) this.Parameters[nameof (FriendlyName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (FriendlyName)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether the activity is both created and executed. Required.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether the activity is both created and executed. true if an activity is both created and executed; false if an activity is created but not executed.</returns>
    public bool ExecuteImmediately
    {
      get
      {
        return this.Parameters.Contains(nameof (ExecuteImmediately)) && (bool) this.Parameters[nameof (ExecuteImmediately)];
      }
      set
      {
        this.Parameters[nameof (ExecuteImmediately)] = (object) value;
      }
    }

    /// <summary>Gets or sets the activity to be distributed. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The activity to be distributed.</returns>
    public Entity Activity
    {
      get
      {
        return this.Parameters.Contains(nameof (Activity)) ? (Entity) this.Parameters[nameof (Activity)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Activity)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the email template. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the email template. This corresponds to the Template.TemplateId attribute, which is the primary key for the Template entity. Use the email template, if <see cref="P:Microsoft.Crm.Sdk.Messages.DistributeCampaignActivityRequest.SendEmail"></see> is true.Use the email template, if <see cref="P:Microsoft.Crm.Sdk.Messages.DistributeCampaignActivityRequest.SendEmail"></see> is true.Use the email template, if <see cref="P:Microsoft.Crm.Sdk.Messages.DistributeCampaignActivityRequest.SendEmail"></see> is true.Use the email template, if <see cref="P:Microsoft.Crm.Sdk.Messages.DistributeCampaignActivityRequest.SendEmail"></see> is true.</returns>
    public Guid TemplateId
    {
      get
      {
        return this.Parameters.Contains(nameof (TemplateId)) ? (Guid) this.Parameters[nameof (TemplateId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (TemplateId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ownership options for propagation. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.PropagationOwnershipOptions"></see>The ownership options for propagation.</returns>
    public PropagationOwnershipOptions OwnershipOptions
    {
      get
      {
        return this.Parameters.Contains(nameof (OwnershipOptions)) ? (PropagationOwnershipOptions) this.Parameters[nameof (OwnershipOptions)] : PropagationOwnershipOptions.None;
      }
      set
      {
        this.Parameters[nameof (OwnershipOptions)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether an asynchronous job is used to distribute an activity, such as an email, fax, or letter, to the members of a list. Required.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether an asynchronous job is used to distribute an activity, such as an email, fax, or letter, to the members of a list. true if an asynchronous job is used to distribute the activity; false if mail merge is used to distribute the activity.</returns>
    public bool PostWorkflowEvent
    {
      get
      {
        return this.Parameters.Contains(nameof (PostWorkflowEvent)) && (bool) this.Parameters[nameof (PostWorkflowEvent)];
      }
      set
      {
        this.Parameters[nameof (PostWorkflowEvent)] = (object) value;
      }
    }

    /// <summary>Gets or sets the owner for the activity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The owner for the activity.</returns>
    public EntityReference Owner
    {
      get
      {
        return this.Parameters.Contains(nameof (Owner)) ? (EntityReference) this.Parameters[nameof (Owner)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Owner)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether to send an email about the new activity. Required.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether to send an email about the new activity. true to automatically send email messages; otherwise, false. Primarily used for the email activity.</returns>
    public bool SendEmail
    {
      get
      {
        return this.Parameters.Contains(nameof (SendEmail)) && (bool) this.Parameters[nameof (SendEmail)];
      }
      set
      {
        this.Parameters[nameof (SendEmail)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the queue to which the created activities are added. Optional.</summary>
    /// <returns>Type: Returns_GuidThe ID of the queue to which the created activities are added. This corresponds to the Queue.QueueId attribute, which is the primary key for the Queue entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.PropagateByExpressionRequest"></see> class.</summary>
    public PropagateByExpressionRequest()
    {
      this.RequestName = "PropagateByExpression";
      this.QueryExpression = (QueryBase) null;
      this.FriendlyName = (string) null;
      this.ExecuteImmediately = false;
      this.Activity = (Entity) null;
      this.TemplateId = new Guid();
      this.OwnershipOptions = PropagationOwnershipOptions.None;
      this.PostWorkflowEvent = false;
      this.Owner = (EntityReference) null;
      this.SendEmail = false;
    }
  }
}
