using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.CanManyToManyRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CanManyToManyResponse : OrganizationResponse
  {
    /// <summary>Gets the result of the request to see whether the entity can participate in a many-to-many relationship.</summary>
    /// <returns>Type: Returns_Booleantrue if the the entity can participate in a many-to-many relationship.; otherwise, false.</returns>
    public bool CanManyToMany
    {
      get
      {
        return this.Results.Contains(nameof (CanManyToMany)) && (bool) this.Results[nameof (CanManyToMany)];
      }
    }
  }
}
