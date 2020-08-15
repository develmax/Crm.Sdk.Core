using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  lock the total price of products and services that are specified in the sales order (order).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class LockSalesOrderPricingRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the sales order.</summary>
    /// <returns>Type: Returns_GuidThe ID of the sales order. This corresponds to the SalesOrder.SalesOrderId attribute, which is the primary key for the SalesOrder entity.</returns>
    public Guid SalesOrderId
    {
      get
      {
        return this.Parameters.Contains(nameof (SalesOrderId)) ? (Guid) this.Parameters[nameof (SalesOrderId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (SalesOrderId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.LockSalesOrderPricingRequest"></see> class.</summary>
    public LockSalesOrderPricingRequest()
    {
      this.RequestName = "LockSalesOrderPricing";
      this.SalesOrderId = new Guid();
    }
  }
}
