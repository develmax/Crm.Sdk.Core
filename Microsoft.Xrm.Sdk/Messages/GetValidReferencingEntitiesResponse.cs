using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.GetValidReferencingEntitiesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class GetValidReferencingEntitiesResponse : OrganizationResponse
  {
    /// <summary>Gets the array of valid entity names that can be the related entity in a many-to-many relationship.</summary>
    /// <returns>Type: Returns_String[]The array of valid entity names that can be the related entity in a many-to-many relationship.</returns>
    public string[] EntityNames
    {
      get
      {
        return this.Results.Contains(nameof (EntityNames)) ? (string[]) this.Results[nameof (EntityNames)] : (string[]) null;
      }
    }
  }
}
