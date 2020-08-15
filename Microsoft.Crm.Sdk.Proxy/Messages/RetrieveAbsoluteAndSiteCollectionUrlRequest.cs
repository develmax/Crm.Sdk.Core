using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the absolute URL and the site collection URL for a pn_SharePoint_short location record in pn_microsoftcrm.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAbsoluteAndSiteCollectionUrlRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target for which the data is to be retrieved. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target for which the data is to be retrieved. This property must be a reference to a record of the SharepointDocumentLocation entity or the SharepointSite entity type.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveAbsoluteAndSiteCollectionUrlRequest"></see> class.</summary>
    public RetrieveAbsoluteAndSiteCollectionUrlRequest()
    {
      this.RequestName = "RetrieveAbsoluteAndSiteCollectionUrl";
      this.Target = (EntityReference) null;
    }
  }
}
