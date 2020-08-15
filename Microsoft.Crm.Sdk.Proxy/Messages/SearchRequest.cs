using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data needed to search for available time slots that fulfill the specified appointment request.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SearchRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the appointment request.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.AppointmentRequest"></see>The appointment request.</returns>
    public AppointmentRequest AppointmentRequest
    {
      get
      {
        return this.Parameters.Contains(nameof (AppointmentRequest)) ? (AppointmentRequest) this.Parameters[nameof (AppointmentRequest)] : (AppointmentRequest) null;
      }
      set
      {
        this.Parameters[nameof (AppointmentRequest)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.SearchRequest"></see> class.</summary>
    public SearchRequest()
    {
      this.RequestName = "Search";
      this.AppointmentRequest = (AppointmentRequest) null;
    }
  }
}
