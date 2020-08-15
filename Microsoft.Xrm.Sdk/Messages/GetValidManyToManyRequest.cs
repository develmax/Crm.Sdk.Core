using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve a list of all the entities that can participate in a Many-to-Many entity relationship. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class GetValidManyToManyRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the  GetValidManyToManyRequest class</summary>
    public GetValidManyToManyRequest()
    {
      this.RequestName = "GetValidManyToMany";
    }
  }
}
