using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  initialize a new record from an existing record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class InitializeFromRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the record that is the source for initializing.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The record that is the source for initializing.</returns>
    public EntityReference EntityMoniker
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityMoniker)) ? (EntityReference) this.Parameters[nameof (EntityMoniker)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (EntityMoniker)] = (object) value;
      }
    }

    /// <summary>Gets or sets the logical name of the target entity.</summary>
    /// <returns>Type: Returns_StringThe logical name of the target entity.</returns>
    public string TargetEntityName
    {
      get
      {
        return this.Parameters.Contains(nameof (TargetEntityName)) ? (string) this.Parameters[nameof (TargetEntityName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (TargetEntityName)] = (object) value;
      }
    }

    /// <summary>Gets or sets which attributes are to be initialized in the initialized instance.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.TargetFieldType"></see>Indicates which attributes are to be initialized in the initialized instance.</returns>
    public TargetFieldType TargetFieldType
    {
      get
      {
        return this.Parameters.Contains(nameof (TargetFieldType)) ? (TargetFieldType) this.Parameters[nameof (TargetFieldType)] : TargetFieldType.All;
      }
      set
      {
        this.Parameters[nameof (TargetFieldType)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.InitializeFromRequest"></see> class.</summary>
    public InitializeFromRequest()
    {
      this.RequestName = "InitializeFrom";
      this.EntityMoniker = (EntityReference) null;
      this.TargetEntityName = (string) null;
      this.TargetFieldType = TargetFieldType.All;
    }
  }
}
