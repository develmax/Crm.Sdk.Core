using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains data that is needed to retrieve all the property instances (dynamic property instances) for a product added to an opportunity, quote, order, or invoice.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveProductPropertiesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the product record for which you want to retrieve all the property instances (dynamic property instances).</summary>
    /// <returns>Type <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>Product record for which you want to retrieve all the property instances (dynamic property instances).</returns>
    public EntityReference ParentObject
    {
      get
      {
        return this.Parameters.Contains(nameof (ParentObject)) ? (EntityReference) this.Parameters[nameof (ParentObject)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (ParentObject)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveProductPropertiesRequest"></see> class.</summary>
    public RetrieveProductPropertiesRequest()
    {
      this.RequestName = "RetrieveProductProperties";
      this.ParentObject = (EntityReference) null;
    }
  }
}
