using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to create a record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateRequest : OrganizationRequest
  {
    /// <summary>Gets or sets an instance of an entity that you can use to create a new record. Required. </summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>
    /// The entity instance.</returns>
    public Entity Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (Entity) this.Parameters[nameof (Target)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateRequest"></see> class.</summary>
    public CreateRequest()
    {
      this.RequestName = "Create";
      this.Target = (Entity) null;
    }
  }
}
