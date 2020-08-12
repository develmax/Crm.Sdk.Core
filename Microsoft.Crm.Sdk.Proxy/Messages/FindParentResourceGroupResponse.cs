// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.FindParentResourceGroupResponse
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.FindParentResourceGroupRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class FindParentResourceGroupResponse : OrganizationResponse
  {
    /// <summary>Gets a value that indicates whether the parent resource group was found.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether the parent resource group was found. true if the parent resource group was found; otherwise, false.</returns>
    public bool result
    {
      get
      {
        return this.Results.Contains(nameof (result)) && (bool) this.Results[nameof (result)];
      }
    }
  }
}
