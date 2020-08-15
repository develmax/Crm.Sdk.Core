using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains information about a privilege.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RolePrivilege : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RolePrivilege"></see> class.</summary>
    public RolePrivilege()
    {
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RolePrivilege"></see> class by setting the depth and the privilege ID.</summary>
    /// <param name="depth">Type: Returns_Int32. The depth of the privilege.</param>
    /// <param name="privilegeId">Type: Returns_Guid. The ID of the privilege.</param>
    public RolePrivilege(int depth, Guid privilegeId)
    {
      this.Depth = (PrivilegeDepth) depth;
      this.PrivilegeId = privilegeId;
      this.BusinessUnitId = Guid.Empty;
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RolePrivilege"></see> class by setting the depth (as an integer), the privilege ID, and the business unit ID.</summary>
    /// <param name="depth">Type: Returns_Int32. The depth of the privilege.</param>
    /// <param name="privilegeId">Type: Returns_Guid. The ID of the privilege.</param>
    /// <param name="businessId">Type: Returns_Guid. The ID of the business unit.</param>
    public RolePrivilege(int depth, Guid privilegeId, Guid businessId)
      : this((PrivilegeDepth) depth, privilegeId, businessId)
    {
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RolePrivilege"></see> class by setting the depth, privilege ID, and business unit ID.</summary>
    /// <param name="depth">Type: <see cref="T:Microsoft.Crm.Sdk.Messages.PrivilegeDepth"></see>. The depth of the privilege.</param>
    /// <param name="privilegeId">Type: Returns_Guid. The ID of the privilege.</param>
    /// <param name="businessId">Type: Returns_Guid. The ID of the business unit.</param>
    public RolePrivilege(PrivilegeDepth depth, Guid privilegeId, Guid businessId)
    {
      this.Depth = depth;
      this.PrivilegeId = privilegeId;
      this.BusinessUnitId = businessId;
    }

    /// <summary>Gets or sets the depth of the privilege.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.PrivilegeDepth"></see>The depth of the privilege.</returns>
    [DataMember]
    public PrivilegeDepth Depth { get; set; }

    /// <summary>Gets or sets the ID of the privilege.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the privilege, which corresponds to the Privilege.PrivilegeID attribute, which is the primary key for the Privilege entity..</returns>
    [DataMember]
    public Guid PrivilegeId { get; set; }

    /// <summary>Gets or sets the ID of the business unit.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the business unit, which corresponds to the BusinessUnit.BusinessUnitID attribute, which is the primary key for the BusinessUnit entity..</returns>
    [DataMember]
    public Guid BusinessUnitId { get; set; }

    /// <summary>ExtensionData</summary>
    /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
    public ExtensionDataObject ExtensionData
    {
      get
      {
        return this._extensionDataObject;
      }
      set
      {
        this._extensionDataObject = value;
      }
    }
  }
}
