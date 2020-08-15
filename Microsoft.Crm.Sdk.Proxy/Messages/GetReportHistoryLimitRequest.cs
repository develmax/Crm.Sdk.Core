using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the history limit for a report.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetReportHistoryLimitRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the report. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the report. This corresponds to the Report.ReportId property, which is the primary key for the Report entity.</returns>
    public Guid ReportId
    {
      get
      {
        return this.Parameters.Contains(nameof (ReportId)) ? (Guid) this.Parameters[nameof (ReportId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ReportId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.GetReportHistoryLimitRequest"></see> class.</summary>
    public GetReportHistoryLimitRequest()
    {
      this.RequestName = "GetReportHistoryLimit";
      this.ReportId = new Guid();
    }
  }
}
