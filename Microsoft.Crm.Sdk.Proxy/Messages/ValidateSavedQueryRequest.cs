// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ValidateSavedQueryRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  validate a saved query (view).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ValidateSavedQueryRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the FetchXML query string to be validated.</summary>
    /// <returns>Type: Returns_String
    /// The FetchXML query string to be validated.</returns>
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

    /// <summary>Gets or sets the type of the query.</summary>
    /// <returns>Type: Returns_Int32
    /// The query type, which should be one of the values in the <see cref="T:Microsoft.Crm.Sdk.SavedQueryQueryType"></see> class.</returns>
    public int QueryType
    {
      get
      {
        return this.Parameters.Contains(nameof (QueryType)) ? (int) this.Parameters[nameof (QueryType)] : 0;
      }
      set
      {
        this.Parameters[nameof (QueryType)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ValidateSavedQueryRequest"></see> class.</summary>
    public ValidateSavedQueryRequest()
    {
      this.RequestName = "ValidateSavedQuery";
      this.FetchXml = (string) null;
      this.QueryType = 0;
    }
  }
}
