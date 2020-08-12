// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ResetUserFiltersRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  reset the offline data filters for the calling user to the default filters for the organization.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ResetUserFiltersRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the type of filters to set. Required.</summary>
    /// <returns>Type: Returns_Int32The type of filters to set. Use, <see cref="F:Microsoft.Crm.Sdk.UserQueryQueryType.OfflineFilters"></see> or <see cref="F:Microsoft.Crm.Sdk.UserQueryQueryType.OutlookFilters"></see>.</returns>
    public int QueryType
    {
      get
      {
        return this.Parameters.Contains(nameof (QueryType)) ? (int) this.Parameters[nameof (QueryType)] : 0;
      }
      set
      {
        this.Parameters[nameof (QueryType)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ResetUserFiltersRequest"></see> class.</summary>
    public ResetUserFiltersRequest()
    {
      this.RequestName = "ResetUserFilters";
      this.QueryType = 0;
    }
  }
}
