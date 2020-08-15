using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveLocLabelsRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveLocLabelsResponse : OrganizationResponse
  {
    /// <summary>Gets the label for the requested entity attribute.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The label for the requested entity attribute.</returns>
    public Label Label
    {
      get
      {
        return this.Results.Contains(nameof (Label)) ? (Label) this.Results[nameof (Label)] : (Label) null;
      }
    }
  }
}
