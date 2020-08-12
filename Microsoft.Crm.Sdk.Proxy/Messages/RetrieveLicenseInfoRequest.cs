// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveLicenseInfoRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the number of used and available licenses for a deployment of pn_microsoftcrm.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveLicenseInfoRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the access mode for retrieving the license information.</summary>
    /// <returns>Type: Returns_Int32The access mode for retrieving the license information. Use one of the option set values for SystemUser.AccessMode. For a list of these values, the metadata for this entity. metadata_browser</returns>
    public int AccessMode
    {
      get
      {
        return this.Parameters.Contains(nameof (AccessMode)) ? (int) this.Parameters[nameof (AccessMode)] : 0;
      }
      set
      {
        this.Parameters[nameof (AccessMode)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveLicenseInfoRequest"></see> class.</summary>
    public RetrieveLicenseInfoRequest()
    {
      this.RequestName = "RetrieveLicenseInfo";
      this.AccessMode = 0;
    }
  }
}
