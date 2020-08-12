// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveMissingDependenciesResponse
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveMissingDependenciesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveMissingDependenciesResponse : OrganizationResponse
  {
    /// <summary>Gets an entity collection that represents the solution components that the solution requires in the target system.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>An entity collection that represents the solution components that the solution requires in the target system.</returns>
    public EntityCollection EntityCollection
    {
      get
      {
        return this.Results.Contains(nameof (EntityCollection)) ? (EntityCollection) this.Results[nameof (EntityCollection)] : (EntityCollection) null;
      }
    }
  }
}
