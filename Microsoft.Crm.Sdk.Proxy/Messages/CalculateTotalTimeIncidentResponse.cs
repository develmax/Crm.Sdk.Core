using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.CalculateTotalTimeIncidentRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CalculateTotalTimeIncidentResponse : OrganizationResponse
  {
    /// <summary>Gets the total time, in minutes that you use when you work on an incident (case).</summary>
    /// <returns>Type: Returns_Int64The total time, in minutes that you use when you work on an incident (case). </returns>
    public long TotalTime
    {
      get
      {
        return this.Results.Contains(nameof (TotalTime)) ? (long) this.Results[nameof (TotalTime)] : 0L;
      }
    }
  }
}
