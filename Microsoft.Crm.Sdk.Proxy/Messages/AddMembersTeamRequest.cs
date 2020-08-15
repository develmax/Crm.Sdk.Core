using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to add members to a team.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddMembersTeamRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the team. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the team, that corresponds to the Team.TeamId attribute, which is the primary key for the Team entity.</returns>
    public Guid TeamId
    {
      get
      {
        return this.Parameters.Contains(nameof (TeamId)) ? (Guid) this.Parameters[nameof (TeamId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (TeamId)] = (object) value;
      }
    }

    /// <summary>Gets or sets an array of IDs for the users you want to add to the team. Required.</summary>
    /// <returns>Type: Returns_Guid[]
    /// The array of user IDs to add to the team. Each element of the MemberIds array corresponds to the SystemUser.SystemUserId property, which is the primary key for the SystemUser entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AddMembersTeamRequest"></see> class.</summary>
    public AddMembersTeamRequest()
    {
      this.RequestName = "AddMembersTeam";
      this.TeamId = new Guid();
      this.MemberIds = (Guid[]) null;
    }
  }
}
