using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveDependenciesForDeleteRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveDependenciesForDeleteResponse : OrganizationResponse
  {
    /// <summary>Gets a collection of Dependency records where the DependentComponentObjectId and DependentComponentType attributes represent those components that can prevent the solution component from being deleted.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The collection of Dependency records where the DependentComponentObjectId and DependentComponentType attributes represent those components that can prevent the solution component from being deleted..</returns>
    public EntityCollection EntityCollection
    {
      get
      {
        return this.Results.Contains(nameof (EntityCollection)) ? (EntityCollection) this.Results[nameof (EntityCollection)] : (EntityCollection) null;
      }
    }
  }
}
