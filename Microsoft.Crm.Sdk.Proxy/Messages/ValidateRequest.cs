// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ValidateRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to verify that an appointment or service appointment (service activity) has valid available resources for the activity, duration, and site, as appropriate.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ValidateRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the activities to validate.</summary>
    /// <returns><see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The activities to validate.</returns>
    public EntityCollection Activities
    {
      get
      {
        return this.Parameters.Contains(nameof (Activities)) ? (EntityCollection) this.Parameters[nameof (Activities)] : (EntityCollection) null;
      }
      set
      {
        this.Parameters[nameof (Activities)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ValidateRequest"></see> class.</summary>
    public ValidateRequest()
    {
      this.RequestName = "Validate";
      this.Activities = (EntityCollection) null;
    }
  }
}
