using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the  <see cref="T:Microsoft.Crm.Sdk.Messages.LocalTimeFromUtcTimeRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class LocalTimeFromUtcTimeResponse : OrganizationResponse
  {
    /// <summary>Gets the time that is represented as local time.</summary>
    /// <returns>Type: Returns_DateTimeThe time that is represented as local time.</returns>
    public DateTime LocalTime
    {
      get
      {
        return this.Results.Contains(nameof (LocalTime)) ? (DateTime) this.Results[nameof (LocalTime)] : new DateTime();
      }
    }
  }
}
