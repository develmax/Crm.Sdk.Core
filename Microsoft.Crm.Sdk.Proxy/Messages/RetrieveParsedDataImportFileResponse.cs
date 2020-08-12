// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveParsedDataImportFileResponse
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveParsedDataImportFileRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveParsedDataImportFileResponse : OrganizationResponse
  {
    /// <summary>Gets the parsed data.</summary>
    /// <returns>Type: Returns_StringThe parsed data. The returned data has the same column order as the column order in the source file.</returns>
    public string[][] Values
    {
      get
      {
        return this.Results.Contains(nameof (Values)) ? (string[][]) this.Results[nameof (Values)] : (string[][]) null;
      }
    }
  }
}
