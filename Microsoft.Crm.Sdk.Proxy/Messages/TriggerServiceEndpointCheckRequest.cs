// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.TriggerServiceEndpointCheckRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  validate the configuration of a windows_azure_service_bus solution’s service endpoint.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class TriggerServiceEndpointCheckRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ServiceEndpoint record that contains the configuration. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The entity reference of the service endpoint record.</returns>
    public EntityReference Entity
    {
      get
      {
        return this.Parameters.Contains(nameof (Entity)) ? (EntityReference) this.Parameters[nameof (Entity)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Entity)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the TriggerServiceEndpointCheck class.</summary>
    public TriggerServiceEndpointCheckRequest()
    {
      this.RequestName = "TriggerServiceEndpointCheck";
      this.Entity = (EntityReference) null;
    }
  }
}
