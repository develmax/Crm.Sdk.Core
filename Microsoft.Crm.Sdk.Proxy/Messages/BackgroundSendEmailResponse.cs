// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.BackgroundSendEmailResponse
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.BackgroundSendEmailRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class BackgroundSendEmailResponse : OrganizationResponse
  {
    /// <summary>Gets the resulting emails. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The collection of resulting emails.</returns>
    public EntityCollection EntityCollection
    {
      get
      {
        return this.Results.Contains(nameof (EntityCollection)) ? (EntityCollection) this.Results[nameof (EntityCollection)] : (EntityCollection) null;
      }
    }

    /// <summary>Gets a value that indicates whether the email has attachments. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the email has attachments; otherwise, false.</returns>
    public bool[] HasAttachments
    {
      get
      {
        return this.Results.Contains(nameof (HasAttachments)) ? (bool[]) this.Results[nameof (HasAttachments)] : (bool[]) null;
      }
    }
  }
}
