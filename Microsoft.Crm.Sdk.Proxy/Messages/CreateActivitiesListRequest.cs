using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create a quick campaign to distribute an activity to members of a list (marketing list).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CreateActivitiesListRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the list. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the list that corresponds to the List.ListId attribute, which is the primary key for the List entity.</returns>
    public Guid ListId
    {
      get
      {
        return this.Parameters.Contains(nameof (ListId)) ? (Guid) this.Parameters[nameof (ListId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ListId)] = (object) value;
      }
    }

    /// <summary>Gets or sets a display name for the campaign. Required.</summary>
    /// <returns>Type: Returns_StringThe display name for the campaign.</returns>
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
    /// <returns>Type: Returns_GuidThe ID of the email template that corresponds to the Template.TemplateId attribute, which is the primary key for the Template entity.</returns>
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

    /// <summary>Gets or sets the propagation ownership options. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.PropagationOwnershipOptions"></see>The propagation ownership options.</returns>
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
    /// <returns>Type: Returns_BooleanIndicates whether to send an email about the new activity. true if you want email messages sent automatically; otherwise, false.</returns>
    public bool sendEmail
    {
      get
      {
        return this.Parameters.Contains(nameof (sendEmail)) && (bool) this.Parameters[nameof (sendEmail)];
      }
      set
      {
        this.Parameters[nameof (sendEmail)] = (object) value;
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

    /// <summary>Gets or sets the ID of the queue to which the created activities are added. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the queue to which the created activities are added that corresponds to the Queue.QueueId attribute, which is the primary key for the Queue entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CreateActivitiesListRequest"></see> class.</summary>
    public CreateActivitiesListRequest()
    {
      this.RequestName = "CreateActivitiesList";
      this.ListId = new Guid();
      this.FriendlyName = (string) null;
      this.Activity = (Entity) null;
      this.TemplateId = new Guid();
      this.Propagate = false;
      this.OwnershipOptions = PropagationOwnershipOptions.None;
      this.Owner = (EntityReference) null;
      this.sendEmail = false;
      this.PostWorkflowEvent = false;
    }
  }
}
