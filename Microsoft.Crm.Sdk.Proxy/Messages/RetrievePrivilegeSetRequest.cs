using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data needed to retrieve the set of privileges defined in the system.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrievePrivilegeSetRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrievePrivilegeSetRequest"></see> class.</summary>
    public RetrievePrivilegeSetRequest()
    {
      this.RequestName = "RetrievePrivilegeSet";
    }
  }
}
