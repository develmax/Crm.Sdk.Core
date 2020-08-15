using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to set the state of an opportunity to Won.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class WinOpportunityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the opportunity close activity associated with this state change. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The opportunity close activity associated with this state change. This must be an instance of the OpportunityClose class, which is a subclass of the Entity class.</returns>
    public Entity OpportunityClose
    {
      get
      {
        return this.Parameters.Contains(nameof (OpportunityClose)) ? (Entity) this.Parameters[nameof (OpportunityClose)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (OpportunityClose)] = (object) value;
      }
    }

    /// <summary>Gets or sets a new status of the opportunity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>The status of the opportunity.</returns>
    public OptionSetValue Status
    {
      get
      {
        return this.Parameters.Contains(nameof (Status)) ? (OptionSetValue) this.Parameters[nameof (Status)] : (OptionSetValue) null;
      }
      set
      {
        this.Parameters[nameof (Status)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.WinOpportunityRequest"></see> class.</summary>
    public WinOpportunityRequest()
    {
      this.RequestName = "WinOpportunity";
      this.OpportunityClose = (Entity) null;
      this.Status = (OptionSetValue) null;
    }
  }
}
