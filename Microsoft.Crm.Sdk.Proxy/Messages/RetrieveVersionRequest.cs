using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the version number of the pn_microsoftcrm_server.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveVersionRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveVersionRequest"></see> class.</summary>
    public RetrieveVersionRequest()
    {
      this.RequestName = "RetrieveVersion";
    }
  }
}
