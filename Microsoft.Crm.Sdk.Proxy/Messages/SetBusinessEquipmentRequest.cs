using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  assign equipment (facility/equipment) to a specific business unit.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SetBusinessEquipmentRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the equipment (facility/equipment).</summary>
    /// <returns>Type: Returns_GuidThe ID of the equipment (facility/equipment). This corresponds to the Equipment.EquipmentId attribute, which is the primary key for the Equipment entity.</returns>
    public Guid EquipmentId
    {
      get
      {
        return this.Parameters.Contains(nameof (EquipmentId)) ? (Guid) this.Parameters[nameof (EquipmentId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (EquipmentId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the business unit.</summary>
    /// <returns>Type: Returns_GuidThe ID of the business unit. This corresponds to the BusinessUnit.BusinessUnitId attribute, which is the primary key for the BusinessUnit entity.</returns>
    public Guid BusinessUnitId
    {
      get
      {
        return this.Parameters.Contains(nameof (BusinessUnitId)) ? (Guid) this.Parameters[nameof (BusinessUnitId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (BusinessUnitId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.SetBusinessEquipmentRequest"></see> class.</summary>
    public SetBusinessEquipmentRequest()
    {
      this.RequestName = "SetBusinessEquipment";
      this.EquipmentId = new Guid();
      this.BusinessUnitId = new Guid();
    }
  }
}
