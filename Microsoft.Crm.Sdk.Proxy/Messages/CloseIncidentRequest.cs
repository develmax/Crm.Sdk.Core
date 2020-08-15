using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to close an incident (case).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CloseIncidentRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the incident resolution (case resolution) that is associated with the incident (case) to be closed. Required.</summary>
    /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The incident resolution (case resolution) that is associated with the incident (case) to be closed. This is an instance of the IncidentResolution class, which is a subclass of the Entity class.</returns>
    public Entity IncidentResolution
    {
      get
      {
        return this.Parameters.Contains(nameof (IncidentResolution)) ? (Entity) this.Parameters[nameof (IncidentResolution)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (IncidentResolution)] = (object) value;
      }
    }

    /// <summary>Gets or sets a status of the incident. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>The status of the incident.</returns>
    public OptionSetValue Status
    {
      get
      {
        return this.Parameters.Contains(nameof (Status)) ? (OptionSetValue) this.Parameters[nameof (Status)] : (OptionSetValue) null;
      }
      set
      {
        this.Parameters[nameof (Status)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CloseIncidentRequest"></see> class.</summary>
    public CloseIncidentRequest()
    {
      this.RequestName = "CloseIncident";
      this.IncidentResolution = (Entity) null;
      this.Status = (OptionSetValue) null;
    }
  }
}
