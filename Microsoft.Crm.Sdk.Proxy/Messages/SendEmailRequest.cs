// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.SendEmailRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to send an email message.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SendEmailRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the email to send.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the email to send, which corresponds to the Email.EmailId attribute, which is the primary key for the Email entity.</returns>
    public Guid EmailId
    {
      get
      {
        return this.Parameters.Contains(nameof (EmailId)) ? (Guid) this.Parameters[nameof (EmailId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (EmailId)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether to send the email, or to just record it as sent.</summary>
    /// <returns>Type: Returns_Booleantrue if the email should be sent; otherwise, false, just record it as sent.</returns>
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

    /// <summary>Gets or sets the tracking token.</summary>
    /// <returns>Type: Returns_StringThe tracking token, which is used to correlate an email with a context.</returns>
    public string TrackingToken
    {
      get
      {
        return this.Parameters.Contains(nameof (TrackingToken)) ? (string) this.Parameters[nameof (TrackingToken)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (TrackingToken)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.SendEmailRequest"></see> class.</summary>
    public SendEmailRequest()
    {
      this.RequestName = "SendEmail";
      this.EmailId = new Guid();
      this.IssueSend = false;
    }
  }
}
