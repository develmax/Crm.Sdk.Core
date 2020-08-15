using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to send a bulk email message that is created from a template.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SendTemplateRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the template to be used for the email. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The the ID of the template to be used for the email, which corresponds to the Template.TemplateId attribute, which is the primary key for the Template entity.</returns>
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

    /// <summary>Gets or sets the sender of the email.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The sender of the email. The <see cref="P:Microsoft.Crm.Sdk.Messages.SendTemplateRequest.Sender"></see> property contains the ID of a record and an entity type. The return value of this property must be a system user.</returns>
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

    /// <summary>Gets or sets the type of entity that is represented by the list of recipients. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the entity that is represented by the list of recipients. Set this property to the name of the entity type for the recipient list that is specified in the <see cref="P:Microsoft.Crm.Sdk.Messages.SendTemplateRequest.RecipientIds"></see> property.</returns>
    public string RecipientType
    {
      get
      {
        return this.Parameters.Contains(nameof (RecipientType)) ? (string) this.Parameters[nameof (RecipientType)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (RecipientType)] = (object) value;
      }
    }

    /// <summary>Gets or sets the array that contains the list of recipients for the email. Required.</summary>
    /// <returns>Type: Returns_Guid[]
    /// The array of recipients for the email. The recipients must be of the same entity type that is specified in the <see cref="P:Microsoft.Crm.Sdk.Messages.SendTemplateRequest.RecipientType"></see> property.</returns>
    public Guid[] RecipientIds
    {
      get
      {
        return this.Parameters.Contains(nameof (RecipientIds)) ? (Guid[]) this.Parameters[nameof (RecipientIds)] : (Guid[]) null;
      }
      set
      {
        this.Parameters[nameof (RecipientIds)] = (object) value;
      }
    }

    /// <summary>Gets or sets the type of entity that is represented by the regarding ID. Required.</summary>
    /// <returns>Type: Returns_String
    /// The name of entity that is represented by the regarding ID. This property is the logical entity name of the record that is specified in the <see cref="P:Microsoft.Crm.Sdk.Messages.SendTemplateRequest.RegardingId"></see> property.</returns>
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

    /// <summary>Gets or sets the ID of a record that the email is regarding. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of a record that the email is regarding. This property is the ID of a record that is valid for the Email.RegardingObjectId attribute. The <see cref="P:Microsoft.Crm.Sdk.Messages.SendTemplateRequest.RegardingType"></see> property must contain the logical name of the entity type for this record.</returns>
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

    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>.</returns>
    public OptionSetValue DeliveryPriorityCode
    {
      get
      {
        return this.Parameters.Contains(nameof (DeliveryPriorityCode)) ? (OptionSetValue) this.Parameters[nameof (DeliveryPriorityCode)] : (OptionSetValue) null;
      }
      set
      {
        this.Parameters[nameof (DeliveryPriorityCode)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.SendTemplateRequest"></see> class.</summary>
    public SendTemplateRequest()
    {
      this.RequestName = "SendTemplate";
      this.TemplateId = new Guid();
      this.Sender = (EntityReference) null;
      this.RecipientType = (string) null;
      this.RecipientIds = (Guid[]) null;
      this.RegardingType = (string) null;
      this.RegardingId = new Guid();
    }
  }
}
