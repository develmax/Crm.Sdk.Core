using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the data that defines the content and behavior of the application ribbon. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveApplicationRibbonRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveApplicationRibbonRequest"></see> class.</summary>
    public RetrieveApplicationRibbonRequest()
    {
      this.RequestName = "RetrieveApplicationRibbon";
    }
  }
}
