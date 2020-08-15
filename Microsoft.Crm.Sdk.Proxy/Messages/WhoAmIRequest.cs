using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the system user ID for the currently logged on user or the user under whose context the code is running.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class WhoAmIRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.WhoAmIRequest"></see> class.</summary>
    public WhoAmIRequest()
    {
      this.RequestName = "WhoAmI";
    }
  }
}
