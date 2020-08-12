// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ProcessInboundEmailRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to process the email responses from a marketing campaign.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ProcessInboundEmailRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the inbound email activity.</summary>
    /// <returns>Type: Returns_GuidThe ID of the inbound email activity. This corresponds to the ActivityPointer.ActivityId attribute, which is the primary key for the ActivityPointer entity. Alternatively, it can be the ActivityID for any activity entity type, including custom activity entities.</returns>
    public Guid InboundEmailActivity
    {
      get
      {
        return this.Parameters.Contains(nameof (InboundEmailActivity)) ? (Guid) this.Parameters[nameof (InboundEmailActivity)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (InboundEmailActivity)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ProcessInboundEmailRequest"></see> class.</summary>
    public ProcessInboundEmailRequest()
    {
      this.RequestName = "ProcessInboundEmail";
      this.InboundEmailActivity = new Guid();
    }
  }
}
