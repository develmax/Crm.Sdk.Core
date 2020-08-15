using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to apply the active routing rule to an incident.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ApplyRoutingRuleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target incident to apply the routing rule to. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target incident to apply the routing rule to.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ApplyRoutingRuleRequest"></see> class.</summary>
    public ApplyRoutingRuleRequest()
    {
      this.RequestName = "ApplyRoutingRule";
      this.Target = (EntityReference) null;
    }
  }
}
