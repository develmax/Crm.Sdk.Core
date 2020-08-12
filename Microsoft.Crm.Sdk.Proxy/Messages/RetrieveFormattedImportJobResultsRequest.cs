// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveFormattedImportJobResultsRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the formatted results from an import job.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveFormattedImportJobResultsRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the GUID of an import job. Required.</summary>
    /// <returns>Type: Returns_GuidThe GUID of an import job. This corresponds to the ImportJob.ImportJobId attribute, which is the primary key for the ImportJob entity.</returns>
    public Guid ImportJobId
    {
      get
      {
        return this.Parameters.Contains(nameof (ImportJobId)) ? (Guid) this.Parameters[nameof (ImportJobId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ImportJobId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveFormattedImportJobResultsRequest"></see> class.</summary>
    public RetrieveFormattedImportJobResultsRequest()
    {
      this.RequestName = "RetrieveFormattedImportJobResults";
      this.ImportJobId = new Guid();
    }
  }
}
