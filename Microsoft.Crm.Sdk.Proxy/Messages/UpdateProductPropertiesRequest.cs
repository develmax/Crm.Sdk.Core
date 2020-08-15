using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to update values of the property instances (dynamic property instances) for a product added to an opportunity, quote, order, or invoice.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class UpdateProductPropertiesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the property instances (dynamic property instances) for a product to be updated.</summary>
    /// <returns>Type <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The property instances (dynamic property instances) for a product to be updated.</returns>
    public EntityCollection PropertyInstanceList
    {
      get
      {
        return this.Parameters.Contains(nameof (PropertyInstanceList)) ? (EntityCollection) this.Parameters[nameof (PropertyInstanceList)] : (EntityCollection) null;
      }
      set
      {
        this.Parameters[nameof (PropertyInstanceList)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.UpdateProductPropertiesRequest"></see> class.</summary>
    public UpdateProductPropertiesRequest()
    {
      this.RequestName = "UpdateProductProperties";
      this.PropertyInstanceList = (EntityCollection) null;
    }
  }
}
