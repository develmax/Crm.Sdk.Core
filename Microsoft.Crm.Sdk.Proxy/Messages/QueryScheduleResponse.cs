using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains response from <see cref="T:Microsoft.Crm.Sdk.Messages.QueryScheduleRequest"></see>.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class QueryScheduleResponse : OrganizationResponse
  {
    /// <summary>Gets the results of the search, a set of possible time slots for the resource.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.TimeInfo"></see>The results of the search. Contains an array of possible time slots for each of the resource IDs specified in the request class.</returns>
    public TimeInfo[] TimeInfos
    {
      get
      {
        return this.Results.Contains(nameof (TimeInfos)) ? (TimeInfo[]) this.Results[nameof (TimeInfos)] : (TimeInfo[]) null;
      }
    }
  }
}
