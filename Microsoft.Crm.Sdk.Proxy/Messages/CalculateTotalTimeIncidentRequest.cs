using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  calculate the total time, in minutes, that you used while you worked on an incident (case).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CalculateTotalTimeIncidentRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the incident (case). Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the incident (case) that corresponds to the IncidentId.IncidentId attribute, which is the primary key for the Incident entity.</returns>
    public Guid IncidentId
    {
      get
      {
        return this.Parameters.Contains(nameof (IncidentId)) ? (Guid) this.Parameters[nameof (IncidentId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (IncidentId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CalculateTotalTimeIncidentRequest"></see> class.</summary>
    public CalculateTotalTimeIncidentRequest()
    {
      this.RequestName = "CalculateTotalTimeIncident";
      this.IncidentId = new Guid();
    }
  }
}
