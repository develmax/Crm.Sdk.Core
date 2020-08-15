using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveAbsoluteAndSiteCollectionUrlRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveAbsoluteAndSiteCollectionUrlResponse : OrganizationResponse
  {
    /// <summary>Gets the absolute URL of the object that is specified in the request.</summary>
    /// <returns>Type: Returns_String
    /// The absolute URL of the object that is specified in the request.</returns>
    public string AbsoluteUrl
    {
      get
      {
        return this.Results.Contains(nameof (AbsoluteUrl)) ? (string) this.Results[nameof (AbsoluteUrl)] : (string) null;
      }
    }

    /// <summary>Gets the pn_SharePoint_short site collection URL of the object that is specified in the request.</summary>
    /// <returns>Type: Returns_String
    /// The pn_SharePoint_short site collection URL of the object that is specified in the request.</returns>
    public string SiteCollectionUrl
    {
      get
      {
        return this.Results.Contains(nameof (SiteCollectionUrl)) ? (string) this.Results[nameof (SiteCollectionUrl)] : (string) null;
      }
    }
  }
}
