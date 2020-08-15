using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  check whether the specified entity can be the primary entity (one) in a one-to-many relationship.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CanBeReferencedRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the logical entity name to check whether it can be the primary entity in a one-to-many relationship. Required.</summary>
    /// <returns>Type: Returns_String
    /// The logical entity name to check whether it can be the primary entity in a one-to-many relationship. Required.</returns>
    public string EntityName
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityName)) ? (string) this.Parameters[nameof (EntityName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (EntityName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.CanBeReferencedRequest"></see> class.</summary>
    public CanBeReferencedRequest()
    {
      this.RequestName = "CanBeReferenced";
      this.EntityName = (string) null;
    }
  }
}
