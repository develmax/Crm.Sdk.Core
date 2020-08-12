// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ReassignObjectsOwnerRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  reassign all records that are owned by the security principal (user or team) to another security principal (user or team).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ReassignObjectsOwnerRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the security principal (user or team) for which to reassign all records.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The security principal (user or team) for which to reassign all records. This must be an entity reference for the SystemUser entity or Team entity.</returns>
    public EntityReference FromPrincipal
    {
      get
      {
        return this.Parameters.Contains(nameof (FromPrincipal)) ? (EntityReference) this.Parameters[nameof (FromPrincipal)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (FromPrincipal)] = (object) value;
      }
    }

    /// <summary>Gets or sets the security principal (user or team) that will be the new owner for the records.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The security principal (user or team) that will be the new owner for the records. This must be an entity reference for the SystemUser entity or Team entity.</returns>
    public EntityReference ToPrincipal
    {
      get
      {
        return this.Parameters.Contains(nameof (ToPrincipal)) ? (EntityReference) this.Parameters[nameof (ToPrincipal)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (ToPrincipal)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ReassignObjectsOwnerRequest"></see>  class.</summary>
    public ReassignObjectsOwnerRequest()
    {
      this.RequestName = "ReassignObjectsOwner";
      this.FromPrincipal = (EntityReference) null;
      this.ToPrincipal = (EntityReference) null;
    }
  }
}
