// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.FetchXmlToQueryExpressionRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  convert a query in FetchXML to a QueryExpression.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class FetchXmlToQueryExpressionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the query to convert.</summary>
    /// <returns>Type: Returns_StringThe query to convert. This The string must contain a query that you express in FetchXML. For more information, see FetchXML Schema/html/82cae525-a789-4884-9fc0-a3e874ee1567.htm.</returns>
    public string FetchXml
    {
      get
      {
        return this.Parameters.Contains(nameof (FetchXml)) ? (string) this.Parameters[nameof (FetchXml)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (FetchXml)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.FetchXmlToQueryExpressionRequest"></see> class.</summary>
    public FetchXmlToQueryExpressionRequest()
    {
      this.RequestName = "FetchXmlToQueryExpression";
      this.FetchXml = (string) null;
    }
  }
}
