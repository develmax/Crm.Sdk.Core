// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.SendEmailResponse
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.BackgroundSendEmailRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SendEmailResponse : OrganizationResponse
  {
    /// <summary>Gets the subject line for the email message.</summary>
    /// <returns>Type: Returns_StringThe subject line for the email message.</returns>
    public string Subject
    {
      get
      {
        return this.Results.Contains(nameof (Subject)) ? (string) this.Results[nameof (Subject)] : (string) null;
      }
    }
  }
}
