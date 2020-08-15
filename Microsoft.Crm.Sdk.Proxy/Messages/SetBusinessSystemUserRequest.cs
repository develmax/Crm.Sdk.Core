using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  move a system user (user) to a different business unit.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SetBusinessSystemUserRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the user. Required.</summary>
    /// <returns>Type:  Returns_GuidThe ID of the user. This corresponds to the SystemUser.SystemUserId attribute, which is the primary key for the SystemUser entity.</returns>
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

    /// <summary>Gets or sets the ID of the business unit to which the user is moved. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the business unit to which the user is moved. This corresponds to the BusinessUnit.BusinessUnitId attribute, which is the primary key for the BusinessUnit entity.</returns>
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

    /// <summary>Gets or sets the target security principal (user) to which the instances of entities previously owned by the user are to be assigned. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target security principal (user) to which the instances of entities previously owned by the user are to be assigned. If this property is set to null or an empty string, an error occurs.</returns>
    public EntityReference ReassignPrincipal
    {
      get
      {
        return this.Parameters.Contains(nameof (ReassignPrincipal)) ? (EntityReference) this.Parameters[nameof (ReassignPrincipal)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (ReassignPrincipal)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.SetBusinessSystemUserRequest"></see> class.</summary>
    public SetBusinessSystemUserRequest()
    {
      this.RequestName = "SetBusinessSystemUser";
      this.UserId = new Guid();
      this.BusinessId = new Guid();
      this.ReassignPrincipal = (EntityReference) null;
    }
  }
}
