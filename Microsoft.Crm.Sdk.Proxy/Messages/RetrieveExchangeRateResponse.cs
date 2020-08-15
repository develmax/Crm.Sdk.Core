using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveExchangeRateRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveExchangeRateResponse : OrganizationResponse
  {
    /// <summary>Gets the exchange rate for the currency.</summary>
    /// <returns>Type: Returns_DecimalThe exchange rate for the currency. </returns>
    public Decimal ExchangeRate
    {
      get
      {
        return this.Results.Contains(nameof (ExchangeRate)) ? (Decimal) this.Results[nameof (ExchangeRate)] : new Decimal(0);
      }
    }
  }
}
