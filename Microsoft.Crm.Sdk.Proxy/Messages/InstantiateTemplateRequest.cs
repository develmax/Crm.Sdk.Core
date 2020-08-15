using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the parameters that are needed to create an email message from a template (email template).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class InstantiateTemplateRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the template. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the template that corresponds to the Template.TemplateId attribute, which is the primary key for the Template entity.</returns>
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

    /// <summary>Gets or sets the type of entity that is represented by the <see cref="P:Microsoft.Crm.Sdk.Messages.InstantiateTemplateRequest.ObjectId"></see> property. Required.</summary>
    /// <returns>Type: Returns_String
    /// The logical name of the entity.</returns>
    public string ObjectType
    {
      get
      {
        return this.Parameters.Contains(nameof (ObjectType)) ? (string) this.Parameters[nameof (ObjectType)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (ObjectType)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the record that the email is regarding. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the record that the email is regarding. This must be the ID of an entity that has a relationship to the ActivityPointer entity.</returns>
    public Guid ObjectId
    {
      get
      {
        return this.Parameters.Contains(nameof (ObjectId)) ? (Guid) this.Parameters[nameof (ObjectId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ObjectId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.InstantiateTemplateRequest"></see> class.</summary>
    public InstantiateTemplateRequest()
    {
      this.RequestName = "InstantiateTemplate";
      this.TemplateId = new Guid();
      this.ObjectType = (string) null;
      this.ObjectId = new Guid();
    }
  }
}
