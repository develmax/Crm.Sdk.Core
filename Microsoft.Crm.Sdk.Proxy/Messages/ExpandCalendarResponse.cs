using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.ExpandCalendarRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExpandCalendarResponse : OrganizationResponse
  {
    /// <summary>Gets a set of time blocks with appointment information.</summary>
    /// <returns>Type:<see cref="T:Microsoft.Crm.Sdk.Messages.TimeInfo"></see>The set of time blocks with appointment information.</returns>
    public TimeInfo[] result
    {
      get
      {
        return this.Results.Contains(nameof (result)) ? (TimeInfo[]) this.Results[nameof (result)] : (TimeInfo[]) null;
      }
    }
  }
}
