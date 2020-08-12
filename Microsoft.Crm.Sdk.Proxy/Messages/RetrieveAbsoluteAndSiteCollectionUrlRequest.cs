// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveAbsoluteAndSiteCollectionUrlRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the absolute URL and the site collection URL for a pn_SharePoint_short location record in pn_microsoftcrm.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAbsoluteAndSiteCollectionUrlRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target for which the data is to be retrieved. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target for which the data is to be retrieved. This property must be a reference to a record of the SharepointDocumentLocation entity or the SharepointSite entity type.</returns>
    public EntityReference Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveAbsoluteAndSiteCollectionUrlRequest"></see> class.</summary>
    public RetrieveAbsoluteAndSiteCollectionUrlRequest()
    {
      this.RequestName = "RetrieveAbsoluteAndSiteCollectionUrl";
      this.Target = (EntityReference) null;
    }
  }
}
