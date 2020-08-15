using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  add members to the list. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddListMembersListRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the list. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the list. This corresponds to the List.ListId attribute, which is the primary key for the List entity.</returns>
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

    /// <summary>Gets or sets an array of IDs of the members that you want to add to the list. Required.</summary>
    /// <returns>Type: Returns_Guid[]
    /// The array of IDs of the members that you want to add to the list.</returns>
    public Guid[] MemberIds
    {
      get
      {
        return this.Parameters.Contains(nameof (MemberIds)) ? (Guid[]) this.Parameters[nameof (MemberIds)] : (Guid[]) null;
      }
      set
      {
        this.Parameters[nameof (MemberIds)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AddListMembersListRequest"></see> class.</summary>
    public AddListMembersListRequest()
    {
      this.RequestName = "AddListMembersList";
      this.ListId = new Guid();
      this.MemberIds = (Guid[]) null;
    }
  }
}
