using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  delete an entity. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class DeleteEntityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the logical name of the entity. Required.</summary>
    /// <returns>Type: Returns_StringThe logical name of the entity. Required.</returns>
    public string LogicalName
    {
      get
      {
        return this.Parameters.Contains(nameof (LogicalName)) ? (string) this.Parameters[nameof (LogicalName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (LogicalName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.DeleteEntityRequest"></see> class.</summary>
    public DeleteEntityRequest()
    {
      this.RequestName = "DeleteEntity";
      this.LogicalName = (string) null;
    }
  }
}
