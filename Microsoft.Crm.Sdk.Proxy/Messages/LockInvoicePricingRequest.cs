using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  lock the total price of products and services that are specified in the invoice.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class LockInvoicePricingRequest : OrganizationRequest
  {
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.LockInvoicePricingRequest"></see> class.</summary>
    public LockInvoicePricingRequest()
    {
      this.RequestName = "LockInvoicePricing";
      this.InvoiceId = new Guid();
    }
  }
}
