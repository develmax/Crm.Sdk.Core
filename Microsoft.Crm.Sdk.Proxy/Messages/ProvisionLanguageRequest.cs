// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ProvisionLanguageRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  provision a new language.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ProvisionLanguageRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the language to provision. Required.</summary>
    /// <returns>Type: Returns_Int32The language to provision. Required.</returns>
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

    /// <summary>constructor_initializes<see cref="T:Microsoft.Crm.Sdk.Messages.ProvisionLanguageRequest"></see> class</summary>
    public ProvisionLanguageRequest()
    {
      this.RequestName = "ProvisionLanguage";
      this.Language = 0;
    }
  }
}
