using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  convert the calendar rules to an array of available time blocks for the specified period.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExpandCalendarRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the calendar.</summary>
    /// <returns>Type: Returns_GuidThe ID of the calendar. This corresponds to the Calendar.CalendarId property, which is the primary key for the Calendar entity.</returns>
    public Guid CalendarId
    {
      get
      {
        return this.Parameters.Contains(nameof (CalendarId)) ? (Guid) this.Parameters[nameof (CalendarId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (CalendarId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the start of the period to expand.</summary>
    /// <returns>Type: Returns_DateTimeThe start of the time period to expand.</returns>
    public DateTime Start
    {
      get
      {
        return this.Parameters.Contains(nameof (Start)) ? (DateTime) this.Parameters[nameof (Start)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (Start)] = (object) value;
      }
    }

    /// <summary>Gets or sets the end of the time period to expand.</summary>
    /// <returns>Type: Returns_DateTimeThe end of the time period to expand.</returns>
    public DateTime End
    {
      get
      {
        return this.Parameters.Contains(nameof (End)) ? (DateTime) this.Parameters[nameof (End)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (End)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ExpandCalendarRequest"></see> class.</summary>
    public ExpandCalendarRequest()
    {
      this.RequestName = "ExpandCalendar";
      this.CalendarId = new Guid();
      this.Start = new DateTime();
      this.End = new DateTime();
    }
  }
}
