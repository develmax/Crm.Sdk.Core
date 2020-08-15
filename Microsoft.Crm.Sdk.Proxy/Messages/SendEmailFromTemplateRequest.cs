using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to send an email message using a template.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SendEmailFromTemplateRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the email template to use for the email.</summary>
    /// <returns>Type: Returns_GuidThe ID of the email template to use for the email. This corresponds to the Template.TemplateId attribute, which is the primary key for the Template entity.</returns>
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

    /// <summary>Gets or sets the type of the record with which the email message is associated.</summary>
    /// <returns>Type: Returns_StringThe type of the record with which the email message is associated.</returns>
    public string RegardingType
    {
      get
      {
        return this.Parameters.Contains(nameof (RegardingType)) ? (string) this.Parameters[nameof (RegardingType)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (RegardingType)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the record with which the email message is associated.</summary>
    /// <returns>Type: Returns_GuidThe ID of the record with which the email message is associated.</returns>
    public Guid RegardingId
    {
      get
      {
        return this.Parameters.Contains(nameof (RegardingId)) ? (Guid) this.Parameters[nameof (RegardingId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (RegardingId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the email record to send.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The the email record to send. This is an instance of an Email entity.</returns>
    public Entity Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (Entity) this.Parameters[nameof (Target)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the<see cref="T:Microsoft.Crm.Sdk.Messages.SendEmailFromTemplateRequest"></see> class.</summary>
    public SendEmailFromTemplateRequest()
    {
      this.RequestName = "SendEmailFromTemplate";
      this.TemplateId = new Guid();
      this.RegardingType = (string) null;
      this.RegardingId = new Guid();
      this.Target = (Entity) null;
    }
  }
}
