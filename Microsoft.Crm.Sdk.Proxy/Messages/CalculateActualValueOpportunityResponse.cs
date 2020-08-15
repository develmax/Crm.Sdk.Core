using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.CalculateActualValueOpportunityRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CalculateActualValueOpportunityResponse : OrganizationResponse
  {
    /// <summary>Gets the actual value of an opportunity.</summary>
    /// <returns>Type: Returns_DecimalThe actual value of an opportunity.</returns>
    public Decimal Value
    {
      get
      {
        return this.Results.Contains(nameof (Value)) ? (Decimal) this.Results[nameof (Value)] : new Decimal(0);
      }
    }
  }
}
