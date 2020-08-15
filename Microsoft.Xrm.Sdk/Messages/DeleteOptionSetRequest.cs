using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  delete a global option set. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class DeleteOptionSetRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the global option set to delete. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the global option set to delete. Required.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.DeleteOptionSetRequest"></see> class</summary>
    public DeleteOptionSetRequest()
    {
      this.RequestName = "DeleteOptionSet";
      this.Name = (string) null;
    }
  }
}
