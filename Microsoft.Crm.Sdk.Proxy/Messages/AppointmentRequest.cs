using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Provides the details of an appointment request for the <see cref="T:Microsoft.Crm.Sdk.Messages.SearchRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AppointmentRequest : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AppointmentRequest"></see> class.</summary>
    public AppointmentRequest()
    {
      this.SearchWindowStart = new DateTime?(new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc));
      this.SearchWindowEnd = new DateTime?(new DateTime(9999, 12, 30, 23, 59, 59, DateTimeKind.Utc));
      this.AppointmentsToIgnore = new Microsoft.Crm.Sdk.Messages.AppointmentsToIgnore[0];
      this.RequiredResources = new RequiredResource[0];
      this.Constraints = new ConstraintRelation[0];
      this.Objectives = new ObjectiveRelation[0];
      this.Sites = new Guid[0];
    }

    /// <summary>Gets or sets the ID of the service to search for.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the service, which corresponds to the Service.ServiceId attribute, which is the primary key for the Service entity.</returns>
    [DataMember]
    public Guid ServiceId { get; set; }

    /// <summary>Gets or sets the time offset in minutes, from midnight, when the first occurrence of the appointment can take place.</summary>
    /// <returns>Type: Returns_Int32The time offset in minutes.</returns>
    [DataMember]
    public int AnchorOffset { get; set; }

    /// <summary>Gets or sets the time zone code of the user who is requesting the appointment.</summary>
    /// <returns>Type: Returns_Int32
    /// The time zone code of the user who is requesting the appointment.</returns>
    [DataMember]
    public int UserTimeZoneCode { get; set; }

    /// <summary>Gets or sets the time, in minutes, for which the appointment recurrence is valid.</summary>
    /// <returns>Type: Returns_Int32
    /// The time, in minutes, for which the appointment recurrence is valid.</returns>
    [DataMember]
    public int RecurrenceDuration { get; set; }

    /// <summary>Gets or sets a value to override the time zone that is specified by the <see cref="P:Microsoft.Crm.Sdk.Messages.AppointmentRequest.UserTimeZoneCode"></see> property.</summary>
    /// <returns>Type: Returns_Int32
    /// A value to override the time zone that is specified by the <see cref="P:Microsoft.Crm.Sdk.Messages.AppointmentRequest.UserTimeZoneCode"></see> property.</returns>
    [DataMember]
    public int RecurrenceTimeZoneCode { get; set; }

    /// <summary>Gets or sets the appointments to ignore in the search for possible appointments.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.AppointmentsToIgnore"></see>The appointments to ignore in the search for possible appointments.</returns>
    [DataMember]
    public Microsoft.Crm.Sdk.Messages.AppointmentsToIgnore[] AppointmentsToIgnore { get; set; }

    /// <summary>Gets or sets the resources that are needed for this appointment.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.RequiredResource"></see>
    /// The resources that are needed for this appointment.</returns>
    [DataMember]
    public RequiredResource[] RequiredResources { get; set; }

    /// <summary>Gets or sets the date and time to begin the search.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_DateTime&gt;
    /// The date and time to begin the search.</returns>
    [DataMember]
    public DateTime? SearchWindowStart { get; set; }

    /// <summary>Gets or sets the date and time to end the search.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_DateTime&gt;
    /// The date and time to end the search.</returns>
    [DataMember]
    public DateTime? SearchWindowEnd { get; set; }

    /// <summary>Gets or sets the date and time for the first possible instance of the appointment.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_DateTime&gt;
    /// The date and time for the first possible instance of the appointment.</returns>
    [DataMember]
    public DateTime? SearchRecurrenceStart { get; set; }

    /// <summary>Gets or sets the recurrence rule for appointment recurrence.</summary>
    /// <returns>Type: Returns_String
    /// The recurrence rule.Example: "FREQ=WEEKLY;BYDAY=MO;INTERVAL=60";Where: BYDAY means which day = MO,TU,THINTERVAL is an integer valueFREQ="DAILY","WEEKLY"This is similar to the   Recurrence Pattern in Asynchronous Job Execution/html/abfb5df5-138b-4c7e-8730-4903aa2be3d3.htm.</returns>
    [DataMember]
    public string SearchRecurrenceRule { get; set; }

    /// <summary>Gets or sets the appointment duration, in minutes.</summary>
    /// <returns>Type: Returns_Int32
    /// The appointment duration, in minutes.</returns>
    [DataMember]
    public int Duration { get; set; }

    /// <summary>Gets or sets any additional constraints.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.ConstraintRelation"></see>
    /// Additional constraints for the appointment.</returns>
    [DataMember]
    public ConstraintRelation[] Constraints { get; set; }

    /// <summary>Gets or sets the scheduling strategy that overrides the default constraints.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.ObjectiveRelation"></see>
    /// The scheduling strategy that overrides the default constraints.</returns>
    [DataMember]
    public ObjectiveRelation[] Objectives { get; set; }

    /// <summary>Gets or sets the direction of the search.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.SearchDirection"></see>
    /// The search direction.</returns>
    [DataMember]
    public SearchDirection Direction { get; set; }

    /// <summary>Gets or sets the number of results to be returned from the search request.</summary>
    /// <returns>Type: Returns_Int32
    /// The number of results to be returned from the search request.</returns>
    [DataMember]
    public int NumberOfResults { get; set; }

    /// <summary>Gets or sets the sites where the requested appointment can take place.</summary>
    /// <returns>Type: Returns_Guid[]
    /// The array of site IDs,  where the requested appointment can take place. The site ID corresponds to the Site.SiteId attribute, which is the primary key for the Site entity.</returns>
    [DataMember]
    public Guid[] Sites { get; set; }

    /// <summary>ExtensionData</summary>
    /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
    public ExtensionDataObject ExtensionData
    {
      get
      {
        return this._extensionDataObject;
      }
      set
      {
        this._extensionDataObject = value;
      }
    }
  }
}
