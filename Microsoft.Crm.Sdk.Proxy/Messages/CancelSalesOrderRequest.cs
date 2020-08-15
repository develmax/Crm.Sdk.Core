using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to cancel a sales order (order). </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CancelSalesOrderRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the close activity that is associated with the sales order (order) that you want to cancel. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The close activity that is associated with the sales order (order) that you want to cancel. This is an instance of the OrderClose class, which is a subclass of the <see cref="T:Microsoft.Xrm.Sdk.Entity"></see> class. </returns>
    public Entity OrderClose
    {
      get
      {
        return this.Parameters.Contains(nameof (OrderClose)) ? (Entity) this.Parameters[nameof (OrderClose)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (OrderClose)] = (object) value;
      }
    }

    /// <summary>Gets or sets the status of the sales order (order). Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>The status of the sales order (order).</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CancelSalesOrderRequest"></see> class.</summary>
    public CancelSalesOrderRequest()
    {
      this.RequestName = "CancelSalesOrder";
      this.OrderClose = (Entity) null;
      this.Status = (OptionSetValue) null;
    }
  }
}
