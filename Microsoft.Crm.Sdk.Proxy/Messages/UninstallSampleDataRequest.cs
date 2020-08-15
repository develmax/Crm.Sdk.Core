using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class UninstallSampleDataRequest : OrganizationRequest
  {
    public UninstallSampleDataRequest()
    {
      this.RequestName = "UninstallSampleData";
    }
  }
}
