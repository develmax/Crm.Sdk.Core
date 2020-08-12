// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.GetHeaderColumnsImportFileRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the source-file column headings; or retrieve the system-generated column headings if the source file does not contain column headings.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetHeaderColumnsImportFileRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the import file that is associated with the parse table. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the import file that is associated with the parse table. This corresponds to the ImportFile.ImportFileId attribute, which is the primary key for the ImportFile entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.GetHeaderColumnsImportFileRequest"></see> class.</summary>
    public GetHeaderColumnsImportFileRequest()
    {
      this.RequestName = "GetHeaderColumnsImportFile";
      this.ImportFileId = new Guid();
    }
  }
}
