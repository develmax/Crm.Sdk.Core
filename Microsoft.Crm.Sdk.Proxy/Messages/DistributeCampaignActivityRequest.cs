using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create a bulk operation that distributes a campaign activity. The appropriate activities, such as a phone call or fax, are created for the members of the list that is associated with the specified campaign activity.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class DistributeCampaignActivityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the campaign activity for which the activity is distributed. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the campaign activity for which the activity is distributed. This corresponds to the CampaignActivity.ActivityId attribute, which is the primary key for the CampaignActivity entity.</returns>
    public Guid CampaignActivityId
    {
      get
      {
        return this.Parameters.Contains(nameof (CampaignActivityId)) ? (Guid) this.Parameters[nameof (CampaignActivityId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (CampaignActivityId)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether the activity is both created and executed. Required.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether the activity is both created and executed. true if an activity is both created and executed; false if an activity is created but not executed.</returns>
    public bool Propagate
    {
      get
      {
        return this.Parameters.Contains(nameof (Propagate)) && (bool) this.Parameters[nameof (Propagate)];
      }
      set
      {
        this.Parameters[nameof (Propagate)] = (object) value;
      }
    }

    /// <summary>Gets or sets the activity to be distributed. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The activity to be distributed, which must be instance of an activity class. You can only use activities that specify a recipient: a phone call, appointment, letter, fax, or email. .</returns>
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
    /// <returns>Type: Returns_GuidThe ID of the email template. This corresponds to the Template.TemplateId attribute, which is the primary key for the Template entity. Use the email template, if <see cref="P:Microsoft.Crm.Sdk.Messages.DistributeCampaignActivityRequest.SendEmail"></see> is true.</returns>
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

    /// <summary>Gets or sets the ownership options for the activity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.PropagationOwnershipOptions"></see>The ownership options for the activity.</returns>
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

    /// <summary>Gets or sets the owner for the newly created activity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see> The owner for the newly created activity.</returns>
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
    /// <returns>Type: Returns_Booleantrue if you want emails sent automatically; otherwise, false. Use this property for the email activity.</returns>
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

    /// <summary>Gets or sets the ID of the queue to which the created activity is added. Optional.</summary>
    /// <returns>Type: Returns_GuidThe ID of the queue to which the created activity is added. This corresponds to the Queue.QueueId attribute, which is the primary key for the Queue entity.</returns>
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

    /// <summary>Gets or sets a value that indicates whether an asynchronous job is used to distribute activities, such as an email, fax, or letter, to the members of a list. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if an asynchronous job is used to distribute the activity; false if mail merge is used to distribute the activity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.DistributeCampaignActivityRequest"></see> class.</summary>
    public DistributeCampaignActivityRequest()
    {
      this.RequestName = "DistributeCampaignActivity";
      this.CampaignActivityId = new Guid();
      this.Propagate = false;
      this.Activity = (Entity) null;
      this.TemplateId = new Guid();
      this.OwnershipOptions = PropagationOwnershipOptions.None;
      this.Owner = (EntityReference) null;
      this.SendEmail = false;
      this.PostWorkflowEvent = false;
    }
  }
}
