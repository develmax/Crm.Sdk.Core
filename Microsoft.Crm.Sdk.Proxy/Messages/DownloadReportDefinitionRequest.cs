// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.DownloadReportDefinitionRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  download a report definition.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class DownloadReportDefinitionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the report to download.</summary>
    /// <returns>Type: Returns_GuidThe ID of the report to download. This corresponds to the Report.ReportId attribute, which is the primary key for the Report entity.</returns>
    public Guid ReportId
    {
      get
      {
        return this.Parameters.Contains(nameof (ReportId)) ? (Guid) this.Parameters[nameof (ReportId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ReportId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.DownloadReportDefinitionRequest"></see> class.</summary>
    public DownloadReportDefinitionRequest()
    {
      this.RequestName = "DownloadReportDefinition";
      this.ReportId = new Guid();
    }
  }
}
