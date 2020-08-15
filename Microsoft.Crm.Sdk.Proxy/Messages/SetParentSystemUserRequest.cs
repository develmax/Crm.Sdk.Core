using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data needed to set a new parent system user (user) for the specified user.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SetParentSystemUserRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the user. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the user. This corresponds to the SystemUser.SystemUserId attribute, which is the primary key for the SystemUser entity.</returns>
    public Guid UserId
    {
      get
      {
        return this.Parameters.Contains(nameof (UserId)) ? (Guid) this.Parameters[nameof (UserId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (UserId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the new parent user. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the new parent user. This corresponds to the SystemUser.SystemUserId attribute, which is the primary key for the SystemUser entity.</returns>
    public Guid ParentId
    {
      get
      {
        return this.Parameters.Contains(nameof (ParentId)) ? (Guid) this.Parameters[nameof (ParentId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ParentId)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether the child users are to be retained. Required.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether the child users are to be retained. Use true to retain the child users reporting to the original user, otherwise, use false (default) to update the child users to report to the original manager of the user.</returns>
    public bool KeepChildUsers
    {
      get
      {
        return this.Parameters.Contains(nameof (KeepChildUsers)) && (bool) this.Parameters[nameof (KeepChildUsers)];
      }
      set
      {
        this.Parameters[nameof (KeepChildUsers)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.SetParentSystemUserRequest"></see> class.</summary>
    public SetParentSystemUserRequest()
    {
      this.RequestName = "SetParentSystemUser";
      this.UserId = new Guid();
      this.ParentId = new Guid();
      this.KeepChildUsers = false;
    }
  }
}
