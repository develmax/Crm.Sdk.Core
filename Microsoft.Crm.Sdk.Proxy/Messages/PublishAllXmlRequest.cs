using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  publish all changes to solution components. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class PublishAllXmlRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the  PublishAllXmlRequest class</summary>
    public PublishAllXmlRequest()
    {
      this.RequestName = "PublishAllXml";
    }
  }
}
