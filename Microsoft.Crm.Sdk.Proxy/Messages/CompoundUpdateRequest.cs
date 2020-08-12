// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.CompoundUpdateRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateRequest"></see> class. Contains the data that is needed to  update a compound record, such as a sales order (order), invoice, quote, or duplicate rule (duplicate detection rule); and its related detail record, such as a sales order detail (order product), invoice detail (invoice product), quote detail (quote product), or duplicate rule condition.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CompoundUpdateRequest : OrganizationRequest
  {
    /// <summary>deprecated</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see></returns>
    public Entity Entity
    {
      get
      {
        return this.Parameters.Contains(nameof (Entity)) ? (Entity) this.Parameters[nameof (Entity)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Entity)] = (object) value;
      }
    }

    /// <summary>deprecated</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see></returns>
    public EntityCollection ChildEntities
    {
      get
      {
        return this.Parameters.Contains(nameof (ChildEntities)) ? (EntityCollection) this.Parameters[nameof (ChildEntities)] : (EntityCollection) null;
      }
      set
      {
        this.Parameters[nameof (ChildEntities)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.CompoundUpdateRequest"></see> class.</summary>
    public CompoundUpdateRequest()
    {
      this.RequestName = "CompoundUpdate";
      this.Entity = (Entity) null;
      this.ChildEntities = (EntityCollection) null;
    }
  }
}
