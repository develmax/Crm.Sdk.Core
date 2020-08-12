﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ImportFieldTranslationRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to import translations from a compressed file.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ImportFieldTranslationRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the compressed translations file. Required.</summary>
    /// <returns>Type: Returns_Byte[] The compressed translations file.</returns>
    public byte[] TranslationFile
    {
      get
      {
        return this.Parameters.Contains(nameof (TranslationFile)) ? (byte[]) this.Parameters[nameof (TranslationFile)] : (byte[]) null;
      }
      set
      {
        this.Parameters[nameof (TranslationFile)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ImportFieldTranslationRequest"></see> class</summary>
    public ImportFieldTranslationRequest()
    {
      this.RequestName = "ImportFieldTranslation";
      this.TranslationFile = (byte[]) null;
    }
  }
}
