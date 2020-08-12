// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.SendFaxRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to send a fax.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SendFaxRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the fax to send.</summary>
    /// <returns>Type: Returns_GuidThe ID of the fax to send. This corresponds to the Fax.FaxId attribute, which is the primary key for the Fax entity.</returns>
    public Guid FaxId
    {
      get
      {
        return this.Parameters.Contains(nameof (FaxId)) ? (Guid) this.Parameters[nameof (FaxId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (FaxId)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether to send the e-mail, or to just record it as sent.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether to send the e-mail, or to just record it as sent. true, to send the e-mail, otherwise, false. </returns>
    public bool IssueSend
    {
      get
      {
        return this.Parameters.Contains(nameof (IssueSend)) && (bool) this.Parameters[nameof (IssueSend)];
      }
      set
      {
        this.Parameters[nameof (IssueSend)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the<see cref="T:Microsoft.Crm.Sdk.Messages.SendFaxRequest"></see> class.</summary>
    public SendFaxRequest()
    {
      this.RequestName = "SendFax";
      this.FaxId = new Guid();
      this.IssueSend = false;
    }
  }
}
