using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  search the specified resource for an available time block that matches the specified parameters.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class QueryScheduleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the resource.</summary>
    /// <returns>Type: Returns_GuidThe ID of the resource. This corresponds to the Resource.ResourceId attribute, which is the primary key for the Resource entity.</returns>
    public Guid ResourceId
    {
      get
      {
        return this.Parameters.Contains(nameof (ResourceId)) ? (Guid) this.Parameters[nameof (ResourceId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ResourceId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the start of the time slot.</summary>
    /// <returns>Type: Returns_DateTimeThe start of the time slot.</returns>
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

    /// <summary>Gets or sets the end of the time slot.</summary>
    /// <returns>Type: Returns_DateTimeThe end of the time slot.</returns>
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

    /// <summary>Gets or sets the time codes to look for: Available, Busy, Unavailable, or Filter.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.TimeCode"></see>The time codes to look for: Available, Busy, Unavailable, or Filter.</returns>
    public TimeCode[] TimeCodes
    {
      get
      {
        return this.Parameters.Contains(nameof (TimeCodes)) ? (TimeCode[]) this.Parameters[nameof (TimeCodes)] : (TimeCode[]) null;
      }
      set
      {
        this.Parameters[nameof (TimeCodes)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.QueryScheduleRequest"></see> class.</summary>
    public QueryScheduleRequest()
    {
      this.RequestName = "QuerySchedule";
      this.ResourceId = new Guid();
      this.Start = new DateTime();
      this.End = new DateTime();
      this.TimeCodes = (TimeCode[]) null;
    }
  }
}
