using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to qualify a lead and create account, contact, and opportunity records that are linked to the originating lead record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class QualifyLeadRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the lead that is qualified. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The ID of the lead that is qualified. This corresponds to the Lead.LeadId attribute, which is the primary key for the Lead entity.</returns>
    public EntityReference LeadId
    {
      get
      {
        return this.Parameters.Contains(nameof (LeadId)) ? (EntityReference) this.Parameters[nameof (LeadId)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (LeadId)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether to create an account from the originating lead. Required.</summary>
    /// <returns>Type:  Returns_BooleanIndicates whether to create an account from the originating lead. True, to create an account; otherwise, false.</returns>
    public bool CreateAccount
    {
      get
      {
        return this.Parameters.Contains(nameof (CreateAccount)) && (bool) this.Parameters[nameof (CreateAccount)];
      }
      set
      {
        this.Parameters[nameof (CreateAccount)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether to create a contact from the originating lead. Required.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether to create a contact from the originating lead. True, to create a contact; otherwise, false.</returns>
    public bool CreateContact
    {
      get
      {
        return this.Parameters.Contains(nameof (CreateContact)) && (bool) this.Parameters[nameof (CreateContact)];
      }
      set
      {
        this.Parameters[nameof (CreateContact)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether to create an opportunity from the originating lead. Required.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether to create an opportunity from the originating lead. True, to create an opportunity; otherwise, false.</returns>
    public bool CreateOpportunity
    {
      get
      {
        return this.Parameters.Contains(nameof (CreateOpportunity)) && (bool) this.Parameters[nameof (CreateOpportunity)];
      }
      set
      {
        this.Parameters[nameof (CreateOpportunity)] = (object) value;
      }
    }

    /// <summary>Gets or sets the currency to use for this opportunity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The currency to use for this opportunity.</returns>
    public EntityReference OpportunityCurrencyId
    {
      get
      {
        return this.Parameters.Contains(nameof (OpportunityCurrencyId)) ? (EntityReference) this.Parameters[nameof (OpportunityCurrencyId)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (OpportunityCurrencyId)] = (object) value;
      }
    }

    /// <summary>Gets or set the account or contact that is associated with the opportunity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The account or contact that is associated with the opportunity.</returns>
    public EntityReference OpportunityCustomerId
    {
      get
      {
        return this.Parameters.Contains(nameof (OpportunityCustomerId)) ? (EntityReference) this.Parameters[nameof (OpportunityCustomerId)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (OpportunityCustomerId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the source campaign that is associated with the opportunity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The source campaign that is associated with the opportunity.</returns>
    public EntityReference SourceCampaignId
    {
      get
      {
        return this.Parameters.Contains(nameof (SourceCampaignId)) ? (EntityReference) this.Parameters[nameof (SourceCampaignId)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (SourceCampaignId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the status of the lead. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>The status of the lead.</returns>
    public OptionSetValue Status
    {
      get
      {
        return this.Parameters.Contains(nameof (Status)) ? (OptionSetValue) this.Parameters[nameof (Status)] : (OptionSetValue) null;
      }
      set
      {
        this.Parameters[nameof (Status)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.QualifyLeadRequest"></see> class.</summary>
    public QualifyLeadRequest()
    {
      this.RequestName = "QualifyLead";
      this.LeadId = (EntityReference) null;
      this.CreateAccount = false;
      this.CreateContact = false;
      this.CreateOpportunity = false;
    }
  }
}
