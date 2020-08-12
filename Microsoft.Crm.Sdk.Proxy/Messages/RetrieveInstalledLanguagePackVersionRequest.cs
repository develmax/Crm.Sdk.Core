// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveInstalledLanguagePackVersionRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the version of an installed language pack.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveInstalledLanguagePackVersionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the value that represents the locale ID for the language pack. Required.</summary>
    /// <returns>Type: Returns_Int32The value that represents the locale ID for the language pack. Required.</returns>
    public int Language
    {
      get
      {
        return this.Parameters.Contains(nameof (Language)) ? (int) this.Parameters[nameof (Language)] : 0;
      }
      set
      {
        this.Parameters[nameof (Language)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveInstalledLanguagePackVersionRequest"></see> class.</summary>
    public RetrieveInstalledLanguagePackVersionRequest()
    {
      this.RequestName = "RetrieveInstalledLanguagePackVersion";
      this.Language = 0;
    }
  }
}
