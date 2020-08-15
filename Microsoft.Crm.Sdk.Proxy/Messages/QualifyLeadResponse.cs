using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.QualifyLeadRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class QualifyLeadResponse : OrganizationResponse
  {
    /// <summary>Gets the collection of references to the newly created account, contact, and opportunity records. </summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see>The collection of references to the newly created account, contact, and opportunity records.</returns>
    public EntityReferenceCollection CreatedEntities
    {
      get
      {
        return this.Results.Contains(nameof (CreatedEntities)) ? (EntityReferenceCollection) this.Results[nameof (CreatedEntities)] : (EntityReferenceCollection) null;
      }
    }
  }
}
