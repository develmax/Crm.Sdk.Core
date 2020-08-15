using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveDuplicatesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveDuplicatesResponse : OrganizationResponse
  {
    /// <summary>Gets a collection of duplicate entity instances.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The collection of duplicate entity instances.</returns>
    public EntityCollection DuplicateCollection
    {
      get
      {
        return this.Results.Contains(nameof (DuplicateCollection)) ? (EntityCollection) this.Results[nameof (DuplicateCollection)] : (EntityCollection) null;
      }
    }
  }
}
