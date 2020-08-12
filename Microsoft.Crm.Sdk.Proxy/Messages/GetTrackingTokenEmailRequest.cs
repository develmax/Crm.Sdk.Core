// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.GetTrackingTokenEmailRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  return a tracking token that can then be passed as a parameter to the <see cref="T:Microsoft.Crm.Sdk.Messages.SendEmailRequest"></see> message.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetTrackingTokenEmailRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the context of the email. Required.</summary>
    /// <returns>Type: Returns_StringThe context of the email.</returns>
    public string Subject
    {
      get
      {
        return this.Parameters.Contains(nameof (Subject)) ? (string) this.Parameters[nameof (Subject)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (Subject)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.GetTrackingTokenEmailRequest"></see> class.</summary>
    public GetTrackingTokenEmailRequest()
    {
      this.RequestName = "GetTrackingTokenEmail";
    }
  }
}
