using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to delete instances of a recurring appointment master that have an “Open” state.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class DeleteOpenInstancesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target record for the operation. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The record that defines the instances to delete. This must be an entity reference for a RecurringAppointmentMaster entity.</returns>
    public Entity Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (Entity) this.Parameters[nameof (Target)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Gets or sets the end date for the recurring appointment series. Required.</summary>
    /// <returns>Type: Returns_DateTimeThe end date for the appointment series.</returns>
    public DateTime SeriesEndDate
    {
      get
      {
        return this.Parameters.Contains(nameof (SeriesEndDate)) ? (DateTime) this.Parameters[nameof (SeriesEndDate)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (SeriesEndDate)] = (object) value;
      }
    }

    /// <summary>Gets or sets the value to be used to set the status of appointment instances that have already passed. Required.</summary>
    /// <returns>Type: Returns_DateTimeThe status code. The value should be one of the option set values for the RecurringAppointmentMaster.StateCode attribute. For more information, see the metadata for this entity. metadata_browser</returns>
    public int StateOfPastInstances
    {
      get
      {
        return this.Parameters.Contains(nameof (StateOfPastInstances)) ? (int) this.Parameters[nameof (StateOfPastInstances)] : 0;
      }
      set
      {
        this.Parameters[nameof (StateOfPastInstances)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.DeleteOpenInstancesRequest"></see> class.</summary>
    public DeleteOpenInstancesRequest()
    {
      this.RequestName = "DeleteOpenInstances";
      this.Target = (Entity) null;
      this.SeriesEndDate = new DateTime();
      this.StateOfPastInstances = 0;
    }
  }
}
