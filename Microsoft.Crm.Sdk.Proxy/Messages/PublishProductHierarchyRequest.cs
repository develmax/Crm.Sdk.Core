using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contain the data that is needed to publish a product family record and all its child records.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class PublishProductHierarchyRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target product family record that you want to publish along with its child records.</summary>
    /// <returns>Type <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target product family record that you want to publish along with its child records.</returns>
    public EntityReference Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.PublishProductHierarchyRequest"></see> class.</summary>
    public PublishProductHierarchyRequest()
    {
      this.RequestName = "PublishProductHierarchy";
      this.Target = (EntityReference) null;
    }
  }
}
