using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  recalculate system-computed values for rollup fields in the goal hierarchy.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RecalculateRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target record for the recalculate operation. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target record for the recalculate operation. This must be an entity reference for the Goal entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RecalculateRequest"></see> class.</summary>
    public RecalculateRequest()
    {
      this.RequestName = "Recalculate";
      this.Target = (EntityReference) null;
    }
  }
}
