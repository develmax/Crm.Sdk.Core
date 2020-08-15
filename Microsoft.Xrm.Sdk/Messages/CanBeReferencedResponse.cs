using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.CanBeReferencedRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CanBeReferencedResponse : OrganizationResponse
  {
    /// <summary>Gets the result of the request to see whether the entity can be the primary entity (one) in a one-to-many relationship.</summary>
    /// <returns>Type: Returns_Booleantrue if the entity can be the primary entity (one) in a one-to-many relationship; otherwise, false.</returns>
    public bool CanBeReferenced
    {
      get
      {
        return this.Results.Contains(nameof (CanBeReferenced)) && (bool) this.Results[nameof (CanBeReferenced)];
      }
    }
  }
}
