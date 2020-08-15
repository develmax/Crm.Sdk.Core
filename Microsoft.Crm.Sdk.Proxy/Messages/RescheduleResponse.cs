using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RescheduleRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RescheduleResponse : OrganizationResponse
  {
    /// <summary>Gets the validation results for the appointment, recurring appointment master, or service appointment (service activity).</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.ValidationResult"></see>The validation results for the appointment, recurring appointment master, or service appointment (service activity).</returns>
    public ValidationResult ValidationResult
    {
      get
      {
        return this.Results.Contains(nameof (ValidationResult)) ? (ValidationResult) this.Results[nameof (ValidationResult)] : (ValidationResult) null;
      }
    }

    /// <returns>Type: Returns_Object.</returns>
    public object Notifications
    {
      get
      {
        return this.Results.Contains(nameof (Notifications)) ? this.Results[nameof (Notifications)] : (object) null;
      }
    }
  }
}
