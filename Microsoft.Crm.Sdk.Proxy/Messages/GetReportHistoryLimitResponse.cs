using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.GetReportHistoryLimitRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetReportHistoryLimitResponse : OrganizationResponse
  {
    /// <summary>Gets the history limit for a report.</summary>
    /// <returns>Type: Returns_Int32</returns>
    public int HistoryLimit
    {
      get
      {
        return this.Results.Contains(nameof (HistoryLimit)) ? (int) this.Results[nameof (HistoryLimit)] : 0;
      }
    }
  }
}
