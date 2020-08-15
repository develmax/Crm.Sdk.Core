using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.GetTimeZoneCodeByLocalizedNameRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetTimeZoneCodeByLocalizedNameResponse : OrganizationResponse
  {
    /// <summary>Gets the time zone code that has the requested localized name.</summary>
    /// <returns>Type: Returns_Int32The time zone code that has the requested localized name.</returns>
    public int TimeZoneCode
    {
      get
      {
        return this.Results.Contains(nameof (TimeZoneCode)) ? (int) this.Results[nameof (TimeZoneCode)] : 0;
      }
    }
  }
}
