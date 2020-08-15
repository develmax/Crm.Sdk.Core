using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  remove members from a team.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RemoveMembersTeamRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the team.</summary>
    /// <returns>Type:  Returns_GuidThe ID of the team. This corresponds to the Team.TeamId property, which is the primary key for the Team entity.</returns>
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

    /// <summary>Gets or sets an array of IDs of the users to be removed from the team.</summary>
    /// <returns>Type:   Returns_Guid[]The array of IDs of the users to be removed from the team. Each element of the MemberIds array corresponds to the SystemUser.SystemUserId property, which is the primary key for the SystemUser entity.</returns>
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

    /// <summary>constructor_initializes<see cref="T:Microsoft.Crm.Sdk.Messages.RemoveMembersTeamRequest"></see> class.</summary>
    public RemoveMembersTeamRequest()
    {
      this.RequestName = "RemoveMembersTeam";
      this.TeamId = new Guid();
      this.MemberIds = (Guid[]) null;
    }
  }
}
