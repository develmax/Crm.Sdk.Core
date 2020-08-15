using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.AddUserToRecordTeamRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddUserToRecordTeamResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the auto created access team. </summary>
    /// <returns>Type: Returns_GuidThe ID of the auto created access team, which corresponds to the Team.TeamId attribute, which is the primary key for the Team entity.</returns>
    public Guid AccessTeamId
    {
      get
      {
        return this.Results.Contains(nameof (AccessTeamId)) ? (Guid) this.Results[nameof (AccessTeamId)] : new Guid();
      }
    }
  }
}
