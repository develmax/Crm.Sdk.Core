using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the privileges for a team.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveTeamPrivilegesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the team for which you want to retrieve privileges.</summary>
    /// <returns>Type: Returns_GuidThe team for which you want to retrieve privileges. This corresponds to the Team.TeamId attribute, which is the primary key for the Team entity.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveTeamPrivilegesRequest"></see> class.</summary>
    public RetrieveTeamPrivilegesRequest()
    {
      this.RequestName = "RetrieveTeamPrivileges";
      this.TeamId = new Guid();
    }
  }
}
