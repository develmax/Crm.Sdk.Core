using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  check whether an entity can participate in a many-to-many relationship.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CanManyToManyRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the logical entity name. Required</summary>
    /// <returns>Type: Returns_String
    /// The logical entity name. Required.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.CanManyToManyRequest"></see> class.</summary>
    public CanManyToManyRequest()
    {
      this.RequestName = "CanManyToMany";
      this.EntityName = (string) null;
    }
  }
}
