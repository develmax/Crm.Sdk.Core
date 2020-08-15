using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveAuditDetailsRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAuditDetailsResponse : OrganizationResponse
  {
    /// <summary>Gets the details of the audited data changes.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.AuditDetail"></see>The audit details.</returns>
    public AuditDetail AuditDetail
    {
      get
      {
        return this.Results.Contains(nameof (AuditDetail)) ? (AuditDetail) this.Results[nameof (AuditDetail)] : (AuditDetail) null;
      }
    }
  }
}
