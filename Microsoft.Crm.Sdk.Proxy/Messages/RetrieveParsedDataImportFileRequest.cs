﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveParsedDataImportFileRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the data from the parse table.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveParsedDataImportFileRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the import file that is associated with the parse table. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the import file that is associated with the parse table. This property corresponds to the ImportFile.ImportFileId attribute, which is the primary key for the ImportFile entity.</returns>
    public Guid ImportFileId
    {
      get
      {
        return this.Parameters.Contains(nameof (ImportFileId)) ? (Guid) this.Parameters[nameof (ImportFileId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ImportFileId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the paging information for the retrieved data. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.PagingInfo"></see>The paging information for the retrieved data.</returns>
    public PagingInfo PagingInfo
    {
      get
      {
        return this.Parameters.Contains(nameof (PagingInfo)) ? (PagingInfo) this.Parameters[nameof (PagingInfo)] : (PagingInfo) null;
      }
      set
      {
        this.Parameters[nameof (PagingInfo)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveParsedDataImportFileRequest"></see> class.</summary>
    public RetrieveParsedDataImportFileRequest()
    {
      this.RequestName = "RetrieveParsedDataImportFile";
      this.ImportFileId = new Guid();
      this.PagingInfo = (PagingInfo) null;
    }
  }
}
