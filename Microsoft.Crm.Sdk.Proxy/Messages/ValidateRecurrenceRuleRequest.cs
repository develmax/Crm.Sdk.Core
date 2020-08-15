using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  validate a rule for a recurring appointment.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ValidateRecurrenceRuleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the recurrence rule record to validate.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The recurrence rule record to validate. This is an instance of the RecurrenceRule entity. </returns>
    public Entity Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (Entity) this.Parameters[nameof (Target)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ValidateRecurrenceRuleRequest"></see> class.</summary>
    public ValidateRecurrenceRuleRequest()
    {
      this.RequestName = "ValidateRecurrenceRule";
      this.Target = (Entity) null;
    }
  }
}
