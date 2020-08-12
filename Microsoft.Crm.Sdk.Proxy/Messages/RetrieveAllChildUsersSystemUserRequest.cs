// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveAllChildUsersSystemUserRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the collection of users that report to the specified system user (user).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAllChildUsersSystemUserRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the system user (user).</summary>
    /// <returns>Type: Returns_GuidThe ID of the system user (user). This corresponds to the SystemUser.SystemUserId property, which is the primary key for the SystemUser entity.</returns>
    public Guid EntityId
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityId)) ? (Guid) this.Parameters[nameof (EntityId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (EntityId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the set of attributes to retrieve. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>The set of attributes to retrieve.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveAllChildUsersSystemUserRequest"></see> class.</summary>
    public RetrieveAllChildUsersSystemUserRequest()
    {
      this.RequestName = "RetrieveAllChildUsersSystemUser";
      this.EntityId = new Guid();
      this.ColumnSet = (ColumnSet) null;
    }
  }
}
