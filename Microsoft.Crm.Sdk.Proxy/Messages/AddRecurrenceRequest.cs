// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.AddRecurrenceRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  add recurrence information to an existing appointment.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddRecurrenceRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target, which is a recurring appointment master record to which the appointment is converted. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The target, which must be an entity reference for a RecurringAppointmentMaster entity.</returns>
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

    /// <summary>Gets or sets the ID of the appointment that needs to be converted into a recurring appointment. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the appointment that needs to be converted into a recurring appointment. This corresponds to the Appointment.ActivityId attribute, which is the primary key for the Appointment entity.</returns>
    public Guid AppointmentId
    {
      get
      {
        return this.Parameters.Contains(nameof (AppointmentId)) ? (Guid) this.Parameters[nameof (AppointmentId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (AppointmentId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AddRecurrenceRequest"></see> class.</summary>
    public AddRecurrenceRequest()
    {
      this.RequestName = "AddRecurrence";
      this.Target = (Entity) null;
      this.AppointmentId = new Guid();
    }
  }
}
