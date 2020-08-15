using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveAttributeChangeHistoryRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAttributeChangeHistoryResponse : OrganizationResponse
  {
    /// <summary>Gets the attribute change history that results in a collection of audit details.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.AuditDetailCollection"></see>The collection of audit details.</returns>
    public AuditDetailCollection AuditDetailCollection
    {
      get
      {
        return this.Results.Contains(nameof (AuditDetailCollection)) ? (AuditDetailCollection) this.Results[nameof (AuditDetailCollection)] : (AuditDetailCollection) null;
      }
    }
  }
}
