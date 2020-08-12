// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveAttributeChangeHistoryRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve all metadata changes to a specific attribute.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAttributeChangeHistoryRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target audit record for which to retrieve attribute change history. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target record.</returns>
    public EntityReference Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Gets or sets the attribute’s logical (schema) name. Required.</summary>
    /// <returns>Type: Returns_StringThe logical name of the attribute.</returns>
    public string AttributeLogicalName
    {
      get
      {
        return this.Parameters.Contains(nameof (AttributeLogicalName)) ? (string) this.Parameters[nameof (AttributeLogicalName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (AttributeLogicalName)] = (object) value;
      }
    }

    /// <summary>Gets or sets the paging information. Optional.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.PagingInfo"></see>The paging information.</returns>
    public PagingInfo PagingInfo
    {
      get
      {
        return this.Parameters.Contains(nameof (PagingInfo)) ? (PagingInfo) this.Parameters[nameof (PagingInfo)] : (PagingInfo) null;
      }
      set
      {
        this.Parameters[nameof (PagingInfo)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the RetrieveAttributeChangeHistoryRequest class.</summary>
    public RetrieveAttributeChangeHistoryRequest()
    {
      this.RequestName = "RetrieveAttributeChangeHistory";
      this.Target = (EntityReference) null;
      this.AttributeLogicalName = (string) null;
    }
  }
}
