// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveUserQueuesRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data needed to retrieve all private queues of a specified user and optionally all public queues.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveUserQueuesRequest : OrganizationRequest
  {
    /// <returns>Type: Returns_Guid
    /// The id of the user. This corresponds to the SystemUser.SystemUserId attribute, which is the primary key for the SystemUser entity.</returns>
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

    /// <summary>Gets or sets whether the response should include public queues.</summary>
    /// <returns>Type: Returns_Booleantrue if the response should include public queues; otherwise, false.</returns>
    public bool IncludePublic
    {
      get
      {
        return this.Parameters.Contains(nameof (IncludePublic)) && (bool) this.Parameters[nameof (IncludePublic)];
      }
      set
      {
        this.Parameters[nameof (IncludePublic)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveUserQueuesRequest"></see> class.</summary>
    public RetrieveUserQueuesRequest()
    {
      this.RequestName = "RetrieveUserQueues";
      this.UserId = new Guid();
      this.IncludePublic = false;
    }
  }
}
