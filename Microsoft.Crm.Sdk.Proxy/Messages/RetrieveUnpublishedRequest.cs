// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveUnpublishedRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve an unpublished record. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveUnpublishedRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target record for the operation. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>the target record for the operation. Required.</returns>
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

    /// <summary>Gets or sets the collection of attributes for which non-null values are returned from a query. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>The collection of attributes for which non-null values are returned from a query. Required..</returns>
    public ColumnSet ColumnSet
    {
      get
      {
        return this.Parameters.Contains(nameof (ColumnSet)) ? (ColumnSet) this.Parameters[nameof (ColumnSet)] : (ColumnSet) null;
      }
      set
      {
        this.Parameters[nameof (ColumnSet)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveUnpublishedRequest"></see> class.</summary>
    public RetrieveUnpublishedRequest()
    {
      this.RequestName = "RetrieveUnpublished";
      this.Target = (EntityReference) null;
      this.ColumnSet = (ColumnSet) null;
    }
  }
}
