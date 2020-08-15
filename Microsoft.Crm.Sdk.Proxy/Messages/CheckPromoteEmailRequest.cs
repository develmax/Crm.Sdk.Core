using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to check whether the incoming email message should be promoted to the pn_microsoftcrm system.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CheckPromoteEmailRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the message ID that is contained in the email header. Required.</summary>
    /// <returns>Type: Returns_StringThe message ID that is contained in the email header. All email messages have an ID property in their headers. This is similar to a GUID and is used to identify the message and to see if a specific email message has already been promoted (added) to pn_microsoftcrm.</returns>
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

    /// <summary>Gets or sets the subject of the message. Optional.</summary>
    /// <returns>Type: Returns_StringThe subject of the message.</returns>
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

    /// <summary>Provides the direction of a mail checked for promotion for uniqueness.</summary>
    /// <returns>Returns <see cref="T:System.Int32"></see>.</returns>
    public int DirectionCode
    {
      get
      {
        return this.Parameters.Contains(nameof (DirectionCode)) ? (int) this.Parameters[nameof (DirectionCode)] : 0;
      }
      set
      {
        this.Parameters[nameof (DirectionCode)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CheckPromoteEmailRequest"></see> class.</summary>
    public CheckPromoteEmailRequest()
    {
      this.RequestName = "CheckPromoteEmail";
      this.MessageId = (string) null;
    }
  }
}
