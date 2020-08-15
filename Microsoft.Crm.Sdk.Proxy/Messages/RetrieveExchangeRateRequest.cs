using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the exchange rate.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveExchangeRateRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the currency. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the currency. This corresponds to the TransactionCurrency.TransactionCurrencyId attribute, which is the primary key for the TransactionCurrency entity.</returns>
    public Guid TransactionCurrencyId
    {
      get
      {
        return this.Parameters.Contains(nameof (TransactionCurrencyId)) ? (Guid) this.Parameters[nameof (TransactionCurrencyId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (TransactionCurrencyId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveExchangeRateRequest"></see> class.</summary>
    public RetrieveExchangeRateRequest()
    {
      this.RequestName = "RetrieveExchangeRate";
      this.TransactionCurrencyId = new Guid();
    }
  }
}
