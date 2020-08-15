using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  install the sample data.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class InstallSampleDataRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.InstallSampleDataRequest"></see> class.</summary>
    public InstallSampleDataRequest()
    {
      this.RequestName = "InstallSampleData";
    }
  }
}
