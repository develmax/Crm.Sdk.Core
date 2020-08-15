using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  remove a member from a list (marketing list).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RemoveMemberListRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the list. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the list. This corresponds to the List.ListId attribute, which is the primary key for the List entity.</returns>
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

    /// <summary>Gets or sets the ID of the member to be removed from the list. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the member to be removed from the list. This corresponds to the ListMember.ListMemberId attribute, which is the primary key for the ListMember intersect entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RemoveMemberListRequest"></see> class.</summary>
    public RemoveMemberListRequest()
    {
      this.RequestName = "RemoveMemberList";
      this.ListId = new Guid();
      this.EntityId = new Guid();
    }
  }
}
