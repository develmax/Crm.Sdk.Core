using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.ConvertSalesOrderToInvoiceRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ConvertSalesOrderToInvoiceResponse : OrganizationResponse
  {
    /// <summary>Gets the resulting invoice.</summary>
    /// <returns>Type:<see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The resulting invoice. This is an instance of the Invoice class.</returns>
    public Entity Entity
    {
      get
      {
        return this.Results.Contains(nameof (Entity)) ? (Entity) this.Results[nameof (Entity)] : (Entity) null;
      }
    }
  }
}
