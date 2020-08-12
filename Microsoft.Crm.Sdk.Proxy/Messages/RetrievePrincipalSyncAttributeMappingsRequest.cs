// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrievePrincipalSyncAttributeMappingsRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrievePrincipalSyncAttributeMappingsRequest : OrganizationRequest
  {
    public EntityReference Principal
    {
      get
      {
        return this.Parameters.Contains(nameof (Principal)) ? (EntityReference) this.Parameters[nameof (Principal)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Principal)] = (object) value;
      }
    }

    public RetrievePrincipalSyncAttributeMappingsRequest()
    {
      this.RequestName = "RetrievePrincipalSyncAttributeMappings";
      this.Principal = (EntityReference) null;
    }
  }
}
