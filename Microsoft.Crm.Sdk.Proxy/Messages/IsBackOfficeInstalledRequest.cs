using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Checks whether pn_Great_Plains_9 is installed. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class IsBackOfficeInstalledRequest : OrganizationRequest
  {
    /// <summary>deprecated</summary>
    public IsBackOfficeInstalledRequest()
    {
      this.RequestName = "IsBackOfficeInstalled";
    }
  }
}
