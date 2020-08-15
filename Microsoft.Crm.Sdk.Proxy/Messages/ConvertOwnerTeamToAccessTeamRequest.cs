using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to convert a team of type owner to a team of type access. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ConvertOwnerTeamToAccessTeamRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the owner team to be converted. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the team to be converted that corresponds to the Team.TeamId attribute, which is the primary key for the Team entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ConvertOwnerTeamToAccessTeamRequest"></see> class.</summary>
    public ConvertOwnerTeamToAccessTeamRequest()
    {
      this.RequestName = "ConvertOwnerTeamToAccessTeam";
      this.TeamId = new Guid();
    }
  }
}
