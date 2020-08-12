// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RescheduleRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to reschedule an appointment, recurring appointment, or service appointment (service activity).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RescheduleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target of the reschedule operation.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The the target of the reschedule operation. This is an entity reference for an entity that supports this message. For a list of supported entity types, see <see cref="T:Microsoft.Crm.Sdk.Messages.RescheduleRequest"></see>.</returns>
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

    /// <returns>Type: Returns_Boolean.</returns>
    public bool ReturnNotifications
    {
      get
      {
        return this.Parameters.Contains(nameof (ReturnNotifications)) && (bool) this.Parameters[nameof (ReturnNotifications)];
      }
      set
      {
        this.Parameters[nameof (ReturnNotifications)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RescheduleRequest"></see> class.</summary>
    public RescheduleRequest()
    {
      this.RequestName = "Reschedule";
      this.Target = (Entity) null;
    }
  }
}
