using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.ValidateRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ValidateResponse : OrganizationResponse
  {
    /// <summary>Gets the results of the validate operation.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.ValidationResult"></see>The results of the validate operation.</returns>
    public ValidationResult[] Result
    {
      get
      {
        return this.Results.Contains(nameof (Result)) ? (ValidationResult[]) this.Results[nameof (Result)] : (ValidationResult[]) null;
      }
    }
  }
}
