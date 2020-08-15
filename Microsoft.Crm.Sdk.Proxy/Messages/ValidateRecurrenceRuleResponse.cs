using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.ValidateRecurrenceRuleRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ValidateRecurrenceRuleResponse : OrganizationResponse
  {
    /// <summary>Gets the description.</summary>
    /// <returns>Type:  Returns_StringThe description.</returns>
    public string Description
    {
      get
      {
        return this.Results.Contains(nameof (Description)) ? (string) this.Results[nameof (Description)] : (string) null;
      }
    }
  }
}
