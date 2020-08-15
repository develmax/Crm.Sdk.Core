using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to renew an entitlement.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RenewEntitlementRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the id of the entitlement to renew.</summary>
    /// <returns>Type: Returns_Guid
    /// The Entitlement Id. This corresponds to the Entitlement.EntitlementId attribute, which is the primary key for the Entitlement entity.</returns>
    public Guid EntitlementId
    {
      get
      {
        return this.Parameters.Contains(nameof (EntitlementId)) ? (Guid) this.Parameters[nameof (EntitlementId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (EntitlementId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the StatusCode value for the renewed Entitlement.</summary>
    /// <returns>Type: Returns_Int32
    /// The status value for the renewed Entitlement.</returns>
    public int Status
    {
      get
      {
        return this.Parameters.Contains(nameof (Status)) ? (int) this.Parameters[nameof (Status)] : 0;
      }
      set
      {
        this.Parameters[nameof (Status)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RenewEntitlementRequest"></see> class.</summary>
    public RenewEntitlementRequest()
    {
      this.RequestName = "RenewEntitlement";
      this.EntitlementId = new Guid();
      this.Status = 0;
    }
  }
}
