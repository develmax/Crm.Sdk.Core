using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to verify that an appointment or service appointment (service activity) has valid available resources for the activity, duration, and site, as appropriate.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ValidateRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the activities to validate.</summary>
    /// <returns><see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The activities to validate.</returns>
    public EntityCollection Activities
    {
      get
      {
        return this.Parameters.Contains(nameof (Activities)) ? (EntityCollection) this.Parameters[nameof (Activities)] : (EntityCollection) null;
      }
      set
      {
        this.Parameters[nameof (Activities)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ValidateRequest"></see> class.</summary>
    public ValidateRequest()
    {
      this.RequestName = "Validate";
      this.Activities = (EntityCollection) null;
    }
  }
}
