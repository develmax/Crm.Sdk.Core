using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.BookRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class BookResponse : OrganizationResponse
  {
    /// <summary>Gets the appointment validation results.</summary>
    /// <returns>Type:<see cref="T:Microsoft.Crm.Sdk.Messages.ValidationResult"></see>The appointment validation results.</returns>
    public ValidationResult ValidationResult
    {
      get
      {
        return this.Results.Contains(nameof (ValidationResult)) ? (ValidationResult) this.Results[nameof (ValidationResult)] : (ValidationResult) null;
      }
    }

    /// <returns>Returns Returns_Object.</returns>
    public object Notifications
    {
      get
      {
        return this.Results.Contains(nameof (Notifications)) ? this.Results[nameof (Notifications)] : (object) null;
      }
    }
  }
}
