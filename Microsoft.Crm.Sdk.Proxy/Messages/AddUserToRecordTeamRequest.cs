using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to add a user to the auto created access team for the specified record. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddUserToRecordTeamRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the record for which the access team is auto created. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The record for which the access team is auto created, which must be an entity reference for an entity that is enabled for access teams. To enable an entity for the auto created access teams, set the <see cref="P:Microsoft.Xrm.Sdk.Metadata.EntityMetadata.AutoCreateAccessTeams"></see> attribute to true.</returns>
    public EntityReference Record
    {
      get
      {
        return this.Parameters.Contains(nameof (Record)) ? (EntityReference) this.Parameters[nameof (Record)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Record)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of team template which is used to create the access team. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the team template that corresponds to the TeamTemplate.TeamTemplateId attribute, which is the primary key for the TeamTemplate entity.</returns>
    public Guid TeamTemplateId
    {
      get
      {
        return this.Parameters.Contains(nameof (TeamTemplateId)) ? (Guid) this.Parameters[nameof (TeamTemplateId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (TeamTemplateId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of system user (user) to add to the auto created access team. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the system user (user) that corresponds to the SystemUser.SystemUserId attribute, which is the primary key for the SystemUser entity.</returns>
    public Guid SystemUserId
    {
      get
      {
        return this.Parameters.Contains(nameof (SystemUserId)) ? (Guid) this.Parameters[nameof (SystemUserId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (SystemUserId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AddUserToRecordTeamRequest"></see> class.</summary>
    public AddUserToRecordTeamRequest()
    {
      this.RequestName = "AddUserToRecordTeam";
      this.Record = (EntityReference) null;
      this.TeamTemplateId = new Guid();
      this.SystemUserId = new Guid();
    }
  }
}
