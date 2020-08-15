using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.UtcTimeFromLocalTimeRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class UtcTimeFromLocalTimeResponse : OrganizationResponse
  {
    /// <summary>Gets the local time and expresses it in Coordinated Universal Time (UTC) time.</summary>
    /// <returns>Type: Returns_DateTimeThe local time expressed as Coordinated Universal Time (UTC) time.</returns>
    public DateTime UtcTime
    {
      get
      {
        return this.Results.Contains(nameof (UtcTime)) ? (DateTime) this.Results[nameof (UtcTime)] : new DateTime();
      }
    }
  }
}
