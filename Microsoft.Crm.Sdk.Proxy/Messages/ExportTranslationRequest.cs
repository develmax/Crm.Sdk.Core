// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ExportTranslationRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  export all translations for a specific solution to a compressed file.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExportTranslationRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the unique name for the unmanaged solution to export translations for. Required.</summary>
    /// <returns>Type: Returns_StringThe unique name for the unmanaged solution to export translations for. Required.</returns>
    public string SolutionName
    {
      get
      {
        return this.Parameters.Contains(nameof (SolutionName)) ? (string) this.Parameters[nameof (SolutionName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (SolutionName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ExportTranslationRequest"></see> class</summary>
    public ExportTranslationRequest()
    {
      this.RequestName = "ExportTranslation";
      this.SolutionName = (string) null;
    }
  }
}
