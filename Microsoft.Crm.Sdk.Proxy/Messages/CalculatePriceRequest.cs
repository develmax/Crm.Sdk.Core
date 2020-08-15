using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to calculate price in an opportunity, quote, order, and invoice. This is used internally for custom pricing calculation when the default system pricing is overridden.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CalculatePriceRequest : OrganizationRequest
  {
    /// <summary>internal</summary>
    /// <returns>Type <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see></returns>
    public EntityReference Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type Returns_Guid</returns>
    public Guid ParentId
    {
      get
      {
        return this.Parameters.Contains(nameof (ParentId)) ? (Guid) this.Parameters[nameof (ParentId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ParentId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CalculatePriceRequest"></see>.</summary>
    public CalculatePriceRequest()
    {
      this.RequestName = "CalculatePrice";
      this.Target = (EntityReference) null;
    }
  }
}
