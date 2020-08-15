using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the products from an opportunity and copy them to the invoice.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetInvoiceProductsFromOpportunityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the opportunity.</summary>
    /// <returns>Type: Returns_GuidThe ID of the opportunity. This corresponds to the Opportunity.OpportunityId attribute, which is the primary key for the Opportunity entity.</returns>
    public Guid OpportunityId
    {
      get
      {
        return this.Parameters.Contains(nameof (OpportunityId)) ? (Guid) this.Parameters[nameof (OpportunityId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (OpportunityId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the invoice.</summary>
    /// <returns>Type: Returns_GuidThe ID of the invoice. This corresponds to the Invoice.InvoiceId attribute, which is the primary key for the Invoice entity.</returns>
    public Guid InvoiceId
    {
      get
      {
        return this.Parameters.Contains(nameof (InvoiceId)) ? (Guid) this.Parameters[nameof (InvoiceId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (InvoiceId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.GetInvoiceProductsFromOpportunityRequest"></see> class.</summary>
    public GetInvoiceProductsFromOpportunityRequest()
    {
      this.RequestName = "GetInvoiceProductsFromOpportunity";
      this.OpportunityId = new Guid();
      this.InvoiceId = new Guid();
    }
  }
}
