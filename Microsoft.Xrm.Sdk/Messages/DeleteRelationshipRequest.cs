using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  delete an entity relationship. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class DeleteRelationshipRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the relationship to delete. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the relationship to delete. Required.</returns>
    public string Name
    {
      get
      {
        return this.Parameters.Contains(nameof (Name)) ? (string) this.Parameters[nameof (Name)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (Name)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.DeleteRelationshipRequest"></see> class</summary>
    public DeleteRelationshipRequest()
    {
      this.RequestName = "DeleteRelationship";
      this.Name = (string) null;
    }
  }
}
