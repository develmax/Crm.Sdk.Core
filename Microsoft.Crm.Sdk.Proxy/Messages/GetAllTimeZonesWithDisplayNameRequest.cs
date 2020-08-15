using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve all the time zone definitions for the specified locale and to return only the display name attribute.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetAllTimeZonesWithDisplayNameRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the locale ID. Required.</summary>
    /// <returns>Type: Returns_Int32The locale ID.</returns>
    public int LocaleId
    {
      get
      {
        return this.Parameters.Contains(nameof (LocaleId)) ? (int) this.Parameters[nameof (LocaleId)] : 0;
      }
      set
      {
        this.Parameters[nameof (LocaleId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.GetAllTimeZonesWithDisplayNameRequest"></see> class.</summary>
    public GetAllTimeZonesWithDisplayNameRequest()
    {
      this.RequestName = "GetAllTimeZonesWithDisplayName";
      this.LocaleId = 0;
    }
  }
}
