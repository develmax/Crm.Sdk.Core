using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the full audit details from an Audit record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAuditDetailsRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the Audit record to retrieve. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the record to retrieve.</returns>
    public Guid AuditId
    {
      get
      {
        return this.Parameters.Contains(nameof (AuditId)) ? (Guid) this.Parameters[nameof (AuditId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (AuditId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveAuditDetailsRequest"></see> class.</summary>
    public RetrieveAuditDetailsRequest()
    {
      this.RequestName = "RetrieveAuditDetails";
      this.AuditId = new Guid();
    }
  }
}
