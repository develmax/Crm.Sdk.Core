// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.AddRecurrenceResponse
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.AddRecurrenceRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddRecurrenceResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the newly created recurring appointment.</summary>
    /// <returns>Type: Returns_GuidThe ID of the newly created recurring appointment. This corresponds to the RecurringAppointmentMaster.ActivityId attribute, which is the primary key for the RecurringAppointmentMaster entity.</returns>
    public Guid id
    {
      get
      {
        return this.Results.Contains(nameof (id)) ? (Guid) this.Results[nameof (id)] : new Guid();
      }
    }
  }
}
