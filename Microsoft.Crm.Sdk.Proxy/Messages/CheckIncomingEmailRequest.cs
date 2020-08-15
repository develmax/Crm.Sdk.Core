using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to check whether the incoming email message is relevant to the pn_microsoftcrm system.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CheckIncomingEmailRequest : OrganizationRequest
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

    /// <summary>Gets or sets the from address for the email message.</summary>
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

    /// <summary>Gets or sets the addresses of the recipients of the email message.</summary>
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

    /// <summary>Gets or sets the addresses of the carbon copy (Cc) recipients for the email message.</summary>
    /// <returns>Type: Returns_StringThe carbon copy (Cc) recipients for the email message.</returns>
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

    /// <summary>Gets or sets the addresses of the blind carbon copy (Bcc) recipients for the email message.</summary>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CheckIncomingEmailRequest"></see> class.</summary>
    public CheckIncomingEmailRequest()
    {
      this.RequestName = "CheckIncomingEmail";
      this.MessageId = (string) null;
      this.From = (string) null;
      this.To = (string) null;
      this.Cc = (string) null;
      this.Bcc = (string) null;
    }
  }
}
