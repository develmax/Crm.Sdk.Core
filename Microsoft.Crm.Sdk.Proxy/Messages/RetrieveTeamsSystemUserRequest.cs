// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveTeamsSystemUserRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest"></see> class.Contains the data needed to retrieve the list of teams of which the specified user is a member.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveTeamsSystemUserRequest : OrganizationRequest
  {
    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest"></see> class and its members.</summary>
    /// <returns>Type: Returns_Guid</returns>
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

    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest"></see> class and its members.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see></returns>
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

    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest"></see> class and its members.</summary>
    public RetrieveTeamsSystemUserRequest()
    {
      this.RequestName = "RetrieveTeamsSystemUser";
      this.EntityId = new Guid();
      this.ColumnSet = (ColumnSet) null;
    }
  }
}
