// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.UtcTimeFromLocalTimeRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the Coordinated Universal Time (UTC) for the specified local time.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class UtcTimeFromLocalTimeRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the time zone code. Required.</summary>
    /// <returns>Type: Returns_Int32The time zone code.</returns>
    public int TimeZoneCode
    {
      get
      {
        return this.Parameters.Contains(nameof (TimeZoneCode)) ? (int) this.Parameters[nameof (TimeZoneCode)] : 0;
      }
      set
      {
        this.Parameters[nameof (TimeZoneCode)] = (object) value;
      }
    }

    /// <summary>Gets or sets the local time. Required.</summary>
    /// <returns>Type: Returns_DateTimeThe the local time.</returns>
    public DateTime LocalTime
    {
      get
      {
        return this.Parameters.Contains(nameof (LocalTime)) ? (DateTime) this.Parameters[nameof (LocalTime)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (LocalTime)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.UtcTimeFromLocalTimeRequest"></see> class.</summary>
    public UtcTimeFromLocalTimeRequest()
    {
      this.RequestName = "UtcTimeFromLocalTime";
      this.TimeZoneCode = 0;
      this.LocalTime = new DateTime();
    }
  }
}
