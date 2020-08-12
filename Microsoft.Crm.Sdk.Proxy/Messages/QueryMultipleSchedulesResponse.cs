// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.QueryMultipleSchedulesResponse
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.QueryMultipleSchedulesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class QueryMultipleSchedulesResponse : OrganizationResponse
  {
    /// <summary>Gets the results of the search, which is a set of possible time block for each resource.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.TimeInfo"></see>The results of the search. Contains an array of possible time slots for each of the specified resource IDs in the <see cref="T:Microsoft.Crm.Sdk.Messages.QueryMultipleSchedulesRequest"></see> class.</returns>
    public TimeInfo[][] TimeInfos
    {
      get
      {
        return this.Results.Contains(nameof (TimeInfos)) ? (TimeInfo[][]) this.Results[nameof (TimeInfos)] : (TimeInfo[][]) null;
      }
    }
  }
}
