using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the time zone code for the specified localized time zone name.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetTimeZoneCodeByLocalizedNameRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the localized name to search for.</summary>
    /// <returns>Type: Returns_StringThe localized name to search for.</returns>
    public string LocalizedStandardName
    {
      get
      {
        return this.Parameters.Contains(nameof (LocalizedStandardName)) ? (string) this.Parameters[nameof (LocalizedStandardName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (LocalizedStandardName)] = (object) value;
      }
    }

    /// <summary>Gets or sets the locale ID.</summary>
    /// <returns>Type: Returns_Int32The locale ID. LCID</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.GetTimeZoneCodeByLocalizedNameRequest"></see> class.</summary>
    public GetTimeZoneCodeByLocalizedNameRequest()
    {
      this.RequestName = "GetTimeZoneCodeByLocalizedName";
      this.LocalizedStandardName = (string) null;
      this.LocaleId = 0;
    }
  }
}
