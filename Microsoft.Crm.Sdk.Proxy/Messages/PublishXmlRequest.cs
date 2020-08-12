// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.PublishXmlRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  publish specified solution components. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class PublishXmlRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the XML that defines which solution components to publish in this request. Required.</summary>
    /// <returns>Type: Returns_Stringthe XML that defines which solution components to publish in this request. Required.</returns>
    public string ParameterXml
    {
      get
      {
        return this.Parameters.Contains(nameof (ParameterXml)) ? (string) this.Parameters[nameof (ParameterXml)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (ParameterXml)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.PublishXmlRequest"></see> class</summary>
    public PublishXmlRequest()
    {
      this.RequestName = "PublishXml";
      this.ParameterXml = (string) null;
    }
  }
}
