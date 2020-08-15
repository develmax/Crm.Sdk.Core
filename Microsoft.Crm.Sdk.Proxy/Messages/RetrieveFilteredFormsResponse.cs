using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveFilteredFormsRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveFilteredFormsResponse : OrganizationResponse
  {
    /// <summary>Gets a collection of SystemForm entity references.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see>A collection of SystemForm entity references.</returns>
    public EntityReferenceCollection SystemForms
    {
      get
      {
        return this.Results.Contains(nameof (SystemForms)) ? (EntityReferenceCollection) this.Results[nameof (SystemForms)] : (EntityReferenceCollection) null;
      }
    }
  }
}
