// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveFormXmlRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveFormXmlRequest : OrganizationRequest
  {
    /// <summary>internal</summary>
    /// <returns>Type: Returns_Stringinternal</returns>
    public string EntityName
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityName)) ? (string) this.Parameters[nameof (EntityName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (EntityName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveFormXmlRequest"></see> class.</summary>
    public RetrieveFormXmlRequest()
    {
      this.RequestName = "RetrieveFormXml";
      this.EntityName = (string) null;
    }
  }
}
