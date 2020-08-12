// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.DeleteAuditDataRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  delete all audit data records up until a specified end date.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class DeleteAuditDataRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the end date and time. Required.</summary>
    /// <returns>Type: Returns_DateTimeThe end date and time.</returns>
    public DateTime EndDate
    {
      get
      {
        return this.Parameters.Contains(nameof (EndDate)) ? (DateTime) this.Parameters[nameof (EndDate)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (EndDate)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the DeleteAuditDataRequest class.</summary>
    public DeleteAuditDataRequest()
    {
      this.RequestName = "DeleteAuditData";
      this.EndDate = new DateTime();
    }
  }
}
