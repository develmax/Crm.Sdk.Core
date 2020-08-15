using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveDependenciesForUninstallRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveDependenciesForUninstallResponse : OrganizationResponse
  {
    /// <summary>Gets a collection of Dependency records where the DependentComponentObjectId and DependentComponentType attributes represent the components that can prevent you from deleting the solution.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>A collection of Dependency records where the DependentComponentObjectId and DependentComponentType attributes represent the components that can prevent you from deleting the solution.</returns>
    public EntityCollection EntityCollection
    {
      get
      {
        return this.Results.Contains(nameof (EntityCollection)) ? (EntityCollection) this.Results[nameof (EntityCollection)] : (EntityCollection) null;
      }
    }
  }
}
