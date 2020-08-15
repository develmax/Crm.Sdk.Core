using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create future unexpanded instances for the recurring appointment master.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CreateInstanceRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target appointment instance to create. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The target appointment instance to create. This is an instance of the Appointment class, which is a subclass of the Entity class.</returns>
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

    /// <summary>Gets or sets the number of instances to be created. Required.</summary>
    /// <returns>Type: Returns_Int32The number of instances to be created.</returns>
    public int Count
    {
      get
      {
        return this.Parameters.Contains(nameof (Count)) ? (int) this.Parameters[nameof (Count)] : 0;
      }
      set
      {
        this.Parameters[nameof (Count)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.CreateInstanceRequest"></see> class.</summary>
    public CreateInstanceRequest()
    {
      this.RequestName = "CreateInstance";
      this.Target = (Entity) null;
      this.Count = 0;
    }
  }
}
