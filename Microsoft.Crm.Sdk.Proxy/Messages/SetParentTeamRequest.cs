using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data needed to set the parent business unit of a team.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SetParentTeamRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the team. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the team. This corresponds to the Team.TeamId attribute, which is the primary key for the Team entity.</returns>
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

    /// <summary>Gets or sets the ID of the business unit to which to move the team. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the business unit to which to move the team. This corresponds to the BusinessUnit.BusinessUnitId attribute, which is the primary key for the BusinessUnit entity. </returns>
    public Guid BusinessId
    {
      get
      {
        return this.Parameters.Contains(nameof (BusinessId)) ? (Guid) this.Parameters[nameof (BusinessId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (BusinessId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.SetParentTeamRequest"></see> class.</summary>
    public SetParentTeamRequest()
    {
      this.RequestName = "SetParentTeam";
      this.TeamId = new Guid();
      this.BusinessId = new Guid();
    }
  }
}
