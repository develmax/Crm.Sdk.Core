using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  validate the configuration of a windows_azure_service_bus solution’s service endpoint.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class TriggerServiceEndpointCheckRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ServiceEndpoint record that contains the configuration. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The entity reference of the service endpoint record.</returns>
    public EntityReference Entity
    {
      get
      {
        return this.Parameters.Contains(nameof (Entity)) ? (EntityReference) this.Parameters[nameof (Entity)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Entity)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the TriggerServiceEndpointCheck class.</summary>
    public TriggerServiceEndpointCheckRequest()
    {
      this.RequestName = "TriggerServiceEndpointCheck";
      this.Entity = (EntityReference) null;
    }
  }
}
