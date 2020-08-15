using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  search multiple resources for available time block that match the specified parameters.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class QueryMultipleSchedulesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the IDs of the resources. Required.</summary>
    /// <returns>Type: Returns_GuidThe IDs of the resources. Each element of the <see cref="P:Microsoft.Crm.Sdk.Messages.QueryMultipleSchedulesRequest.ResourceIds"></see> array corresponds to the Resource.ResourceId attribute, which is the primary key for the Resource entity. The number of resource IDs and time codes must match.</returns>
    public Guid[] ResourceIds
    {
      get
      {
        return this.Parameters.Contains(nameof (ResourceIds)) ? (Guid[]) this.Parameters[nameof (ResourceIds)] : (Guid[]) null;
      }
      set
      {
        this.Parameters[nameof (ResourceIds)] = (object) value;
      }
    }

    /// <summary>Gets or sets the start of the time slot. Required.</summary>
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

    /// <summary>Gets or sets the end time for the scheduled block of time. Required.</summary>
    /// <returns>Type: Returns_DateTimeThe end time for the scheduled block of time.</returns>
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

    /// <summary>Gets or sets the time codes to look for: Available, Busy, Unavailable, or Filter, which correspond to the resource IDs. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.TimeCode"></see>The time codes to look for: Available, Busy, Unavailable, or Filter, which correspond to the resource IDs. The number of resource IDs and time codes must match.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.QueryMultipleSchedulesRequest"></see> class.</summary>
    public QueryMultipleSchedulesRequest()
    {
      this.RequestName = "QueryMultipleSchedules";
      this.ResourceIds = (Guid[]) null;
      this.Start = new DateTime();
      this.End = new DateTime();
      this.TimeCodes = (TimeCode[]) null;
    }
  }
}
