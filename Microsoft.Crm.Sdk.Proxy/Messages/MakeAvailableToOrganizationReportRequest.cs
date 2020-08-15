using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.UpdateRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class MakeAvailableToOrganizationReportRequest : OrganizationRequest
  {
    /// <summary>deprecated</summary>
    /// <returns>Type: Returns_Guid</returns>
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

    /// <summary>deprecated</summary>
    public MakeAvailableToOrganizationReportRequest()
    {
      this.RequestName = "MakeAvailableToOrganizationReport";
      this.ReportId = new Guid();
    }
  }
}
