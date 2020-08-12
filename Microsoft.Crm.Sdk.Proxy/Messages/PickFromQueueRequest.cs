// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.PickFromQueueRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to assign a queue item to a user and optionally remove the queue item from the queue.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class PickFromQueueRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the</summary>
    /// <returns>Type: Returns_Guid
    /// The QueueItem. This corresponds to the QueueItem.QueueItemId attribute, which is the primary key for the QueueItem entity.</returns>
    public Guid QueueItemId
    {
      get
      {
        return this.Parameters.Contains(nameof (QueueItemId)) ? (Guid) this.Parameters[nameof (QueueItemId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (QueueItemId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the user to assign the queue item to. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The User. This corresponds to the SystemUser.SystemUserId attribute, which is the primary key for the SystemUser entity.</returns>
    public Guid WorkerId
    {
      get
      {
        return this.Parameters.Contains(nameof (WorkerId)) ? (Guid) this.Parameters[nameof (WorkerId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (WorkerId)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether the queue item should be removed from the queue.</summary>
    /// <returns>Type: Returns_Booleantrue if the queue item should be removed from the queue; otherwise, false.</returns>
    public bool RemoveQueueItem
    {
      get
      {
        return this.Parameters.Contains(nameof (RemoveQueueItem)) && (bool) this.Parameters[nameof (RemoveQueueItem)];
      }
      set
      {
        this.Parameters[nameof (RemoveQueueItem)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.PickFromQueueRequest"></see> class.</summary>
    public PickFromQueueRequest()
    {
      this.RequestName = "PickFromQueue";
      this.QueueItemId = new Guid();
      this.WorkerId = new Guid();
      this.RemoveQueueItem = false;
    }
  }
}
