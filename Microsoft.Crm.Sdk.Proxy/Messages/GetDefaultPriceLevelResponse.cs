// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.GetDefaultPriceLevelResponse
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.GetDefaultPriceLevelRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetDefaultPriceLevelResponse : OrganizationResponse
  {
    /// <summary>Gets the price level (price list) for the current user. If a user territory is part of multiple price levels (price lists), gets multiple price levels (price lists).</summary>
    /// <returns>Returns <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The resulting price level, which is an instance of the PriceLevel class.</returns>
    public EntityCollection PriceLevels
    {
      get
      {
        return this.Results.Contains(nameof (PriceLevels)) ? (EntityCollection) this.Results[nameof (PriceLevels)] : (EntityCollection) null;
      }
    }
  }
}
