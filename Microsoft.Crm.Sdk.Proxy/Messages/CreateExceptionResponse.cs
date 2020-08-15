using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.CreateExceptionRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CreateExceptionResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the exception appointment.</summary>
    /// <returns>Type: Returns_GuidThe ID of the exception appointment. This corresponds to the Appointment. AppointmentId attribute, which is the primary key for the Appointment entity.</returns>
    public Guid id
    {
      get
      {
        return this.Results.Contains(nameof (id)) ? (Guid) this.Results[nameof (id)] : new Guid();
      }
    }
  }
}
