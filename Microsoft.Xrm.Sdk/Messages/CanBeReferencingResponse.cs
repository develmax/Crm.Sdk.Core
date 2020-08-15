using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.CanBeReferencingRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CanBeReferencingResponse : OrganizationResponse
  {
    /// <summary>Gets the result of the request to see whether the entity can be the referencing entity (many) in a one-to-many relationship.</summary>
    /// <returns>Type: Returns_Booleantrue if the entity can be the referencing entity (many) in a one-to-many relationship.; otherwise, false.</returns>
    public bool CanBeReferencing
    {
      get
      {
        return this.Results.Contains(nameof (CanBeReferencing)) && (bool) this.Results[nameof (CanBeReferencing)];
      }
    }
  }
}
