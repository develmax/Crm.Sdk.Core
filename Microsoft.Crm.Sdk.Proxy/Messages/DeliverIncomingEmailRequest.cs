using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to create an email activity record from an incoming email message (Track in CRM).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class DeliverIncomingEmailRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the email message stored in the email header. Required.</summary>
    /// <returns>Type: Returns_StringThe ID of the email message stored in the email header.</returns>
    public string MessageId
    {
      get
      {
        return this.Parameters.Contains(nameof (MessageId)) ? (string) this.Parameters[nameof (MessageId)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (MessageId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the subject line for the email message. Optional.</summary>
    /// <returns>Type: Returns_StringThe subject line for the email message.</returns>
    public string Subject
    {
      get
      {
        return this.Parameters.Contains(nameof (Subject)) ? (string) this.Parameters[nameof (Subject)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (Subject)] = (object) value;
      }
    }

    /// <summary>Gets or sets the from address for the email message. Required.</summary>
    /// <returns>Type: Returns_StringThe from address for the email message.</returns>
    public string From
    {
      get
      {
        return this.Parameters.Contains(nameof (From)) ? (string) this.Parameters[nameof (From)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (From)] = (object) value;
      }
    }

    /// <summary>Gets or sets the addresses of the recipients of the email message. Required.</summary>
    /// <returns>Type: Returns_StringThe addresses of the recipients of the email message.</returns>
    public string To
    {
      get
      {
        return this.Parameters.Contains(nameof (To)) ? (string) this.Parameters[nameof (To)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (To)] = (object) value;
      }
    }

    /// <summary>Gets or sets the addresses of the carbon copy (Cc) recipients for the email message. Required.</summary>
    /// <returns>Type: Returns_StringThe addresses of the carbon copy (Cc) recipients for the email message.</returns>
    public string Cc
    {
      get
      {
        return this.Parameters.Contains(nameof (Cc)) ? (string) this.Parameters[nameof (Cc)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (Cc)] = (object) value;
      }
    }

    /// <summary>Gets or sets the addresses of the blind carbon copy (Bcc) recipients for the email message. Required.</summary>
    /// <returns>Type: Returns_StringThe addresses of the blind carbon copy (Bcc) recipients for the email message.</returns>
    public string Bcc
    {
      get
      {
        return this.Parameters.Contains(nameof (Bcc)) ? (string) this.Parameters[nameof (Bcc)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (Bcc)] = (object) value;
      }
    }

    /// <summary>Gets or sets the time the message was received on. Required.</summary>
    /// <returns>Type: Returns_DateTimeThe time the message was received on.</returns>
    public DateTime ReceivedOn
    {
      get
      {
        return this.Parameters.Contains(nameof (ReceivedOn)) ? (DateTime) this.Parameters[nameof (ReceivedOn)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (ReceivedOn)] = (object) value;
      }
    }

    /// <summary>Gets or sets the email address of the account that is creating the email activity instance. Required.</summary>
    /// <returns>Type: Returns_StringThe email address of the account that is creating the email activity instance.</returns>
    public string SubmittedBy
    {
      get
      {
        return this.Parameters.Contains(nameof (SubmittedBy)) ? (string) this.Parameters[nameof (SubmittedBy)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (SubmittedBy)] = (object) value;
      }
    }

    /// <summary>Gets or sets the level of importance for the email message. Required.</summary>
    /// <returns>Type: Returns_StringThe level of importance for the email message.</returns>
    public string Importance
    {
      get
      {
        return this.Parameters.Contains(nameof (Importance)) ? (string) this.Parameters[nameof (Importance)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (Importance)] = (object) value;
      }
    }

    /// <summary>Gets or sets the message body for the email. Required.</summary>
    /// <returns>Type: Returns_StringThe message body for the email.</returns>
    public string Body
    {
      get
      {
        return this.Parameters.Contains(nameof (Body)) ? (string) this.Parameters[nameof (Body)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (Body)] = (object) value;
      }
    }

    /// <summary>Gets or sets a collection of activity mime attachment (email attachment) instances to attach to the email message. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The collection of ActivityMimeAttachment records to attach to the email message.</returns>
    public EntityCollection Attachments
    {
      get
      {
        return this.Parameters.Contains(nameof (Attachments)) ? (EntityCollection) this.Parameters[nameof (Attachments)] : (EntityCollection) null;
      }
      set
      {
        this.Parameters[nameof (Attachments)] = (object) value;
      }
    }

    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>.</returns>
    public Entity ExtraProperties
    {
      get
      {
        return this.Parameters.Contains(nameof (ExtraProperties)) ? (Entity) this.Parameters[nameof (ExtraProperties)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (ExtraProperties)] = (object) value;
      }
    }

    /// <returns>Type: Returns_Boolean.</returns>
    public bool ValidateBeforeCreate
    {
      get
      {
        return this.Parameters.Contains(nameof (ValidateBeforeCreate)) && (bool) this.Parameters[nameof (ValidateBeforeCreate)];
      }
      set
      {
        this.Parameters[nameof (ValidateBeforeCreate)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.DeliverIncomingEmailRequest"></see> class.</summary>
    public DeliverIncomingEmailRequest()
    {
      this.RequestName = "DeliverIncomingEmail";
      this.MessageId = (string) null;
      this.From = (string) null;
      this.To = (string) null;
      this.Cc = (string) null;
      this.Bcc = (string) null;
      this.ReceivedOn = new DateTime();
      this.SubmittedBy = (string) null;
      this.Importance = (string) null;
      this.Body = (string) null;
      this.Attachments = (EntityCollection) null;
    }
  }
}
