using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create an email activity record from the specified email message (Track in CRM).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class DeliverPromoteEmailRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the email from which to create the email. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the email, which corresponds to the Email.EmailId attribute, which is the primary key for the Email entity..</returns>
    public Guid EmailId
    {
      get
      {
        return this.Parameters.Contains(nameof (EmailId)) ? (Guid) this.Parameters[nameof (EmailId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (EmailId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the email message stored in the email header. Required.</summary>
    /// <returns>Type: Returns_String
    /// The the ID of the email message from the email header.</returns>
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
    /// <returns>Type: Returns_String
    /// The subject line for the email.</returns>
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
    /// <returns>Type: Returns_String
    /// The from address for the email.</returns>
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
    /// <returns>Type: Returns_String
    /// The addresses of the recipients of the email message.</returns>
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
    /// <returns>Type: Returns_String
    /// The addresses of the CC recipients.</returns>
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
    /// <returns>Type: Returns_String
    /// The addresses of the BCC recipients.</returns>
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
    /// <returns>Type: Returns_DateTimeThe time the message was received.</returns>
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
    /// <returns>Type: Returns_String
    /// The email address of the account that is creating the email activity.</returns>
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
    /// <returns>Type: Returns_String
    /// The level of importance for the email.</returns>
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
    /// <returns>Type: Returns_String
    /// The message body.</returns>
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

    /// <summary>Gets or sets a collection of activity mime attachment (email attachment) records to attach to the email message. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The collection of attachments, which a collection of ActivityMimeAttachment records..</returns>
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

    /// <summary>Gets or sets the extra properties for the email. Optional.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The extra properties.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.DeliverPromoteEmailRequest"></see> class.</summary>
    public DeliverPromoteEmailRequest()
    {
      this.RequestName = "DeliverPromoteEmail";
      this.EmailId = new Guid();
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
