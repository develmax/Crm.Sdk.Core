// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.GetAllTimeZonesWithDisplayNameRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve all the time zone definitions for the specified locale and to return only the display name attribute.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetAllTimeZonesWithDisplayNameRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the locale ID. Required.</summary>
    /// <returns>Type: Returns_Int32The locale ID.</returns>
    public int LocaleId
    {
      get
      {
        return this.Parameters.Contains(nameof (LocaleId)) ? (int) this.Parameters[nameof (LocaleId)] : 0;
      }
      set
      {
        this.Parameters[nameof (LocaleId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.GetAllTimeZonesWithDisplayNameRequest"></see> class.</summary>
    public GetAllTimeZonesWithDisplayNameRequest()
    {
      this.RequestName = "GetAllTimeZonesWithDisplayName";
      this.LocaleId = 0;
    }
  }
}
