using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Specifies a set of time blocks with appointment information.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class TimeInfo : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Gets or sets the start time for the block.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_DateTime&gt;
    /// The start time for the block.</returns>
    [DataMember]
    public DateTime? Start { get; set; }

    /// <summary>Gets or sets the end time for the block.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_DateTime&gt;
    /// The end time for the block.</returns>
    [DataMember]
    public DateTime? End { get; set; }

    /// <summary>Gets or sets the value that indicates whether the time block is available, busy, filtered or unavailable.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.TimeCode"></see>The time code.</returns>
    [DataMember]
    public TimeCode TimeCode { get; set; }

    /// <summary>Gets or sets information about the time block such as whether it is an appointment, break, or holiday.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.SubCode"></see>The information about the time block.</returns>
    [DataMember]
    public SubCode SubCode { get; set; }

    /// <summary>Gets or sets the ID of the record referred to in the time block.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the record, which corresponds to the primary key for the entity.</returns>
    [DataMember]
    public Guid SourceId { get; set; }

    /// <summary>Gets or sets the ID of the calendar for this block of time.</summary>
    /// <returns>Type: Returns_Guid
    /// The the ID of the calendar for this block of time, which corresponds to the Calendar.CalendarId attribute, which is the primary key for the Calendar entity.</returns>
    [DataMember]
    public Guid CalendarId { get; set; }

    /// <summary>Gets or sets the type of entity referred to in the time block.</summary>
    /// <returns>Type: Returns_Int32
    /// The entity type code.</returns>
    [DataMember]
    public int SourceTypeCode { get; set; }

    /// <summary>Gets or sets the value that indicates whether the block of time refers to an activity.</summary>
    /// <returns>Type: Returns_Booleantrue if the block of time refers to an activity; otherwise, false.</returns>
    [DataMember]
    public bool IsActivity { get; set; }

    /// <summary>Gets or sets the status of the activity.</summary>
    /// <returns>Type: Returns_Int32The activity status code.</returns>
    [DataMember]
    public int ActivityStatusCode { get; set; }

    /// <summary>Gets or sets the amount of effort required for this block of time.</summary>
    /// <returns>Type: Returns_Double
    /// The amount of effort required for this block of time.</returns>
    [DataMember]
    public double Effort { get; set; }

    /// <summary>Gets or sets the display text shown in the calendar for the time block.</summary>
    /// <returns>Type: Returns_StringThe display text shown in the calendar for the time block..</returns>
    [DataMember]
    public string DisplayText { get; set; }

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
