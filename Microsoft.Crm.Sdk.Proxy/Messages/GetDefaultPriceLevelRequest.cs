// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.GetDefaultPriceLevelRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the default price level (price list) for the current user based on the user’s territory relationship with the price list. If a user territory is part of multiple price levels (price lists), this message will retrieve all those price levels (price lists). This message will return results only if the Organization.UseInbuiltRuleForDefaultPriceSelectionRule attribute is set to 0 (false).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetDefaultPriceLevelRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the logical entity name.</summary>
    /// <returns>Returns <see cref="T:System.String"></see>The logical entity name.</returns>
    public string EntityName
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityName)) ? (string) this.Parameters[nameof (EntityName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (EntityName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.GetDefaultPriceLevelRequest"></see> class.</summary>
    public GetDefaultPriceLevelRequest()
    {
      this.RequestName = "GetDefaultPriceLevel";
      this.EntityName = (string) null;
    }
  }
}
