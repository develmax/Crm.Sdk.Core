using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  add a member to a list (marketing list).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddMemberListRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the list. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the list that corresponds to the List.ListId attribute, which is the primary key for the List entity.</returns>
    public Guid ListId
    {
      get
      {
        return this.Parameters.Contains(nameof (ListId)) ? (Guid) this.Parameters[nameof (ListId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ListId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the member you want to add to the list. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the member you want to add to the list.</returns>
    public Guid EntityId
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityId)) ? (Guid) this.Parameters[nameof (EntityId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (EntityId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AddMemberListRequest"></see> class.</summary>
    public AddMemberListRequest()
    {
      this.RequestName = "AddMemberList";
      this.ListId = new Guid();
      this.EntityId = new Guid();
    }
  }
}
