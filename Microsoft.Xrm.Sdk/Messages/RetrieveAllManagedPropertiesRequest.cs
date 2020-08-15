using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve all managed property definitions </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAllManagedPropertiesRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the  RetrieveAllManagedPropertiesRequest class</summary>
    public RetrieveAllManagedPropertiesRequest()
    {
      this.RequestName = "RetrieveAllManagedProperties";
    }
  }
}
