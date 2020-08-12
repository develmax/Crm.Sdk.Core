// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveUserPrivilegesRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data needed to retrieve the privileges a system user (user) has through his or her roles in the specified business unit.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveUserPrivilegesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the user to retrieve privileges for.</summary>
    /// <returns>Type: Returns_GuidThe user to retrieve privileges for. This corresponds to the User.UserId attribute, which is the primary key for the User entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveUserPrivilegesRequest"></see> class.</summary>
    public RetrieveUserPrivilegesRequest()
    {
      this.RequestName = "RetrieveUserPrivileges";
      this.UserId = new Guid();
    }
  }
}
