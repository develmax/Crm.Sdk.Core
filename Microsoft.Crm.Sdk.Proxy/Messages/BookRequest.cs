using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to schedule or “book” an appointment, recurring appointment, or service appointment (service activity).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class BookRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the record that is the target of the book operation. Required.</summary>
    /// <returns>Type:<see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The target of the book operation.</returns>
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

    /// <returns>Type: Returns_Boolean.</returns>
    public bool ReturnNotifications
    {
      get
      {
        return this.Parameters.Contains(nameof (ReturnNotifications)) && (bool) this.Parameters[nameof (ReturnNotifications)];
      }
      set
      {
        this.Parameters[nameof (ReturnNotifications)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.BookRequest"></see> Class.</summary>
    public BookRequest()
    {
      this.RequestName = "Book";
      this.Target = (Entity) null;
    }
  }
}
