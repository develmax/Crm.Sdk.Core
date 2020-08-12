// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ReassignObjectsSystemUserRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to reassign all records that are owned by a specified user to another security principal (user or team).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ReassignObjectsSystemUserRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the user for which you want to reassign all records.</summary>
    /// <returns>Type: Returns_GuidThe ID of the user for which you want to reassign all records. This corresponds to the SystemUser.SystemUserId attribute, which is the primary key for the SystemUser entity.</returns>
    public Guid UserId
    {
      get
      {
        return this.Parameters.Contains(nameof (UserId)) ? (Guid) this.Parameters[nameof (UserId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (UserId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the security principal (user or team) that is the new owner for the records.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The security principal (user or team) that is the new owner for the records. This must be an entity reference for the SystemUser entity or Team entity. </returns>
    public EntityReference ReassignPrincipal
    {
      get
      {
        return this.Parameters.Contains(nameof (ReassignPrincipal)) ? (EntityReference) this.Parameters[nameof (ReassignPrincipal)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (ReassignPrincipal)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ReassignObjectsSystemUserRequest"></see> class.</summary>
    public ReassignObjectsSystemUserRequest()
    {
      this.RequestName = "ReassignObjectsSystemUser";
      this.UserId = new Guid();
      this.ReassignPrincipal = (EntityReference) null;
    }
  }
}
