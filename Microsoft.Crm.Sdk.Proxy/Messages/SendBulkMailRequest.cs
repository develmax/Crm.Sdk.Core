using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to send bulk email messages.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SendBulkMailRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the sender of the email messages.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The sender of the email messages.</returns>
    public EntityReference Sender
    {
      get
      {
        return this.Parameters.Contains(nameof (Sender)) ? (EntityReference) this.Parameters[nameof (Sender)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Sender)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the email template to use.</summary>
    /// <returns>Type: Returns_GuidThe ID of the email template to use. This corresponds to the Template.TemplateId attribute, which is the primary key for the Template entity.</returns>
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

    /// <summary>Gets or sets the type of the record with which the email messages are associated.</summary>
    /// <returns>Type: Returns_StringThe type of the record with which the email messages are associated. </returns>
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

    /// <summary>Gets or sets the ID of the record with which the email messages are associated.</summary>
    /// <returns>Type: Returns_GuidThe ID of the record with which the email messages are associated. </returns>
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

    /// <summary>Gets or sets the query to retrieve the recipients for the email messages.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryBase"></see>The query to retrieve the recipients for the email messages.</returns>
    public QueryBase Query
    {
      get
      {
        return this.Parameters.Contains(nameof (Query)) ? (QueryBase) this.Parameters[nameof (Query)] : (QueryBase) null;
      }
      set
      {
        this.Parameters[nameof (Query)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the<see cref="T:Microsoft.Crm.Sdk.Messages.SendBulkMailRequest"></see> class.</summary>
    public SendBulkMailRequest()
    {
      this.RequestName = "SendBulkMail";
      this.Sender = (EntityReference) null;
      this.TemplateId = new Guid();
      this.RegardingType = (string) null;
      this.RegardingId = new Guid();
      this.Query = (QueryBase) null;
    }
  }
}
