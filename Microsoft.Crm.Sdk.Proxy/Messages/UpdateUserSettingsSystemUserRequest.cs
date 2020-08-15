using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.UpdateRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class UpdateUserSettingsSystemUserRequest : OrganizationRequest
  {
    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.UpdateRequest"></see> class and its members.</summary>
    /// <returns>Type: <see cref="T:System.Guid"></see>.</returns>
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

    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.UpdateRequest"></see> class and its members.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>.</returns>
    public Entity Settings
    {
      get
      {
        return this.Parameters.Contains(nameof (Settings)) ? (Entity) this.Parameters[nameof (Settings)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Settings)] = (object) value;
      }
    }

    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.UpdateRequest"></see> class and its members.</summary>
    public UpdateUserSettingsSystemUserRequest()
    {
      this.RequestName = "UpdateUserSettingsSystemUser";
      this.UserId = new Guid();
      this.Settings = (Entity) null;
    }
  }
}
