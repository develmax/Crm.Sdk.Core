using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveUnpublishedMultipleRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveUnpublishedMultipleResponse : OrganizationResponse
  {
    /// <summary>Gets the collection of records that satisfy the query in the request.</summary>
    /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The collection of records that satisfy the query in the request.</returns>
    public EntityCollection EntityCollection
    {
      get
      {
        return this.Results.Contains(nameof (EntityCollection)) ? (EntityCollection) this.Results[nameof (EntityCollection)] : (EntityCollection) null;
      }
    }
  }
}
